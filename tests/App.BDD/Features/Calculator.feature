# language: es
Característica: Calculadora
  Para evitar errores al calcular
  Como usuario
  Quiero sumar y dividir números

  Escenario: Sumar dos números
    Dado que ingreso 2 y 3
    Cuando realizo la suma
    Entonces el resultado debe ser 5

  Escenario: Dividir por cero
    Dado que ingreso 4 y 0
    Cuando realizo la división
    Entonces debería ocurrir un error de división por cero

