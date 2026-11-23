# FlashPoint Prehistoric Breakfast Rescue — demo visual

Proyecto Unity experimental: abrir esta carpeta con Unity Hub usando **6000.6.8f1**, y abrir `Assets/Scenes/Main_PrefabTest.unity`. Esperar a que Unity resuelva los paquetes de `Packages/manifest.json` y `Packages/packages-lock.json`. No se requiere Python para esta demostración visual.

## Uso

Entra en Play. Pulsa **F1** o el botón «DEMO VISUAL — controles» para abrir o cerrar el panel. Selecciona fila 0–5 y columna 0–7. Los botones cambian humo, fuego o ausencia de peligro en la celda; muestran una explosión temporal; presentan objetivo, falsa alarma o rescate; alternan los estados de un muro y una puerta provisional; y reinician la demostración.

Las filas empiezan en el lado de Z positiva y las columnas en X negativa. Las 48 posiciones se calculan con los límites del renderizador del suelo, no con coordenadas codificadas. El ejemplo visual de muro afecta solo a la instancia configurada en el componente; los colliders no cambian. La puerta es una representación provisional, no una puerta funcional. El huevo se instancia a partir del modelo existente y el campamento existente representa el destino. Una falsa alarma retira el objetivo visible; no contabiliza víctimas.

La lava dibujada en el material original es decorativa y permanece visible tanto con peligro como sin él. El fuego y el humo son partículas independientes y reemplazables por celda. La explosión es una ráfaga autolimpiable, con un máximo de cuatro simultáneas. Reiniciar elimina instancias visuales y restaura los renderizadores del muro.

## Integración y límites

**DEMO VISUAL**: no hay conexión con Python/Mesa, simulación multiagente, propagación, turnos, cálculo de rutas ni reglas de victoria. Los botones no generan eventos inteligentes. `VisualDemoController` ofrece `SetCellHazard`, `ShowExplosion`, `SetPoi`, `SetWallState`, `SetDoorState` y `ResetDemo` para recibir en el futuro estados ya confirmados por el backend; todavía no existe transporte ni contrato validado con Mesa. La correspondencia de índices y bordes deberá acordarse con ese backend antes de integrarla.

Los estados de daño se representan ocultando renderizadores durante Play y se revierten al reiniciar o salir de Play; no modifican geometría, física ni prefabs originales. La visibilidad de humo y fuego a escala del tablero y el aspecto provisional de la puerta requieren revisión artística. El objetivo usa el conjunto de huevo existente; no se identificó un recurso independiente verificado de huevo roto o puerta.

## Archivos para otro clon

Conservar `Assets/` y todos sus `.meta`, `Packages/manifest.json`, `Packages/packages-lock.json` y `ProjectSettings/`, incluyendo `ProjectVersion.txt`. Los prefabs nuevos y sus materiales viven en `Assets/FlashPointVisualDemo/`; dependen de texturas existentes en `Assets/Externals/Particles/` y del modelo en `Assets/Externals/Egg/`. No se instalaron paquetes nuevos. Comprobar las licencias y condiciones de redistribución de los recursos externos antes de publicar; no se identificó un archivo de licencia para todos ellos.

No compartir `Library/`, `Temp/`, `Obj/`, `Logs/`, `UserSettings/`, archivos de solución generados, `VisualRecoveryBackup/`, credenciales, archivos `.env` ni configuración personal. La disponibilidad de archivos en el clon debe confirmarse con `git status` y una prueba en un clon limpio antes de publicar. No se ha hecho esa prueba desde este entorno.
