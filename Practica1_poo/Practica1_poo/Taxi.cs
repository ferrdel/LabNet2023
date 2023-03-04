using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_poo
{
    public class Taxi : TransportePublico
    {
        //Metodo constructor
        public Taxi (int pasajeros): base(pasajeros)
        {
        }

        public override string MostrarPasajeros()
        {
            return $"Taxi: {pasajeros} pasajeros";
        }
    }
}
