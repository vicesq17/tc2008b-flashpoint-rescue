# Conexión posterior: Unity cliente y Python servidor

## Qué muestran los laboratorios

El [Lab 2 - Llamadas API en Unity](https://groups.meeplab.com/contenidos/tc2008b/intro-unity/api-calls-unity)
enseña un cliente Unity que solicita datos a una API HTTP y recibe JSON. Usa
`UnityWebRequest`, una corrutina con `yield return SendWebRequest()`, comprobación
de errores y entidades `[System.Serializable]` deserializadas con `JsonUtility`.
Una función de retorno entrega los datos a la vista sin bloquear el juego.
El servicio del ejemplo es externo: el laboratorio no implementa el servidor
Python de nuestro juego.

El [Lab 4](https://groups.meeplab.com/contenidos/tc2008b/intro-unity/project-structure)
amplía la separación en Data, Domain, Framework y Utils. La siguiente aplicación
de esas ideas es una **propuesta del equipo pendiente de implementar**, no una
funcionalidad disponible ni un contrato exigido literalmente por el laboratorio.

## Reparto de responsabilidades

```text
Unity (cliente C#) -- solicitud HTTP --> Python (API + simulación Mesa)
Unity (vista 3D)   <-- estado JSON ---- Python (reglas y agentes)
```

| Parte | Lugar previsto | Responsabilidad |
| --- | --- | --- |
| Modelo y agentes | `python/src/flashpoint_rescue/model/` y `agents/` | Tablero, turnos, rescates, fuego y decisiones. |
| Servidor HTTP | `python/src/flashpoint_rescue/api/` | Exponer operaciones y serializar el estado; framework pendiente. |
| Entidades y acceso a datos | Unity `Assets/Scripts/Data/` | Objetos JSON, servicio de red y repositorio. |
| Casos de uso | Unity `Assets/Scripts/Domain/` | Solicitar estado o avance mediante el repositorio. |
| Componentes y presentación | Unity `Assets/Scripts/Framework/` | Iniciar corrutinas desde MonoBehaviour y actualizar vistas. |
| Utilidades | Unity `Assets/Scripts/Utils/` | Funciones compartidas sin reglas de la simulación duplicadas. |

La dependencia concreta de `UnityWebRequest` puede aislarse en un adaptador para
mantener las entidades sin heredar de `MonoBehaviour`, siguiendo la separación
del laboratorio. Unity representa los resultados; Python decide las reglas.
GitHub almacena y coordina el código: subir el repositorio no ejecuta un servidor.

## Contrato mínimo a acordar

El [JSON actual](json-contract.md) y su [ejemplo](examples/game-state.example.json)
son incompletos. Antes de escribir el cliente y el servidor, acordar juntos:

- URL base configurable, puerto y versión de API. Para probar en una misma
  computadora se puede usar `http://127.0.0.1:<puerto-acordado>`. En computadoras
  distintas `localhost` apunta a cada computadora, no a la del compañero.
- Una operación de lectura de estado que no avance turnos y una operación
  explícita para avanzar. Nombres, métodos y rutas se deciden en el PR de API;
  no hay endpoints operativos todavía.
- Mapa, coordenadas fila/columna y su conversión a ejes Unity; tamaño 6x8 según
  el avance, identificadores de los seis agentes, nidos/huevos, lava, puertas,
  daños, PA y condiciones de término.
- Versión del esquema, tipos de datos y errores. Los campos C# deben coincidir
  con el JSON y probarse con `JsonUtility`; evitar suponer soporte de cualquier
  diccionario o estructura sin comprobarlo.
- Quién controla el avance y cómo impedir peticiones concurrentes o turnos
  duplicados por clics/reintentos. Un error de red tras avanzar no garantiza que
  el servidor no haya procesado el turno.
- Timeout, cancelación, frecuencia de consulta y estados de interfaz cuando el
  servidor no responde. No hacer llamadas bloqueantes ni una petición en cada
  frame; una sola solicitud pendiente durante la prueba inicial.

## Integración por etapas

1. **Importación Unity:** Luis publica el proyecto completo en su rama y ambos
   consiguen abrirlo en la misma versión del Editor.
2. **Acuerdo JSON:** ambos completan `json-contract.md` y el ejemplo. Se fija
   una respuesta de estado que represente el tablero y los agentes.
3. **Servidor:** implementar la API en Python y documentar dependencias, comando
   de inicio, puerto y operación de prueba. Empezar en la interfaz local
   `127.0.0.1`. No está implementado ni se ha desplegado un servidor en esta auditoría.
4. **Cliente:** un componente inicia la corrutina, el servicio comprueba el
   resultado de `UnityWebRequest`, convierte el JSON y actualiza prefabs/UI.
   Mostrar el error sin congelar la ventana. Mantener la URL configurable.
5. **Prueba de extremo a extremo:** iniciar primero Python; leer su JSON por
   navegador o herramienta HTTP; iniciar Unity y comprobar posiciones; avanzar
   un turno y verificar que solo avance una vez; detener Python y comprobar
   que Unity siga respondiendo y permita recuperarse.
6. **Red o WebGL, si se requiere:** decidir despliegue y acceso. Editor/escritorio
   y WebGL tienen condiciones distintas; WebGL requiere revisar CORS y contenido
   mixto. No abrir puertos del equipo ni publicar servicios por defecto.

Cada etapa puede tener su propia rama y PR hacia la integración de la iteración.
La guía de ejecución se completará al tener implementaciones reales; por ahora
no hay un comando de servidor ni conexión probada que se pueda prometer.
