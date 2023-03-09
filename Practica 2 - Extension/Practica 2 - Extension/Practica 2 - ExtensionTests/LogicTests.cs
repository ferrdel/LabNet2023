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
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(LogicExceptions))]
        public void ObtenerValorTest()
        {
            int posicion = 4;
            var numeros = new List<int> { 33, 66, 55 };

            Logic listaNros = new Logic();

            listaNros.ObtenerValor(numeros.ToArray(), posicion);
        }
    }
}