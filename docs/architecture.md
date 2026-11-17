# Arquitectura preliminar

Proyecto TC2008B: simulación multiagente inspirada en Flash Point, con temática
de cavernícolas rescatando huevos. Las reglas precisas y su adaptación deben
validarse con los requisitos del curso antes de programarse.

```text
Unity 3D -> peticiones HTTP locales -> Python / Mesa 3.5
Unity 3D <- estado JSON por turno   <- modelo y agentes
```

## Responsabilidades

| Parte | Responsabilidad |
| --- | --- |
| Python / Mesa | Modelo, tablero, agentes, reglas, semilla, avance y métricas |
| Adaptador HTTP | Exponer comandos y serializar estados del modelo |
| Unity | Solicitar estados y representar cavernícolas, huevos, entorno y UI |
| docs | Registrar acuerdos, contrato, experimentos y evidencia de validación |

El modelo será la fuente del estado. El adaptador de red se mantendrá separado
de las reglas, para poder probar la simulación sin Unity.

En Unity se propone Data / Domain / Framework / Utils según el Lab 4, con
entidades, servicio de conexión y controlador de visualización del patrón
planteado a partir del Lab 2. Las reglas de rescate permanecen en Python.

## Decisiones pendientes

- Mapa, reglas de riesgo, acciones, victoria/derrota y métricas.
- Estrategias de agentes y semillas para experimentos reproducibles.
- Versión exacta de Unity y pipeline 3D.
- Métodos y rutas HTTP, formato final del estado, manejo de errores y cadencia.
- Evitar avance duplicado por reintentos y actualizaciones fuera de orden.

Primera integración propuesta: un cliente Unity local solicita explícitamente
un avance y recibe un estado completo. Leer un estado no debería avanzar el
modelo; las rutas y métodos se decidirán antes de implementar.

La preparación no incluye hosting, bases de datos externas, telemetría,
automatizaciones de pago ni servicios facturables.
