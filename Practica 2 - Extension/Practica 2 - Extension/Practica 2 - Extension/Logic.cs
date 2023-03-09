
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2___Extension
{
    public class Logic
    {
        public int ObtenerValor(int[] lista ,int n)
        {
            
            if (n <= lista.Count())
            {
                return lista[n];
            }
            else
            {
                throw new LogicExceptions();
            }
        
        }
    }
}
