using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_poo
{
    public abstract class TransportePublico
    {
        public int pasajeros { get; set; }

        public TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public string Avanzar()
        {
            return string.Format("\n \nLos pasajeros han subido, Ya se puede Avanzar... \n");
        }

        public string Detenerse()
        {
            return string.Format("\n \nDetenerse para el ascenso de pasajeros \n");
        }

        public abstract string MostrarPasajeros();
    }
}
