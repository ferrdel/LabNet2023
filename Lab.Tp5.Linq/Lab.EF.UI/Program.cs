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
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Ejerc 1 - Devolver objeto customer");
            ObtenerCustomers();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nEjerc 2 - Devolver todos los productos sin stock");
            productSinStock();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nEjerc 3 - Devolver todos los productos con stock");
            productStock();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nEjerc 4 - Devolverlos customers de la Región WA");
            CustomersRegion();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nEjerc 5 - Devolver el primer elemento o nulo de una lista de productos");
            productPorId();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nEjerc6 - Devolver los nombre de Customers. Mostrarlos en Mayuscula y Minuscula");
            CustomersMayMin();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nEjerc7 -  Devolver Join entre Customers y Orders ");
            CustomersOrders();
            Console.ReadKey();


        }

        private static void productSinStock()
        {
            IABMLogic<Products> productsLog = new ProducLogic();

            var products = productsLog.GetAll();
            var query2 = products.Where(p => p.UnitsInStock == 0).ToList();

            foreach (var i in query2)
            {
                Console.WriteLine("Producto: " + i.ProductName + " - Stock: " + i.UnitsInStock);
            }
        }

        private static void productPorId()
        {
            IABMLogic<Products> productsLog = new ProducLogic();

            var products = productsLog.GetAll();
            var query2 = products.Where(p => p.ProductID == 789).Select(s => s.ProductName).FirstOrDefault();

            if (query2 == null)
            {
                Console.WriteLine("\n Error, no se encontro el producto");
            }
            else
            {
                Console.WriteLine(query2);
            }

        }

        private static void productStock()
        {

            IABMLogic<Products> productsLog = new ProducLogic();

            var products = productsLog.GetAll();

            var query3 = from prod in products
                         where prod.UnitsInStock > 0
                         select prod.ProductName;


            foreach (var i in query3)
            {
                Console.WriteLine(i);
            }
        }

        private static void ObtenerCustomers()
        {
            IABMLogic<Customers> customerLog = new CustomersLogic();

            var customers = customerLog.GetAll();

            var query = customers.Where(c => c.CustomerID == "ALFKI").ToList();


            foreach (var i in query)
            {
                Console.WriteLine(i.CompanyName + " - " + i.ContactName + " - " + i.ContactTitle);
            }
        }

        private static void CustomersRegion()
        {
            IABMLogic<Customers> customerLog = new CustomersLogic();

            var customers = customerLog.GetAll();

            var query3 = from c in customers
                         where c.Region == "WA"
                         select c.CompanyName;


            foreach (var i in query3)
            {
                Console.WriteLine(i);
            }
        }

        private static void CustomersOrders()
        {
            IABMLogic<Customers> customerLog = new CustomersLogic();
            IABMLogic<Orders> ordersLog = new OrdersLogic();
            DateTime fecha = new DateTime(1997, 1, 1);

            var customers = customerLog.GetAll();
            var order = ordersLog.GetAll();

            var query6 = (from c in customers
                          join b in order
                          on c.CustomerID equals b.CustomerID
                          where b.OrderDate > fecha && c.Region == "WA"
                          select c.CompanyName).ToList();

             
            foreach(var i in query6)
            {
                Console.WriteLine(i);
            }
        }

        private static void CustomersMayMin()
        {
            IABMLogic<Customers> customerLog = new CustomersLogic();
            var customers = customerLog.GetAll();

            var upper = customers.Select(c => c.CompanyName.ToUpper()).ToList();


            Console.WriteLine("\n \tNombres Mostrados en Mayuscula");
            foreach (var u in upper)
            {
                Console.WriteLine(u);
            }

            Console.ReadKey();
            Console.Clear();

            var lower = customers.Select(c => c.CompanyName.ToLower()).ToList();

            Console.WriteLine("\n \tNombres Mostrados en Minuscula");
            foreach (var l in lower)
            {
                Console.WriteLine(l);
            }


        }
    }
}
