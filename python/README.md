# Python / Mesa

Aquí se desarrollará la simulación con Mesa 3.5.0. Aún no hay modelo ni servidor
ejecutables.

- `src/flashpoint_rescue/model/`: tablero, reglas y turnos.
- `src/flashpoint_rescue/agents/`: cavernícolas y sus decisiones.
- `src/flashpoint_rescue/api/`: comunicación con Unity.
- `tests/`: pruebas del modelo y de los datos compartidos.

## Preparar el entorno

Usar Python 3.12 o superior. Desde la raíz del repositorio, en PowerShell:

```powershell
python -m venv .venv
.\.venv\Scripts\python.exe -m pip install -r python/requirements.txt
```

Versión y requisitos de referencia: [Mesa 3.5.0](https://pypi.org/project/Mesa/3.5.0/).
