# Datos compartidos con JSON

Esta es una propuesta inicial; el equipo debe acordarla antes de implementar.
Ver el [ejemplo de estado](examples/game-state.example.json).

| Dato | Significado |
| --- | --- |
| `schema_version` | Versión del formato. |
| `turn` | Turno de la simulación. |
| `agents` | Identificador y posición de cada cavernícola. |
| `rescued` / `lost` | Huevos rescatados y perdidos. |
| `damage` | Daño acumulado, pendiente de precisar en las reglas. |
| `finished` | Si la simulación terminó. |

Todavía falta describir el mapa, los huevos y los riesgos, además de acordar
las coordenadas y cómo solicitar cada avance sin repetir un turno por error.
