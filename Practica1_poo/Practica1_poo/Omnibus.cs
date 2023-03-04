
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_poo
{
    public class Omnibus: TransportePublico
    {

        //Metodo constructor
        public Omnibus(int pasajeros) : base(pasajeros)
        {

        }
                       
        public override string MostrarPasajeros()
        {
            return $"Omnibus: {pasajeros} pasajeros";
        }
    }
}
