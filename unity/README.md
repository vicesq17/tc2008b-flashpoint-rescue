# Unity 3D

Aquí se incorporará la visualización del rescate. Todavía no hay un proyecto
Unity ejecutable en Git. El Google Doc del equipo ya describe un avance visual:
se debe importar ese proyecto existente en `unity/FlashpointRescue/`, conservando
su versión del Editor, paquetes, assets y archivos `.meta`.

Seguir la [guía para Luis](../docs/unity-onboarding.md). Crear un proyecto nuevo
solo si el equipo confirma que no existe el avance original.

## Organización prevista

- `Assets/Scenes/`: escenas.
- `Assets/Prefabs/`: cavernícolas, huevos y partes del escenario reutilizables.
- `Assets/Models/`, `Assets/Materials/`, `Assets/Textures/` y `Assets/Music/`:
  recursos visuales y sonido, siguiendo los ejemplos del laboratorio. Las carpetas
  propias de paquetes externos pueden conservarse.
- `Assets/Scripts/`: código separado en `Data`, `Domain`, `Framework` y `Utils`,
  tomando como referencia el Laboratorio 4.

En la escena se usarán los grupos `Managers`, `Setup`, `Environment`, `Canvases`
y `Systems` propuestos en el laboratorio. Python llevará las reglas; Unity
mostrará los estados recibidos.

Para colaborar, cada integrante trabajará sus prefabs y se coordinará la
integración de la escena. Se usará Visible Meta Files y Force Text, conservando
los `.meta`, `Packages/` y `ProjectSettings/` en Git. Las cachés y builds quedan
excluidas por `.gitignore`.
