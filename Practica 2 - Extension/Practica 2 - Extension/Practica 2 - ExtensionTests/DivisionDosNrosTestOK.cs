using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica_2___Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2___Extension.Tests
{
    [TestClass()]
    public class CalcularDivisionTestsOk
    {
        [TestMethod()]
        public void DivisionDosNrosTestOK()
        {
            //preparar escenario
            int num1 = 10;
            int num2 = 5;
            int resEsperado = 2;
            int resObtenido;

            CalcularDivision calcular = new CalcularDivision();

            resObtenido= calcular.DivisionDosNros(num1, num2);

            Assert.AreEqual(resEsperado, resObtenido);
        }

    }
}