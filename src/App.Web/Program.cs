using App.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var html = @"<!doctype html>
<html lang='es'>
<head>
  <meta charset='utf-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <title>Demo Calculadora</title>
  <style>body{font-family:sans-serif;margin:2rem}input{width:6rem;margin-right:.5rem}</style>
  </head>
<body>
  <h1>Calculadora (Demo)</h1>
  <div>
    <input id='a' type='number' placeholder='a' />
    <input id='b' type='number' placeholder='b' />
    <button id='sumButton'>Sumar</button>
  </div>
  <p id='result'></p>
  <script>
    const $ = s => document.querySelector(s);
    $('#sumButton').addEventListener('click', async () => {
      const a = $('#a').value || 0;
      const b = $('#b').value || 0;
      const res = await fetch(`/calc/sum?a=${a}&b=${b}`);
      const data = await res.json();
      $('#result').textContent = `Resultado: ${data.result}`;
    });
  </script>
</body>
</html>";
    await context.Response.WriteAsync(html);
});

app.MapGet("/calc/sum", (int a, int b) => Results.Json(new { result = new Calculator().Add(a, b) }));
app.MapGet("/calc/sub", (int a, int b) => Results.Json(new { result = new Calculator().Subtract(a, b) }));
app.MapGet("/calc/mul", (int a, int b) => Results.Json(new { result = new Calculator().Multiply(a, b) }));
app.MapGet("/calc/div", (int a, int b) =>
{
    try
    {
        var value = new Calculator().Divide(a, b);
        return Results.Json(new { result = value });
    }
    catch (DivideByZeroException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();

