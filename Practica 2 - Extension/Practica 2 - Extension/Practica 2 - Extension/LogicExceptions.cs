using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2___Extension
{
    public class LogicExceptions : Exception
    {
        public LogicExceptions() : base("Error! el valor a mostrar esta fuera del rango")
        {
            
        }
    }
}
