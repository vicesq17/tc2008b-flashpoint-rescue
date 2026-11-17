# tc2008b-flashpoint-rescue

Proyecto TC2008B: simulación multiagente inspirada en Flash Point con cavernícolas
rescatando huevos. Python/Mesa controla la simulación y Unity muestra el estado en 3D.

**Estado: organización preliminar.** No hay todavía una simulación, API o escena
ejecutables. Las reglas y el contrato JSON deben acordarse con el equipo.

## Estructura

```text
python/                         Modelo y agentes Mesa 3.5
unity/                          Espacio e instrucciones para Unity 3D
docs/                           Arquitectura y propuesta JSON
.github/PULL_REQUEST_TEMPLATE.md Plantilla de revisión
CHANGELOG.md                    Historial de cambios
CONTRIBUTING.md                  Acuerdos de colaboración
```

## Primeros pasos

1. Leer [arquitectura](docs/architecture.md) y [colaboración](CONTRIBUTING.md).
2. Preparar el [entorno Python](python/README.md) con Python >=3.12 y Mesa 3.5.0.
3. Acordar la versión del Editor antes de crear el [proyecto Unity](unity/README.md).
4. Revisar la [propuesta JSON](docs/json-contract.md) antes de programar la conexión.

El trabajo se realiza localmente. No se requieren servicios facturables.

## Ramas y Pull Requests

Flujo del Lab 4: `main` estable, `pre-release-0.0.1` para integración y una rama
por funcionalidad. Ejemplo: `pre-release-0.0.1.1-feature-project-structure`.
Los PR de funcionalidades van hacia la rama pre-release; al validar la iteración,
se propone el PR hacia `main`. Ver [CONTRIBUTING.md](CONTRIBUTING.md).

## Equipo y licencia

Repositorio privado de `vicesq17`. La invitación del compañero queda pendiente
hasta recibir su usuario de GitHub; no se asume su nombre ni se asignan tareas.
Sin licencia inicialmente. Los originales del profesor no se modifican ni se
copian a este repositorio.
