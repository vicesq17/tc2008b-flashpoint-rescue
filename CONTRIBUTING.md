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

LuisFer753 tiene permiso `write` aceptado: puede crear ramas y subir cambios sin
pedir una nueva invitación. No se han añadido bloqueos de ramas ni revisores
obligatorios en GitHub. Las revisiones descritas aquí son el acuerdo recomendado
del equipo para seguir el laboratorio. `main` se reserva para versiones estables.

Mientras el PR #1 siga pendiente, consultar las dos opciones de punto de partida
en la [guía para Luis](docs/unity-onboarding.md). No asumir que `main` o
`pre-release-0.0.1` ya contienen la estructura de ese PR.

## Trabajo en Unity

- Acordar quién integra la escena y qué prefab trabaja cada integrante.
- Editar los prefabs por separado para evitar cambios simultáneos a la escena.
- Usar la misma versión de Unity y conservar los archivos `.meta`.
- Versionar `Assets/`, `Packages/` y `ProjectSettings/`; excluir cachés y builds.
- Registrar en cada PR las escenas y prefabs que se tocarán y quién integrará la
  escena compartida. Esta responsabilidad se coordina por tarea, sin limitar el
  permiso de escritura de ninguno de los dos.
- Editar los prefabs en Prefab Mode; guardar la escena únicamente cuando la tarea
  incluya cambios de cámara, luces, jerarquía o integración acordados.
- Cerrar Unity antes de cambiar de rama o actualizar archivos del proyecto.
- Mover y renombrar assets desde Unity para conservar sus `.meta` y referencias.

Ver [incorporación y comprobaciones de Unity](docs/unity-onboarding.md) y el
[plan de conexión cliente/servidor](docs/client-server.md).

## Resolver diferencias

Actualizar la rama propia con la rama destino antes de solicitar revisión. Ante
un conflicto, conservar las entradas de ambos en `CHANGELOG.md`. Para escenas,
prefabs y `.meta`, coordinar con quien integra: no elegir una versión completa
sin revisar ni regenerar GUID para resolver el conflicto. Abrir el proyecto y
comprobar las referencias después de resolverlo. No usar force push sobre ramas
compartidas. Tags y releases se preparan al cerrar una iteración probada.

El material del profesor se consulta como referencia y no se modifica.
