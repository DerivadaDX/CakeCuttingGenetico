﻿using Common;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace App.Tests
{
    public class ParametrosGeneracionTests : IDisposable
    {
        public void Dispose()
        {
            FileSystemHelperFactory.SetearHelper(null);
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void Constructor_AtomosInvalido_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ParametrosGeneracion(0, 1, 100, "instancia.dat", false));
            Assert.StartsWith("Se requieren al menos 1 átomo", ex.Message);
        }

        [Fact]
        public void Constructor_AgentesInvalido_LanzaArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ParametrosGeneracion(1, 0, 100, "instancia.dat", false));
            Assert.StartsWith("Se requieren al menos 1 agente", ex.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_ValorMaximoInvalido_LanzaArgumentException(int valorMaximo)
        {
            var ex = Assert.Throws<ArgumentException>(() => new ParametrosGeneracion(1, 1, valorMaximo, "instancia.dat", false));
            Assert.StartsWith("El valor máximo debe ser positivo", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_RutaSalidaVacia_LanzaArgumentException(string rutaSalida)
        {
            var ex = Assert.Throws<ArgumentException>(() => new ParametrosGeneracion(1, 1, 100, rutaSalida, false));
            Assert.StartsWith("La ruta no puede estar vacía", ex.Message);
        }

        [Fact]
        public void Constructor_RutaSalidaInvalida_LanzaArgumentException()
        {
            var fileSystemHelper = Substitute.For<FileSystemHelper>();
            fileSystemHelper.GetFullPath("¡ruta-inválida!").Throws(new Exception("La ruta es inválida"));
            FileSystemHelperFactory.SetearHelper(fileSystemHelper);

            var ex = Assert.Throws<ArgumentException>(() => new ParametrosGeneracion(1, 1, 100, "¡ruta-inválida!", false));
            Assert.StartsWith($"Ruta inválida: La ruta es inválida", ex.Message);
        }

        [Fact]
        public void Constructor_DatosValidos_CreaInstanciaCorrectamente()
        {
            var parametros = new ParametrosGeneracion(5, 3, 100, "instancia.dat", true);

            Assert.Equal(5, parametros.Atomos);
            Assert.Equal(3, parametros.Agentes);
            Assert.Equal(100, parametros.ValorMaximo);
            Assert.Equal("instancia.dat", parametros.RutaSalida);
            Assert.True(parametros.ValoracionesDisjuntas);
        }
    }
}
