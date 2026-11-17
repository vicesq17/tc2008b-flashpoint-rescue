# Propuesta de estado JSON

Estado: BORRADOR, sin servidor ni cliente implementados. No es un contrato
oficial del profesor. El equipo debe acordarlo antes de programar la integración.

Ver [ejemplo JSON](examples/game-state.example.json).

| Campo | Tipo propuesto | Significado |
| --- | --- | --- |
| schema_version | string | Versión del formato, inicialmente `0.1` |
| turn | integer | Turno lógico, independiente de los frames de Unity |
| agents | array | Identificador, x e y de cada cavernícola |
| rescued | integer | Huevos rescatados |
| lost | integer | Huevos perdidos |
| damage | integer | Daño acumulado; significado preciso por acordar |
| finished | boolean | Indica si terminó la simulación |

Propuesta de coordenadas: x/y del tablero se representan como x/z en Unity;
origen, escala y orientación quedan por confirmar. Añadir mapa, huevos, riesgos
y eventos al contrato cuando estén definidas sus reglas.

Unity podría usar clases serializables con campos públicos y listas/arreglos,
una entidad `GameState`, `APIHelper` y un controlador de escena. Documentar
cambios incompatibles y probar el mismo ejemplo en ambos lenguajes.

Para la comunicación local, acordar por separado operaciones de reinicio,
avance y consulta. No fijar rutas, frecuencia de peticiones ni política de
reintentos hasta validar cómo se evita avanzar dos veces un mismo turno.
