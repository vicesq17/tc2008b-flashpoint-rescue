# Arquitectura

La simulación estará separada de su representación en pantalla.

| Componente | Responsabilidad |
| --- | --- |
| Python / Mesa 3.5 | Aplicar las reglas, mover a los agentes y registrar el resultado de cada turno. |
| Comunicación HTTP / JSON | Compartir el estado entre Python y Unity en la computadora local. |
| Unity 3D | Mostrar el escenario, los cavernícolas, los huevos y los indicadores. |

Unity solicitará una actualización; Python responderá con el estado en JSON
y Unity actualizará la escena. Las reglas del rescate se mantendrán en Python.

En Unity se tomarán como referencia las carpetas `Data`, `Domain`, `Framework`
y `Utils` del Laboratorio 4. Los objetos se organizarán en prefabs para que
cada integrante pueda trabajar su parte.

El [documento de avance](https://docs.google.com/document/d/1CgF76q8ODBcBNcsgTugBptV36PMenR7l90USv5Lfjoo/edit?usp=sharing)
contiene las decisiones y propuestas actuales del juego. La versión exacta de
Unity debe tomarse del `ProjectSettings/ProjectVersion.txt` del proyecto que se
incorpore. Falta validar el mapa y las reglas en código y cerrar el contrato de
comunicación. Ver [propuesta JSON](json-contract.md) y [plan cliente/servidor](client-server.md).
