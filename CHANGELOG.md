## [v1.0.0-beta.1](https://github.com/DerivadaDX/CakeCuttingGenetico/compare/v0.0.0...v1.0.0-beta.1) (2025-03-28)

### Breaking Changes

* **instancia-builder:** se modific� para usar matrices rectangulares en vez de escalonadas
* **generador-instancia:** se renombr� el proyecto y cambi� de consola a librer�a
* **instancia-problema:** se invirti� el orden esperado en la matriz de valoraciones

### Features

* **app:** implementaci�n de CLI para generar y exportar instancias del problema
* **instancia-builder:** implementaci�n inicial del builder de instancias
* **individuo:** clase base para individuos y definici�n de cromosomas
* **random:** se removi� `IGeneradorNumerosRandom` y se implement� factory
* **solver:** clases b�sicas: `�tomo`, `Jugador`, `InstanciaProblema`
* **solver:** generador de n�meros aleatorios con tests
* **common:** `FileSystemHelper` para interacci�n con el sistema de archivos

### Refactors

* **instancia-problema:** se elimin� la condici�n de valoraciones disjuntas
* **atomo:** se elimin� la restricci�n de valoraci�n dentro del rango [0,1]

### Chores

* **dotnet:** configuraci�n inicial de la soluci�n y CI/CD
