# Colaboración

## Flujo del Laboratorio 4

1. `main` conserva la base estable; no trabajar directamente aquí.
2. `pre-release-0.0.1` integra la primera iteración.
3. Crear desde esa rama una rama corta por funcionalidad, por ejemplo
   `pre-release-0.0.1.2-feature-mesa-model` o
   `pre-release-0.0.1.3-feature-unity-prefabs`.
4. Hacer commits pequeños, actualizar `CHANGELOG.md` y sincronizar con la rama
   de integración antes de abrir el PR.
5. Abrir PR de la rama feature hacia `pre-release-0.0.1`. Verificar la dirección,
   describir cambios y pruebas, y pedir revisión al otro integrante.
6. Tras integrar y validar la iteración, abrir PR de `pre-release-0.0.1` hacia
   `main`. La fecha de release y la etiqueta se agregan al liberar una versión.

La estructura inicial se propone en
`pre-release-0.0.1.1-feature-project-structure`. No es una versión liberada.
No marcar una revisión de otra persona como realizada si sigue pendiente.

## Unity

- Acordar quién integra la escena principal en cada iteración.
- Repartir prefabs (cavernícolas, huevos y entorno) por tarea, sin asignar
  integrantes hasta acordarlo juntos.
- Editar cada prefab en Prefab Mode para reducir cambios a la escena compartida.
- Usar la misma versión del Editor; registrarla cuando se cree el proyecto real.
- Configurar Visible Meta Files y Force Text en el proyecto nuevo. Versionar
  `Assets/` con sus `.meta`, `Packages/` y `ProjectSettings/`.
- Evitar editar a la vez la misma escena o prefab y no resolver conflictos
  borrando archivos `.meta`. No subir cachés ni builds.

## Incorporación del compañero

Pendiente: el usuario debe proporcionar su nombre de usuario de GitHub.
Después se podrá enviar una invitación al repositorio privado. No se ha enviado
ninguna invitación ni se ha supuesto una identidad.

## Alcance

Trabajar únicamente en este repositorio nuevo. Consultar los laboratorios como
referencia sin modificar ni subir los originales del profesor. Mantener la
simulación y la comunicación en local; cualquier servicio de pago queda fuera
del proyecto preliminar.
