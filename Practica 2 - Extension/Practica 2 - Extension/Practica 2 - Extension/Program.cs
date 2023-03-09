using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2___Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1;
            int n2;
            int dato;
            Logic log = new Logic();
            CalcularDivision calculo = new CalcularDivision();
            var numeros = new List<int>();
            var numeros2 = new List<int>();

                        
            Console.Write("\n Punto 1 del Practico.... \n Precione una tecla para continuar..");

            Console.ReadKey();

            Console.Write("\n \n Ingrese un valor numerico: ");
            try
            {
                n1 = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Error!, Ingrese un Valor Numerico \n" +ex.Message + "\n");
                n1 = '0';
            }

            try
            {
                calculo.Division(n1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! - " + e);
            }

            Console.WriteLine("\n Presione una tecla para pasar al item 2...");
            Console.ReadKey();
            Console.Clear();
            
            Console.Write("\n \n Punto 2 del Practico.... \n\n Precione una tecla para continuar..");

            Console.ReadKey();

            Console.Write("\n \n Ingrese el primer numero: ");
            try
            {
                n1 = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("\n Seguro Ingreso una letra o no ingreso ningun valor numerico! \n" +  ex.Message + "\n");
                n1 = 0;
            }


            Console.Write("\n Ingrese el segundo numero: ");
            try
            {
                n2= Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n Seguro Ingreso una letra o no ingreso ningun valor numerico!\n" + ex.Message);
                n2='0';
            }

            try
            {
                calculo.DivisionDosNros(n1, n2);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                if (e.GetType().Name == "DivideByZeroException")
                {
                    Console.WriteLine("\n --------------------------------------------------------");
                    Console.WriteLine("       Solo Chuck Norris divide por cero!");
                    Console.WriteLine(" --------------------------------------------------------");

                }
                Console.WriteLine("\n Error! -> " + e);
            }

            Console.WriteLine("\n Presione una tecla para pasar al item 3...");
            Console.ReadKey();
            Console.Clear();



            Console.Write("\n \n Punto 3 del Practico.... \n\n Precione una tecla para continuar..");

            Console.Write("\n Ingrese tamaño de la lista: ");
            
            n1 = int.Parse(Console.ReadLine());

            Console.Write("\n Ingrese los datos a la lista: ");

            while (numeros.Count() < n1)
            {
                dato = int.Parse(Console.ReadLine());
                numeros.Add(dato);
            }

            Console.Write("\n Ingrese el numero de la posicion a visualizar: ");
            n2 = (int.Parse(Console.ReadLine()) - 1);
            

            try
            {
                Console.WriteLine("\n El valor de la posicion es: " + log.ObtenerValor(numeros.ToArray(), n2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Tipo de Exceptions: "+ex.GetType());
            }

            Console.WriteLine("\nPresione una tecla para pasar al item 4...");
            Console.ReadKey();
            Console.Clear();


            Console.Write("\n \n Punto 4 del Practico.... \n\n Precione una tecla para continuar..");

            Console.Write("\n Ingrese tamaño de la lista: ");

            n1 = int.Parse(Console.ReadLine());

            Console.Write("\n Ingrese los datos a la lista: ");

            while (numeros2.Count() < n1)
            {
                dato = int.Parse(Console.ReadLine());
                numeros2.Add(dato);
            }

            Console.Write("\n Ingrese el numero de la posicion a visualizar: ");
            n2 = (int.Parse(Console.ReadLine()) - 1);


            try
            {
                Console.WriteLine("\n El valor de la posicion es: "+log.ObtenerValor(numeros2.ToArray(), n2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Tipo de Exceptions: " + ex.GetType());
            }

            Console.WriteLine("\nPresione una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
