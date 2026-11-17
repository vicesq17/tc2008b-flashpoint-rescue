# Simulación Python / Mesa

Python contiene las reglas, decisiones de los agentes y estado de la simulación.
Unity consume ese estado para visualizarlo. Esta carpeta es una base de trabajo;
todavía no contiene una simulación ni un servidor ejecutables.

## Entorno local

Usar Python 3.12 o superior. Mesa 3.5.0 requiere Python >=3.12:
https://pypi.org/project/Mesa/3.5.0/

Desde la raíz del repositorio, en PowerShell:

```powershell
python -m venv .venv
.\.venv\Scripts\python.exe -m pip install -r python/requirements.txt
.\.venv\Scripts\python.exe -c "import mesa; print(mesa.__version__)"
```

No es necesario activar el entorno ni cambiar las políticas de PowerShell.
Las dependencias aún no están instaladas como parte de esta preparación.

## Organización prevista

- `src/flashpoint_rescue/model/`: tablero, reglas y avance por turnos.
- `src/flashpoint_rescue/agents/`: cavernícolas y estrategias de rescate.
- `src/flashpoint_rescue/api/`: adaptación HTTP/JSON, por definir.
- `tests/`: futuras pruebas de reglas y contrato, todavía sin implementar.

Próximo paso: acordar las reglas del escenario y una primera prueba del modelo
antes de implementar la API. El ejemplo JSON de `docs/` es una propuesta.
