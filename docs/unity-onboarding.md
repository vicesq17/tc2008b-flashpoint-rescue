# Luis: clonar y subir el avance de Unity

## Acceso y punto de partida

El 2026-11-18 GitHub confirmó que `LuisFer753` es colaborador con permiso
`write` y que no quedan invitaciones pendientes. Puede crear ramas y subir
cambios al repositorio original. No necesita un fork ni una invitación nueva.
Iniciar sesión en GitHub/GitHub Desktop como `LuisFer753`.

El PR #1 contiene la estructura y todavía no está integrado. Hay dos caminos:

1. **Después de revisar e integrar el PR #1:** partir de
   `pre-release-0.0.1`, actualizado con Fetch/Pull, y crear
   `pre-release-0.0.1.2-feature-unity-import`. Abrir el nuevo PR hacia
   `pre-release-0.0.1`.
2. **Para empezar mientras el PR #1 sigue pendiente:** partir de
   `pre-release-0.0.1.1-feature-project-structure`, actualizado con Fetch/Pull,
   y crear `pre-release-0.0.1.2-feature-unity-import`. Abrir inicialmente el PR
   hacia `pre-release-0.0.1.1-feature-project-structure` para mostrar solo el
   avance de Unity. Indicar la dependencia del PR #1. Cuando se integre #1,
   cambiar la base del nuevo PR a `pre-release-0.0.1`, actualizar la rama propia
   y revisar nuevamente el diff; no fusionar el PR de Unity dentro del PR #1.

La segunda opción permite avanzar ahora conservando el `.gitignore` adaptado
para proyectos anidados. `main` aún tiene el `.gitignore` con rutas ancladas a
la raíz: no partir de esa versión para subir Unity dentro de `unity/`.

## Desde GitHub Desktop

1. File > Clone repository > URL:
   `https://github.com/vicesq17/tc2008b-flashpoint-rescue.git`.
   Elegir una carpeta local nueva; no clonar encima del proyecto de Unity
   original ni de otra copia con trabajo sin guardar.
2. En Current branch seleccionar el punto de partida de arriba. Usar Fetch
   origin y Pull origin si aparece; Branch > New branch para la rama propia.
3. Repository > Show in Explorer permite ver la copia clonada. Antes de copiar,
   verificar que el `.gitignore` de esa copia contiene `**/[Ll]ibrary/` y
   `**/[Tt]emp/`.

## Incorporar el proyecto existente sin perder el avance

1. En el proyecto original, guardar todas las escenas y assets. En Edit >
   Project Settings comprobar Version Control > Mode = **Visible Meta Files**
   y Editor > Asset Serialization > Mode = **Force Text**. La ubicación de
   Version Control puede variar con el Editor. Guardar y cerrar Unity.
2. Conservar una copia de respaldo del original fuera del repositorio.
   Leer `ProjectSettings/ProjectVersion.txt`: ambos deben instalar esa versión
   exacta del Editor desde Unity Hub > Installs, con los módulos necesarios.
   Conservar el render pipeline y paquetes del proyecto; no convertirlo ni
   actualizarlo por iniciativa individual al abrirlo.
3. Crear `unity/FlashpointRescue/` dentro de la copia clonada. Copiar desde el
   mismo proyecto original **las tres carpetas completas**, sin mezclar con un
   proyecto vacío:

   ```text
   unity/FlashpointRescue/
     Assets/                 # Escenas, scripts, prefabs y recursos con sus .meta
     Packages/               # manifest.json, packages-lock.json y paquetes locales necesarios
     ProjectSettings/        # ProjectVersion.txt y configuración compartida
   ```

   Incluir todos los `.meta` que acompañen los assets y las carpetas dentro de
   `Assets`. No regenerarlos ni sustituirlos: contienen los identificadores que
   preservan referencias de escenas, materiales y prefabs. Si hay paquetes con
   rutas locales externas en `manifest.json`, hacerlos reproducibles con el
   equipo antes de publicar; no subir rutas personales ni credenciales.
4. No copiar `.git` del original, `Library`, `Temp`, `Obj`, `Logs`, `Build`,
   `Builds`, `UserSettings`, cachés del editor, entornos Python ni archivos
   privados. No sustituir el proyecto por un `.unitypackage` o un ZIP.
5. En Unity Hub > Projects > Add > **Add project from disk** (o Add), seleccionar
   `unity/FlashpointRescue/`, la carpeta que contiene las tres anteriores.
   Elegir la versión exacta; esperar la importación. `Library` se regenerará
   localmente y debe seguir fuera de Git.
6. Abrir la escena de entrada desde `Assets/Scenes` o su ubicación real,
   comprobar materiales, prefabs, scripts y Play Mode. Registrar en `unity/README.md`
   la versión exacta y la ruta de esa escena. Todavía no hay una escena de
   entrada identificada en este repositorio.
7. Guardar y cerrar Unity. En Changes de GitHub Desktop verificar que se incluyen
   `Assets`, `.meta`, `Packages/manifest.json`, `Packages/packages-lock.json`
   (si el proyecto lo genera), `ProjectSettings/ProjectVersion.txt` y el resto
   de ajustes compartidos; comprobar que no hay `Library` ni `Temp`.
8. Revisar el tamaño de los recursos y los derechos de redistribución antes de
   subirlos al repositorio público. Mantener los créditos y archivos de licencia
   que correspondan; el Google Doc contiene la referencia del equipo.
9. Actualizar `CHANGELOG.md` en la versión sin publicar. Commit con descripción
   del avance, Publish branch o Push origin. En GitHub abrir **Compare & pull
   request**, verificar base/compare según el camino elegido, describir cómo
   abrirlo y probarlo, y solicitar la revisión del otro integrante.

Si GitHub rechaza un archivo grande, revisar los límites actuales de archivos y
Git LFS antes de reintentar; el repositorio no tiene LFS configurado. No añadir
LFS a archivos ya publicados ni reescribir el historial sin acordarlo.

## Evitar conflictos de escenas

El Lab 4 propone un responsable de integrar la escena y trabajo separado en
prefabs. Para cada tarea, anotar en su PR:

| Elemento | Acuerdo necesario |
| --- | --- |
| Escena compartida | Ruta `.unity` y un integrante que integre esa tarea. |
| Prefab de escenario, agentes u objetos | Ruta y persona que lo editará en Prefab Mode. |
| Cámara, luces y jerarquía | Coordinar con el responsable de la escena; también cambian el `.unity`. |
| Prueba de integración | El otro integrante abre el proyecto y comprueba referencias y Play Mode. |

Luis puede proponer la escena inicial al subir su avance; ambos confirman en el
PR quién integra cada tarea. Esta coordinación no cambia sus permisos de GitHub.
No editar simultáneamente el mismo prefab. Mover/renombrar assets desde Unity
con sus `.meta`. Guardar el trabajo antes de actualizar Git y cerrar Unity antes
de cambiar ramas. Un prefab reduce conflictos; no elimina los de escenas o
prefabs compartidos. No borrar contenido del avance existente para imitar los
cubos de demostración del laboratorio.

## Comprobación por la otra persona

Clonar en una carpeta nueva, seleccionar la rama de Luis, añadir el proyecto en
Unity Hub e instalar su versión exacta. Debe importar sin depender de `Library`
copiada, archivos fuera del repositorio o rutas personales. Abrir la escena
indicada, revisar la consola, ejecutar Play Mode y dejar el resultado en la
revisión del PR. Hasta hacer esta prueba no se considera comprobado el proyecto
completo ni la conexión con Python.
