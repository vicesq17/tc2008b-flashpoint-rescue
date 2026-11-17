# Visualización Unity 3D

Esta carpeta reserva el espacio para la visualización. Todavía no es un proyecto
Unity ejecutable: no se han generado escenas, paquetes, ajustes ni archivos `.meta`.

## Creación posterior

Crear con Unity Hub un proyecto 3D nuevo en `unity/FlashpointRescue/`, acordando
primero la versión del Editor con el compañero. No importar ni modificar
proyectos originales del profesor. Registrar aquí la versión exacta y el pipeline
elegidos antes del primer PR de Unity.

## Estructura prevista en el proyecto nuevo

```text
FlashpointRescue/
  Assets/
    Art/
    Materials/
    Prefabs/
    Scenes/
    Scripts/
      Data/
      Domain/
      Framework/
      Utils/
  Packages/
  ProjectSettings/
```

- `Data`: entidades de estado y servicios/repositorios de conexión HTTP/JSON.
- `Domain`: casos de uso y coordinación de la visualización.
- `Framework`: vistas, controladores y componentes de Unity.
- `Utils`: utilidades compartidas.

Python mantiene las reglas del rescate. Unity no debe duplicarlas.
La adaptación del Lab 2 propone una entidad `GameState`, un `APIHelper` y un
controlador que actualice objetos; el protocolo final está pendiente.

## Escena y colaboración (Lab 4)

Organizar la jerarquía en `Managers`, `Setup`, `Environment` (con `Units` cuando
convenga), `Canvases` y `Systems`. Reservar `Systems` para objetos persistentes.
Usar prefabs independientes para cavernícolas, huevos y entorno; acordar una
persona integradora de la escena por iteración.

Configurar Visible Meta Files y Force Text. Subir `Assets/` y sus `.meta`,
`Packages/` y `ProjectSettings/`. La regla Unity de la raíz ya cubre cachés y builds
dentro de subcarpetas. Ver también [colaboración](../CONTRIBUTING.md).
