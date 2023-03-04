using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_poo
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int t = 0;
            int cantidad;
            Taxi taxi = new Taxi(i);
            Omnibus omnibus = new Omnibus(i);


            List<TransportePublico> transporte = new List<TransportePublico>
            {
             };

            Console.WriteLine(taxi.Detenerse());


            while (i < 5)
            {
                Console.Write("Ingrese Cantidad de pasajeros a viajar en Taxi (0 - 4): ");
                cantidad = Convert.ToInt32(Console.ReadLine());
                
                if (0 <= cantidad && cantidad <= 4)
                {
                    transporte.Add(new Taxi(cantidad));
                    i++;
                }
                else
                {
                    Console.WriteLine("----------- \n Cantidad de pasajeros fuera del rango. Vuelva a ingresar cantidad \n-----------");
                }
            }


            while (i>=5 && i < 10) {
                Console.Write("Ingrese Cantidad de pasajeros a viajar en Omnibus (0 - 100): ");
                cantidad = Convert.ToInt32(Console.ReadLine());
                if (0 <= cantidad && cantidad <= 100)
                {
                    transporte.Add(new Omnibus(cantidad));
                    i++;
                }
                else
                {
                    Console.WriteLine("----------- \n -- Cantidad de pasajeros fuera del rango. Vuelva a ingresar cantidad  \n-----------");
                }
                
            }


            Console.WriteLine("\n Listado de Transportes con sus cantidad de pasajeros");

            
            foreach (var item in transporte)
            {
                t++;
                Console.WriteLine(t+"° " +item.MostrarPasajeros());
                if (t == 5)
                {
                    t = 0;
                }
            }

            Console.WriteLine(omnibus.Avanzar());

            Console.ReadLine();
        }
    }
}
