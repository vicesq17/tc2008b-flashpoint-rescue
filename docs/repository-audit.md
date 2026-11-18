# Auditoría de colaboración - 2026-11-18

## Alcance y evidencia

Repositorio público `vicesq17/tc2008b-flashpoint-rescue`, rama predeterminada
`main`. Se consultaron las ramas remotas, el árbol versionado, el PR #1, sus
revisiones, colaboradores, invitaciones, protecciones clásicas y rulesets con
la API autenticada de GitHub, además de la interfaz del repositorio.

Referencia estricta de organización: **Laboratorio 4 - Estructuración de Proyectos
en Unity**, PDF adjunto `Grupos _ Plataforma académica(20261118-184802).pdf`
(66 páginas). Se leyó el texto completo y se revisaron las figuras de jerarquía,
carpetas y arquitectura en las páginas 5, 6 y 8. El PDF del profesor no se publica.
También se consultó el [Lab 2](https://groups.meeplab.com/contenidos/tc2008b/intro-unity/api-calls-unity)
para planear la conexión cliente/servidor.

El [Google Doc del avance](https://docs.google.com/document/d/1CgF76q8ODBcBNcsgTugBptV36PMenR7l90USv5Lfjoo/edit?usp=sharing)
se pudo leer con el acceso conectado. Se enlaza desde README y docs sin copiarlo
ni cambiar sus permisos. Esta lectura no demuestra que cualquier visitante o
Luis pueda abrirlo: Luis debe comprobarlo con su propia cuenta.

## Estado comprobado antes de esta actualización

| Elemento | Resultado |
| --- | --- |
| `main` | `58af8df`: solo README y `.gitignore`; sin proyecto Unity. |
| `pre-release-0.0.1` | También `58af8df`; rama de integración creada, sin integrar la estructura. |
| `pre-release-0.0.1.1-feature-project-structure` | `221c4d3`, dos commits sobre integración; estructura inicial de 18 archivos. |
| PR #1 | Único PR; abierto hacia `pre-release-0.0.1`, sin fusionar, cero revisiones y cero checks; la interfaz indicaba ausencia de conflictos. |
| `LuisFer753` | Colaborador aceptado, rol `write`, `push=true`, `admin=false`, `maintain=false`. |
| Invitaciones | Lista vacía; no hay invitación pendiente a Luis. Su estado aceptado se confirma también con su rol de colaborador. |
| Propietario | `vicesq17`, acceso administrador del repositorio. |
| Protecciones | `main` e integración sin protección clásica; lista de rulesets vacía. |
| Configuración adicional | Auto-merge desactivado; no se configuró Git LFS. |

Estos identificadores describen la fotografía inicial; la actualización de esta
documentación añade un commit a la misma rama del PR #1. No se han hecho merges
ni cambios al contenido de `main` o a la rama de integración.

## Contraste con el Lab 4

| Referencia del PDF | Comprobación y resultado |
| --- | --- |
| Paso 1, pp. 1-3: repositorio e ignore de Unity | Existe. En `main`, las exclusiones `/[Ll]ibrary/` y similares solo cubren la raíz. La rama del PR #1 ya usa `**/[Ll]ibrary/`, `**/[Tt]emp/`, etc., que cubren `unity/FlashpointRescue/`. Importante usar esa versión antes de subir Unity. |
| Paso 2, pp. 4-6: Managers, Setup, Environment, Canvases, Systems | Documentado en `unity/README.md`; no hay escena versionada para verificar la jerarquía real. |
| Assets y arquitectura, pp. 6-9 | Carpetas y capas Data/Domain/Framework/Utils documentadas. No existen aún en un proyecto Unity versionado; son preparación, no cumplimiento ejecutable. |
| Prefabs y conflictos, pp. 9-23 | Se añadió guía de Prefab Mode, responsable por escena/tarea y prueba en otra copia. Faltan escenas, prefabs y la prueba real entre ambos integrantes. |
| CHANGELOG, pp. 23-25 y 31-32 | Existe en la rama del PR; se organizaron categorías, fechas de cambios y versión `UNRELEASED`. |
| GitFlow, pp. 26-27 y 30-40 | Ramas main, integración y tarea creadas; PR #1 con base correcta. Se documentó cómo puede empezar Luis mientras #1 sigue pendiente. |
| Plantilla PR, pp. 28-29 y 41-43 | Existe en la rama del PR. Se amplió con tipo de cambio, pruebas, impacto, capturas y checklist Unity. No está aún en la rama predeterminada: si GitHub no la precarga, copiarla manualmente al abrir el PR. |
| Integración, pp. 43-58 | Pendiente de revisión humana y prueba de Unity. No se siguieron los merges de demostración: no se autorizó integrar prematuramente. |
| Tags y release, pp. 59-63 | Pendientes de una versión estable probada; no se publicó una release. |

Las carpetas `/unity`, `/python` y `/docs` separan los dos componentes y la
documentación de este proyecto. Son una adaptación del equipo: el laboratorio
no exige literalmente ese monorepositorio. Los nombres y organización pueden
acordarse, como permite el propio material en la página 9.

## Acceso de Luis y configuración elegida

El permiso actual de escritura le permite trabajar en el repositorio, crear
ramas y enviar sus cambios. No se cambiaron permisos, visibilidad ni credenciales,
ni se enviaron invitaciones duplicadas. No se añadieron restricciones obligatorias:
el propietario pidió conservar libertad de trabajo para Luis. El flujo de PR
se mantiene como acuerdo de colaboración del Lab 4.

Las ramas siguen técnicamente abiertas a cambios directos. Si el equipo decide
protegerlas después, una opción reversible para `main` y `pre-release-0.0.1` es:

- Require a pull request before merging, con **1** aprobación del otro integrante.
- Descartar aprobaciones obsoletas al añadir commits y resolver conversaciones.
- Incluir a administradores; no permitir force pushes ni borrados.
- No exigir checks inexistentes ni dos aprobaciones en un equipo de dos.

Esta opción **no se aplicó**. El propietario puede revisarla en Settings >
Branches > Add classic branch protection rule. La pantalla de colaboradores
pidió confirmar identidad; la API con el acceso de Git existente permitió
verificar los roles sin introducir nuevas credenciales. No queda un bloqueo de
permisos que impida a Luis subir su trabajo.

## Ajustes de esta rama y pendientes reales

Se enlazó el avance de Google Docs; se corrigió la instrucción de crear un proyecto
nuevo para partir del avance ya existente; se detallaron importación completa,
Editor, `.meta`, prefabs y revisión; se amplió plantilla PR y CHANGELOG; y se
documentó el plan de API sin inventar endpoints implementados. El `.gitignore`
ya adaptado se conserva y se explica su alcance anidado.

Falta que Luis publique el proyecto Unity original con `Assets`, `Packages` y
`ProjectSettings`. Hasta entonces no se puede verificar `ProjectVersion.txt`,
Visible Meta Files, Force Text, pipeline, dependencias, GUID, referencias,
propietarios reales de escenas ni reproducibilidad en otra computadora. Python
contiene estructura y requisitos, sin modelo/servidor ejecutable. La conexión
HTTP/JSON sigue pendiente; ver [plan](client-server.md).

Orden recomendado: revisar PR #1; importar el avance con la [guía para Luis](unity-onboarding.md)
(puede empezar antes usando la opción dependiente); comprobar Unity en ambas
máquinas; cerrar el contrato JSON; implementar servidor y cliente en sus ramas;
y solo después integrar una versión estable y preparar tag/release.

## Fuentes de apoyo

Validación de esta actualización: 46 rutas de Unity comprobadas con
`git check-ignore` tanto en la raíz como en `unity/FlashpointRescue/`, incluyendo
la conservación de `.meta` normales, `Packages` y `ProjectSettings`; enlaces
relativos de Markdown resueltos; JSON de ejemplo válido; ausencia de carpetas
generadas y copias PDF en el árbol versionado; y `git diff --check` sin errores.
Esto comprueba la preparación del repositorio, no sustituye la prueba del
proyecto Unity que todavía falta subir.

- [Laboratorio 4](https://groups.meeplab.com/contenidos/tc2008b/intro-unity/project-structure).
- [Unity: control de versiones externo](https://docs.unity3d.com/Manual/ExternalVersionControlSystemSupport.html).
- [GitHub: colaboradores](https://docs.github.com/en/rest/collaborators/collaborators).
- [GitHub: ramas protegidas](https://docs.github.com/en/rest/branches/branch-protection).

La fuente normativa de la organización de este curso es el PDF adjunto. Las
fuentes oficiales anteriores complementan las comprobaciones técnicas.
