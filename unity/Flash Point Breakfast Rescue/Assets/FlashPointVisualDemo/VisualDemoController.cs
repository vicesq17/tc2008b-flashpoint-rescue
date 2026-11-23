using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlashPoint.VisualDemo
{
    public enum HazardView { None, Smoke, Fire }
    public enum PoiView { None, Objective, FalseAlarm, Rescued }
    public enum WallView { Intact, Damaged, Destroyed }
    public enum DoorView { Closed, Open, Destroyed }

    // Visual adapter only: no rules, random events, or backend communication.
    public sealed class VisualDemoController : MonoBehaviour
    {
        public Renderer board;
        public Renderer camp;
        public Transform demoWall;
        public GameObject firePrefab, smokePrefab, explosionPrefab, eggModel;
        private readonly Dictionary<int, GameObject> hazards = new Dictionary<int, GameObject>();
        private readonly List<GameObject> transients = new List<GameObject>();
        private GameObject poi, door;
        private Renderer[] wallRenderers;
        private bool[] initialWallEnabled;
        private string status = "Sin eventos. DEMO VISUAL: no conectada a Mesa.";
        private int selectedRow = 2, selectedColumn = 3;
        private bool showControls;

        private void Update() { if (Input.GetKeyDown(KeyCode.F1)) showControls = !showControls; }
        private WallView wallState = WallView.Intact;
        private DoorView doorState = DoorView.Destroyed;

        public Vector3 CellCenter(int row, int column)
        {
            if (board == null || row < 0 || row >= 6 || column < 0 || column >= 8)
                throw new ArgumentOutOfRangeException("Celda fuera del tablero 6 x 8");
            Bounds b = board.bounds;
            return new Vector3(b.min.x + (column + 0.5f) * b.size.x / 8f,
                               b.max.y + 0.05f,
                               b.max.z - (row + 0.5f) * b.size.z / 6f);
        }

        private void Awake()
        {
            if (demoWall != null)
            {
                wallRenderers = demoWall.GetComponentsInChildren<Renderer>(true);
                initialWallEnabled = new bool[wallRenderers.Length];
                for (int i = 0; i < wallRenderers.Length; i++) initialWallEnabled[i] = wallRenderers[i].enabled;
            }
        }

        public void SetCellHazard(int row, int column, HazardView state)
        {
            Vector3 position = CellCenter(row, column);
            int key = row * 8 + column;
            GameObject old;
            if (hazards.TryGetValue(key, out old))
            {
                if (old != null) Destroy(old);
                hazards.Remove(key);
            }
            GameObject prefab = state == HazardView.Fire ? firePrefab : state == HazardView.Smoke ? smokePrefab : null;
            if (prefab != null)
            {
                GameObject effect = Instantiate(prefab, position, Quaternion.identity, transform);
                hazards.Add(key, effect);
            }
            status = "Celda " + row + "," + column + ": " + state;
        }

        public void ShowExplosion(int row, int column)
        {
            transients.RemoveAll(effect => effect == null);
            if (transients.Count >= 4) { status = "Límite visual de explosiones alcanzado."; return; }
            if (explosionPrefab != null)
                transients.Add(Instantiate(explosionPrefab, CellCenter(row, column), Quaternion.identity, transform));
            status = "Explosión visual temporal; no aplica daño.";
        }

        public void SetPoi(int row, int column, PoiView state)
        {
            Vector3 position = CellCenter(row, column);
            if (poi != null) Destroy(poi);
            poi = null;
            if ((state == PoiView.Objective || state == PoiView.Rescued) && eggModel != null)
            {
                if (state == PoiView.Rescued && camp != null)
                    position = camp.bounds.center + Vector3.up * 0.15f;
                poi = Instantiate(eggModel, position, Quaternion.identity, transform);
                Renderer[] renderers = poi.GetComponentsInChildren<Renderer>();
                if (renderers.Length > 0)
                {
                    Bounds bounds = renderers[0].bounds;
                    for (int i = 1; i < renderers.Length; i++) bounds.Encapsulate(renderers[i].bounds);
                    float largest = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
                    if (largest > 0.001f)
                    {
                        poi.transform.localScale *= 4f / largest;
                        bounds = renderers[0].bounds;
                        for (int i = 1; i < renderers.Length; i++) bounds.Encapsulate(renderers[i].bounds);
                        poi.transform.position += position - new Vector3(bounds.center.x, bounds.min.y, bounds.center.z);
                    }
                }
            }
            status = state == PoiView.FalseAlarm ? "Falsa alarma revelada: marcador retirado." :
                     state == PoiView.Rescued ? "Rescate visual completado: huevo en campamento." :
                     state == PoiView.Objective ? "Objetivo de rescate visible." : "Sin objetivo visual.";
        }

        public void SetWallState(WallView state)
        {
            wallState = state;
            if (wallRenderers != null)
                for (int i = 0; i < wallRenderers.Length; i++)
                    wallRenderers[i].enabled = initialWallEnabled[i] &&
                        (state == WallView.Intact || (state == WallView.Damaged && i < wallRenderers.Length - 2));
            status = "Muro: " + state + " (vista solamente; colisiones intactas).";
        }

        public void SetDoorState(int row, int column, DoorView state)
        {
            Vector3 cell = CellCenter(row, column);
            doorState = state;
            if (door != null) Destroy(door);
            door = null;
            if (state != DoorView.Destroyed)
            {
                door = GameObject.CreatePrimitive(PrimitiveType.Cube);
                door.name = "Puerta provisional - DEMO VISUAL";
                door.transform.SetParent(transform, false);
                Bounds b = board.bounds;
                float width = b.size.x / 8f;
                door.transform.position = cell + new Vector3(width * 0.5f, 1f, 0f);
                door.transform.localScale = new Vector3(0.35f, 2f, width * 0.55f);
                if (state == DoorView.Open) door.transform.Rotate(0, 75, 0);
                Collider collider = door.GetComponent<Collider>();
                if (collider != null) Destroy(collider);
                if (demoWall != null)
                {
                    Renderer rock = demoWall.GetComponentInChildren<Renderer>();
                    if (rock != null) door.GetComponent<Renderer>().sharedMaterial = rock.sharedMaterial;
                }
            }
            status = "Puerta provisional: " + state + " (vista solamente).";
        }

        public void ResetDemo()
        {
            foreach (GameObject effect in hazards.Values) if (effect != null) Destroy(effect);
            hazards.Clear();
            foreach (GameObject effect in transients) if (effect != null) Destroy(effect);
            transients.Clear();
            if (poi != null) Destroy(poi);
            if (door != null) Destroy(door);
            poi = null; door = null;
            SetWallState(WallView.Intact);
            wallState = WallView.Intact; doorState = DoorView.Destroyed;
            status = "Reiniciada. DEMO VISUAL: no conectada a Mesa.";
        }

        private void OnGUI()
        {
            Matrix4x4 originalMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1f));
            if (GUI.Button(new Rect(12, 12, 275, 32), showControls ? "Ocultar controles (F1)" : "DEMO VISUAL — controles (F1)")) showControls = !showControls;
            if (!showControls) { GUI.matrix = originalMatrix; return; }
            GUILayout.BeginArea(new Rect(12, 50, 380, 410), GUI.skin.box);
            GUILayout.Label("DEMO VISUAL — sin conexión a Mesa");
            GUILayout.Label("Celda (fila 0–5, columna 0–7): " + selectedRow + ", " + selectedColumn);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Fila −")) selectedRow = Mathf.Max(0, selectedRow - 1);
            if (GUILayout.Button("Fila +")) selectedRow = Mathf.Min(5, selectedRow + 1);
            if (GUILayout.Button("Col −")) selectedColumn = Mathf.Max(0, selectedColumn - 1);
            if (GUILayout.Button("Col +")) selectedColumn = Mathf.Min(7, selectedColumn + 1);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Humo")) SetCellHazard(selectedRow, selectedColumn, HazardView.Smoke);
            if (GUILayout.Button("Fuego")) SetCellHazard(selectedRow, selectedColumn, HazardView.Fire);
            if (GUILayout.Button("Apagar")) SetCellHazard(selectedRow, selectedColumn, HazardView.None);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Explosión visual")) ShowExplosion(selectedRow, selectedColumn);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Objetivo")) SetPoi(selectedRow, selectedColumn, PoiView.Objective);
            if (GUILayout.Button("Falsa alarma")) SetPoi(selectedRow, selectedColumn, PoiView.FalseAlarm);
            if (GUILayout.Button("Rescatado")) SetPoi(selectedRow, selectedColumn, PoiView.Rescued);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Alternar muro: intacto / dañado / destruido"))
                SetWallState((WallView)(((int)wallState + 1) % 3));
            if (GUILayout.Button("Alternar puerta provisional"))
                SetDoorState(selectedRow, selectedColumn, doorState = (DoorView)(((int)doorState + 1) % 3));
            if (GUILayout.Button("Reiniciar demostración")) ResetDemo();
            GUILayout.Label(status);
            GUILayout.EndArea();
            GUI.matrix = originalMatrix;
        }
    }
}
