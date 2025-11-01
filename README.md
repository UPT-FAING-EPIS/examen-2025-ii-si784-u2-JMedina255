[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/bTwXPjqC)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411429)

Laboratorio: Patrón Factory Method (Transport)

- App .NET 8 con librería `Transport.Core` que define `ITransport`, `Airbus`, `Truck`, `Ship`, y fábricas `TruckFactory`, `ShipFactory`.
- Pruebas unitarias con xUnit (80%+ cobertura, gate activado en CI) en `Transport.UnitTests`.
- BDD con SpecFlow + LivingDoc en `Transport.BDD`.
- GitHub Actions: ejecuta unit/BDD, genera reportes de cobertura (HTML) y LivingDoc y los publica en GitHub Pages.

Estructura
- `src/Transport.Core`: código de dominio (interfaces, clases y fábricas)
- `tests/Transport.UnitTests`: xUnit + coverlet.msbuild (umbral 80%)
- `tests/Transport.BDD`: Features y StepDefinitions (es-ES)
- `.github/workflows/ci.yml`: pipeline de pruebas + Pages
- `docs/`: carpeta donde se publican reportes

Comandos locales (PowerShell)
- Restaurar/compilar solución: `dotnet restore .\examen-2025-ii-si784-u2-JMedina255.sln` y `dotnet build .\examen-2025-ii-si784-u2-JMedina255.sln -c Release`
- Unit (con gate 80%): `dotnet test .\tests\Transport.UnitTests\Transport.UnitTests.csproj -c Release /p:CollectCoverage=true /p:CoverletOutput=TestResults/coverage/ /p:CoverletOutputFormat="cobertura" /p:Threshold=80 /p:ThresholdType=line /p:Include="[Transport.Core]*"`
- BDD: `dotnet test .\tests\Transport.BDD\Transport.BDD.csproj -c Release`
- Reporte HTML (opcional local):
  - `dotnet tool update -g dotnet-reportgenerator-globaltool`
  - `reportgenerator -reports:"**\TestResults\*\coverage.cobertura.xml" -targetdir:"docs\coverage" -reporttypes:"HtmlInline_AzurePipelines;Cobertura"`
- LivingDoc (opcional local):
  - `dotnet tool update -g SpecFlow.Plus.LivingDoc.CLI`
  - `$dll = Resolve-Path .\tests\Transport.BDD\bin\Release\net8.0\Transport.BDD.dll`
  - `$json = Get-ChildItem -Recurse .\tests\Transport.BDD -Filter TestExecution.json | Select-Object -First 1 -ExpandProperty FullName`
  - `livingdoc test-assembly $dll -t $json -o .\docs\bdd`

CI/CD (GitHub Actions)
- Workflow `CI - Unit, BDD, Pages (Transport)` compila, ejecuta unit/BDD, aplica gate 80%, genera reportes y publica GitHub Pages.
- Habilitar Pages: Settings → Pages → Build and deployment = GitHub Actions.

Respuesta (Pregunta 2)
- Se usa Factory Method para desacoplar la creación del transporte (p. ej., `TruckFactory`, `ShipFactory`).
- `GetDeliveryCost(distance)` implementa el costo por milla: Airbus 3.00, Truck 1.00, Ship 0.50.
- Cobertura mínima 80% garantizada por pruebas unitarias (además del gate en CI).
- BDD describe escenarios de negocio para cada transporte y para la creación vía fábrica, con LivingDoc publicado en Pages.

