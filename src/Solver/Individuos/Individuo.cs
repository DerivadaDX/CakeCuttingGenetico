﻿using Solver.Fitness;

namespace Solver.Individuos
{
    internal abstract class Individuo
    {
        protected readonly List<int> _cromosoma;
        protected readonly InstanciaProblema _problema;

        protected Individuo(List<int> cromosoma, InstanciaProblema problema)
        {
            _cromosoma = cromosoma ?? throw new ArgumentException("El cromosoma no puede ser null", nameof(cromosoma));
            _problema = problema ?? throw new ArgumentException("La instancia del problema no puede ser null", nameof(problema));

            if (cromosoma.Count == 0)
                throw new ArgumentException("El cromosoma no puede estar vacío");

            ValidarCromosoma(cromosoma, problema);
        }

        public int Fitness { get; protected set; }

        internal abstract void Mutar();
        internal abstract Individuo Cruzar(Individuo otro);
        internal abstract void CalcularFitness(ICalculadoraFitness calculadoraFitness);

        private void ValidarCromosoma(List<int> cromosoma, InstanciaProblema problema)
        {
            int cantidadJugadores = problema.Jugadores.Count;
            int cantidadCortesEsperada = cantidadJugadores - 1;

            ValidarCantidadGenes(cromosoma, cantidadJugadores);
            ValidarCortes(cromosoma, problema, cantidadCortesEsperada);
            ValidarAsignaciones(cromosoma, cantidadJugadores, cantidadCortesEsperada);
        }

        private void ValidarCantidadGenes(List<int> cromosoma, int cantidadJugadores)
        {
            int cantidadCortesEsperada = cantidadJugadores - 1;
            int cantidadGenesEsperada = cantidadCortesEsperada + cantidadJugadores;

            if (cromosoma.Count != cantidadGenesEsperada)
            {
                string mensaje = $"Cantidad de genes inválida. Esperada: {cantidadGenesEsperada}, recibida: {cromosoma.Count}";
                throw new ArgumentException(mensaje, nameof(cromosoma));
            }
        }

        private void ValidarCortes(List<int> cromosoma, InstanciaProblema problema, int cantidadCortesEsperada)
        {
            List<int> cortes = [.. cromosoma.Take(cantidadCortesEsperada).Order()];
            if (cortes.First() < 0)
            {
                string mensaje = $"Posición del primer corte no puede ser negativa: {cortes.First()}";
                throw new ArgumentException(mensaje, nameof(cromosoma));
            }

            if (cortes.Last() > problema.CantidadAtomos)
            {
                string mensaje = $"Posición del último corte no puede superar a {problema.CantidadAtomos}: {cortes.Last()}";
                throw new ArgumentException(mensaje, nameof(cromosoma));
            }
        }

        private void ValidarAsignaciones(List<int> cromosoma, int cantidadJugadores, int cantidadCortesEsperada)
        {
            List<int> asignaciones = [.. cromosoma.Skip(cantidadCortesEsperada)];
            List<int> fueraDeRango = [.. asignaciones.Where(a => a < 1 || a > cantidadJugadores).Distinct().Order()];
            if (fueraDeRango.Count > 0)
            {
                string mensaje = $"Hay asignaciones fuera del rango [1, {cantidadJugadores}]: ({string.Join(", ", fueraDeRango)})";
                throw new ArgumentException(mensaje, nameof(cromosoma));
            }

            List<int> repetidas = asignaciones.GroupBy(a => a).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (repetidas.Count > 0)
            {
                string mensaje = $"Hay porciones asignadas a más de un jugador: ({string.Join(", ", repetidas)})";
                throw new ArgumentException(mensaje, nameof(cromosoma));
            }
        }
    }
}
