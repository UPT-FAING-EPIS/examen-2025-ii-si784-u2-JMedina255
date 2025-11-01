[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/bTwXPjqC)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411429)

Proyecto con ejemplo mínimo para prácticas de Calidad y Pruebas (.NET 8):

- xUnit con cobertura (coverlet)
- BDD con SpecFlow + LivingDoc
- UI E2E con Playwright (.NET) en Chromium y Firefox
- GitHub Actions para ejecutar pruebas y publicar reportes en GitHub Pages
  - Gate de cobertura: CI falla si cobertura < 80% en `App.Core`

Requisitos locales:
- .NET SDK 8.0
- (Opcional) SpecFlow LivingDoc CLI: `dotnet tool update -g SpecFlow.Plus.LivingDoc.CLI`
- (Opcional) ReportGenerator: `dotnet tool update -g dotnet-reportgenerator-globaltool`

Comandos básicos:
- Ejecutar unit tests con cobertura: `dotnet test tests/App.UnitTests/App.UnitTests.csproj --collect:"XPlat Code Coverage"`
  - Gate local opcional (mismo que CI): `dotnet test tests/App.UnitTests/App.UnitTests.csproj -c Release /p:CollectCoverage=true /p:CoverletOutput=TestResults/coverage/ /p:CoverletOutputFormat="cobertura" /p:Threshold=80 /p:ThresholdType=line /p:Include="[App.Core]*"`
- Ejecutar BDD: `dotnet test tests/App.BDD/App.BDD.csproj`
- Generar LivingDoc (tras ejecutar BDD): `livingdoc test-assembly tests/App.BDD/bin/Release/net8.0/App.BDD.dll -t $(Get-ChildItem -Recurse tests/App.BDD -Filter TestExecution.json | Select-Object -First 1).FullName -o docs/bdd`
- Levantar la web local: `dotnet run --project src/App.Web/App.Web.csproj --urls http://localhost:5187`
- Ejecutar UI tests (en otra terminal): `set BROWSER=chromium && dotnet test tests/App.UI/App.UI.csproj`

GitHub Actions:
- `CI - Unit, BDD, Pages`: ejecuta unit/BDD, genera reportes y publica en Pages (carpeta docs)
- `UI - Playwright (2 browsers)`: ejecuta E2E en Chromium y Firefox
