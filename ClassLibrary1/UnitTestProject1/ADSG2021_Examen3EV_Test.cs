using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen3EV_NS;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ADSG2021_Examen3EV_Test
    {
        [TestMethod]
        public void PruebaNotasCorrectas()
        {
            List<int> notas = new List<int>();

            notas.Add(0);
            notas.Add(5);
            notas.Add(9);
            notas.Add(3);
            notas.Add(7);
            notas.Add(4);
            notas.Add(8);

            double mediaEsperada = 5.143;
            int suspensosEsperados = 3;
            int aprobadosEsperados = 1;
            int notablesEsperados = 2;
            int sobresalientesEsperados = 1;

            ADSG2021_EstadisticasNotas estadisticas = new ADSG2021_EstadisticasNotas(notas);
            //estadisticas.CalcularEstadisticas(notas);

            double actualMedia = estadisticas.Media;
            int actualSuspensos = estadisticas.Suspensos;
            int actualAprobados = estadisticas.Aprobados;
            int actualNotables = estadisticas.Notables;
            int actualSobresalientes = estadisticas.Sobresalientes;

            Assert.AreEqual(mediaEsperada, actualMedia, 0.001, "Media obtenida incorrectamente");
            Assert.AreEqual(suspensosEsperados, actualSuspensos, 0.0001, "Suspensos incorrectos");
            Assert.AreEqual(aprobadosEsperados, actualAprobados, 0.0001, "Aprobados incorrectos");
            Assert.AreEqual(notablesEsperados, actualNotables, 0.0001, "Notables incorrectos");
            Assert.AreEqual(sobresalientesEsperados, actualSobresalientes, 0.0001, "Sobresalientes incorrectos");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ListaVacia()
        {
            List<int> notas = new List<int>();
            ADSG2021_EstadisticasNotas estadisticas = new ADSG2021_EstadisticasNotas(notas);
        }

        [TestMethod]
        public void NotasInorrectasExcepcion()
        {
            List<int> notas = new List<int>();

            notas.Add(0);
            notas.Add(-5);
            notas.Add(9);
            notas.Add(3);
            notas.Add(7);
            notas.Add(4);
            notas.Add(8);

            try
            {
                // creamos el objeto y le pasamos la lista
                ADSG2021_EstadisticasNotas estadisticas = new ADSG2021_EstadisticasNotas(notas);
            }
            catch (ArgumentOutOfRangeException error)
            {

                StringAssert.Contains(error.Message, ADSG2021_EstadisticasNotas.ValoresErroneosMessage);
                return;
            }
            Assert.Fail("No hay excepciones");
                                            
        }
    }
}
