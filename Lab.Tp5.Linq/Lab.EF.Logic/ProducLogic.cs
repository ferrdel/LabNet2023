using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ProducLogic : BaseLogic, IABMLogic<Products>
    {
        public List<Products> GetAll()
        {
            return northContext.Products.ToList();
        }

        public void Add(Products newProd)
        {
            northContext.Products.Add(newProd);

            northContext.SaveChanges();
        }

        public void Update(Products product)
        {
            var prodUpdate = northContext.Products.Find(product.ProductID);

            prodUpdate.ProductName = product.ProductName;

            northContext.SaveChanges();
        }

        public void Delete(int idProd)
        {
            var prodDelete = northContext.Products.Find(idProd);

            northContext.Products.Remove(prodDelete);

            northContext.SaveChanges();

        }
    }
}
