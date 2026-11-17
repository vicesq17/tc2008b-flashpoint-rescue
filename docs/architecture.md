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

Falta acordar las reglas y el mapa, la versión de Unity y los detalles de la
comunicación antes de implementar. Ver [propuesta JSON](json-contract.md).
