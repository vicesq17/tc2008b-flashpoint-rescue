# Unity 3D

Aquí se creará la visualización del rescate. Todavía no hay un proyecto Unity
ejecutable. Primero se acordará la versión del Editor y se creará un proyecto
3D nuevo en `unity/FlashpointRescue/`.

## Organización prevista

- `Assets/Scenes/`: escenas.
- `Assets/Prefabs/`: cavernícolas, huevos y partes del escenario reutilizables.
- `Assets/Art/` y `Assets/Materials/`: recursos visuales.
- `Assets/Scripts/`: código separado en `Data`, `Domain`, `Framework` y `Utils`,
  tomando como referencia el Laboratorio 4.

En la escena se usarán los grupos `Managers`, `Setup`, `Environment`, `Canvases`
y `Systems` propuestos en el laboratorio. Python llevará las reglas; Unity
mostrará los estados recibidos.

Para colaborar, cada integrante trabajará sus prefabs y se coordinará la
integración de la escena. Se usará Visible Meta Files y Force Text, conservando
los `.meta`, `Packages/` y `ProjectSettings/` en Git. Las cachés y builds quedan
excluidas por `.gitignore`.
