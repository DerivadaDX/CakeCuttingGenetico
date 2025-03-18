# Cake Cutting Gen�tico

## Descripci�n

Este proyecto implementa un algoritmo basado en t�cnicas gen�ticas para la divisi�n justa de una torta discreta (discrete
cake-cutting) entre m�ltiples jugadores, con el objetivo de lograr una distribuci�n libre de envidia (envy-free).
Se basa en la teor�a presentada en el art�culo _Envy-free division of discrete cakes_ de Javier Marenco y Tom�s Tetzlaff.

## Contexto

El problema de divisi�n del pastel es un problema de asignaci�n justa en el que un recurso discreto debe ser distribuido
entre varios jugadores, quienes tienen valoraciones diferentes para cada parte del recurso. El pastel est� compuesto por
�tomos indivisibles que son valorados de manera distinta por cada jugador.

Las valoraciones de cada jugador sobre los �tomos deben sumar 1 (100%), representando el valor total que asignan al
pastel completo.

El objetivo es lograr una asignaci�n que satisfaga la propiedad de **libre de envidia** (envy-freeness), lo que
significa que ning�n jugador prefiere la porci�n de otro jugador por encima de la suya.

## Referencias

- Marenco, J., & Tetzlaff, T. (2013). _Envy-free division of discrete cakes_. Discrete Applied Mathematics, 163(Part 2),
  233-244. [DOI: 10.1016/j.dam.2013.06.032](https://doi.org/10.1016/j.dam.2013.06.032)
