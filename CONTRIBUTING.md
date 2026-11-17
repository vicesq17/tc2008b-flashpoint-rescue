# Cómo colaborar

El proyecto se trabaja entre `vicesq17` y Luis Fernando Tena (`LuisFer753`).

## Ramas y revisiones

1. Partir de `pre-release-0.0.1`, la rama de integración de esta iteración.
2. Crear una rama por tarea, por ejemplo `pre-release-0.0.1.2-feature-mesa-model`.
3. Hacer cambios pequeños y registrar los relevantes en `CHANGELOG.md`.
4. Actualizar la rama con los cambios de integración y abrir un PR hacia
   `pre-release-0.0.1` para que el otro integrante lo revise.
5. Cuando la iteración esté probada, integrar `pre-release-0.0.1` en `main`
   mediante otro PR. `main` conserva las versiones estables.

Este flujo se toma como referencia del Laboratorio 4.

## Trabajo en Unity

- Acordar quién integra la escena y qué prefab trabaja cada integrante.
- Editar los prefabs por separado para evitar cambios simultáneos a la escena.
- Usar la misma versión de Unity y conservar los archivos `.meta`.
- Versionar `Assets/`, `Packages/` y `ProjectSettings/`; excluir cachés y builds.

El material del profesor se consulta como referencia y no se modifica.
