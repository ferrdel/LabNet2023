using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IABMLogic<Region> regionLogic = new RegionLogic();
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            CustomersLogic customersLogic = new CustomersLogic();

            int opc = 0;
            int idCat;
            String descripCat;

            do
            {
                Console.WriteLine("SELECCIONE UNA OPCION: ");
                Console.WriteLine("1- LISTADO DE REGIONES: ");
                Console.WriteLine("2- LISTADO DE CATEGORIAS: ");
                Console.WriteLine("3- LISTADO DE CLIENTES: ");
                Console.WriteLine("4- INGRESAR UN REGISTRO EN CATEGORIAS: ");
                Console.WriteLine("5- MODIFICAR REGISTRO DE CATEGORIAS: ");
                Console.WriteLine("6- ELIMINAR UN REGISTRO EN CATEGORIAS: ");
                Console.WriteLine("\n--> INGRESE 0 PARA TERMINAR... ");
                Console.Write("\n - Introduzca una opcion: ");

                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Opcion incorrecta: " + e.Message);
                    opc = 0;
                    Console.ReadLine();
                    Console.Clear();
                }


                switch (opc)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("LISTADO DE REGIONES: ");
                            ListarRegiones();
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("LISTADO DE CATEGORIAS: ");

                            ListarCategorias();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("LISTADO DE CUSTOMERS con su cuidad: ");

                            ListarCustomers();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        //insercion de un registro a una tabla de la BD
                        AgregarCategoria();

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        //Actualizacion de un registro a una tabla de la BD
                        
                        ListarCategorias();

                        Console.Write("- Seleccione registro a modificar: ");
                        idCat = int.Parse(Console.ReadLine());
                        
                        Console.Write("- Ingrese Nombre a modificar: ");
                        descripCat=Console.ReadLine();

                        try
                        {
                        ModificarCategoria(idCat,descripCat);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ERROR! - " + e.Message);
                        }


                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        //Borrar una region de la tabla
                        ListarCategorias();
                        Console.Write("Ingrese el numero de la Categoria a eliminar: ");
                        try
                        {
                            var idOc = int.Parse(Console.ReadLine());

                            EliminarCategoeria(idOc);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("ERROR! - " + e.Message);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default:
                        break;

                }

            } while (opc > 0 && opc < 7);
        }

        private static void ListarRegiones()
        {
            Console.WriteLine("Listado de  Regiones ");
            IABMLogic<Region> regionLogic = new RegionLogic();

            foreach (var item in regionLogic.GetAll())
            {
                Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
            }
        }

        private static void ListarCategorias()
        {
            IABMLogic<Categories> categoriesLogic = new CategoriesLogic();

            foreach (var item in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{item.CategoryID} - {item.CategoryName}");
            }
        }

        private static void ListarCustomers()
        {
            IABMLogic<Customers> customersLogic = new CustomersLogic();

            foreach (var item in customersLogic.GetAll())
            {
                Console.WriteLine($"\tCliente: {item.ContactName} - \t\tCiudad: {item.Country}");
            }
        }


        private static void AgregarCategoria()
        {
            IABMLogic<Categories> categoriesLogic = new CategoriesLogic();
            int idOb='0';
            var descOb="";

            Console.Write("\n- Ingrese el ID de la Categoria: ");
            try
            {
                idOb = int.Parse(Console.ReadLine());
                Console.Write("\n- Ingrese el NOMBRE de la Categoria: ");
                descOb = Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("\nERROR! - "+e.Message);
            }
                        

            try
            {

                categoriesLogic.Add(new Categories
                {
                    CategoryID = idOb,
                    CategoryName = descOb
                });
                Console.WriteLine("\n--> Categoria Agregada Exitosamente!");

            }
            catch (Exception r)
            {
                Console.WriteLine("Error! --> " + r.Message);
            }
        }

        private static void ModificarCategoria(int idP, String descP)
        {
            IABMLogic<Categories> categoriesLogic = new CategoriesLogic();
                        
            try
            {
                categoriesLogic.Update(new Categories
                {
                    CategoryName = descP,
                    CategoryID = idP
                });

                Console.WriteLine("Categoria Modificado");
            }
            catch (Exception r)
            {
                Console.WriteLine("Error! --> " + r.Message);
            }
        }

        private static void EliminarCategoeria(int idOcP)
        {
            IABMLogic<Categories> categoriesLogic = new CategoriesLogic();

            try
            {
                categoriesLogic.Delete(idOcP);
                Console.WriteLine("--> Registro Eliminado Exitosamete");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error --> " + e.Message);
            }
        }
    }
}
