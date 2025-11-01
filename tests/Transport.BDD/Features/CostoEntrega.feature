# language: es
Característica: Costo de entrega por tipo de transporte
  Para calcular costos de envío
  Como planificador logístico
  Quiero conocer el costo por distancia según el transporte

  Esquema del escenario: Calcular costo directo por tipo
    Dado un transporte "<tipo>"
    Cuando calculo el costo para <distancia> millas
    Entonces el costo debe ser <costo>

    Ejemplos:
      | tipo    | distancia | costo |
      | Airbus  | 10        | 30    |
      | Truck   | 20        | 20    |
      | Ship    | 20        | 10    |

  Esquema del escenario: Calcular costo usando fábrica
    Dado una fábrica de transporte "<factory>"
    Cuando creo el transporte y calculo el costo para <distancia> millas
    Entonces el costo debe ser <costo>

    Ejemplos:
      | factory       | distancia | costo |
      | TruckFactory  | 20        | 20    |
      | ShipFactory   | 20        | 10    |

