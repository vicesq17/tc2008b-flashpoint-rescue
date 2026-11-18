# TC2008B - Flash Point Rescue

Proyecto colaborativo de TC2008B: una simulación inspirada en Flash Point,
con cavernícolas que rescatan huevos. Python con Mesa 3.5 manejará las reglas
y los agentes; Unity mostrará lo que ocurre en 3D.

## Equipo

- [vicesq17](https://github.com/vicesq17)
- Luis Fernando Tena - [LuisFer753](https://github.com/LuisFer753)

## Estructura

| Carpeta o archivo | ¿Para qué sirve? |
| --- | --- |
| `python/` | Simulación, agentes y comunicación con Unity. |
| `unity/` | Visualización 3D: escenario, cavernícolas y huevos. |
| `docs/` | Acuerdos del equipo y formato de los datos compartidos. |
| `CHANGELOG.md` | Registro de los cambios del proyecto. |
| `.github/PULL_REQUEST_TEMPLATE.md` | Guía breve para solicitar una revisión. |

Cada integrante trabajará en una rama por tarea y abrirá un Pull Request para
revisar e integrar sus cambios. Ver [cómo colaborar](CONTRIBUTING.md).

## Incorporar el avance de Unity

LuisFer753 ya tiene acceso de escritura aceptado (verificado el 2026-11-18).
Puede crear ramas y subir cambios. El flujo del laboratorio se mantiene como
acuerdo del equipo; no hay protecciones de ramas obligatorias configuradas.

La estructura inicial está en el [PR #1](https://github.com/vicesq17/tc2008b-flashpoint-rescue/pull/1),
con destino a `pre-release-0.0.1`; todavía no está integrada en `main`.
Para subir el proyecto existente, seguir la [guía de Unity para Luis](docs/unity-onboarding.md).

- [Documento de avance y créditos de assets (Google Docs)](https://docs.google.com/document/d/1CgF76q8ODBcBNcsgTugBptV36PMenR7l90USv5Lfjoo/edit?usp=sharing).
- [Auditoría frente al Laboratorio 4](docs/repository-audit.md).
- [Conexión futura: Unity cliente y Python servidor](docs/client-server.md).

## Referencias y estado

Se tomó como referencia el **Laboratorio 4 - Estructuración de Proyectos en Unity**,
incluido en el PDF proporcionado para el curso. Se aplican sus recomendaciones
de carpetas, prefabs, ramas y Pull Requests.

Se utilizó **ChatGPT (OpenAI) únicamente como apoyo para crear este repositorio
y preparar su estructura inicial**. La simulación y la visualización se
desarrollarán de manera colaborativa por el equipo.

Esta es la base del repositorio: aún no contiene un proyecto Unity ejecutable
ni un servidor Python implementado. El documento compartido describe un avance
visual que falta incorporar a Git. Más detalles en [documentación y referencias](docs/README.md).
Sin licencia por el momento.
