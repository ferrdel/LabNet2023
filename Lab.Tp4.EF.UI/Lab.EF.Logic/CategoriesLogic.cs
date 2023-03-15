using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        
        public List<Categories> GetAll()
        {
            return northContext.Categories.ToList();
        }

        public void Add(Categories newCategories)
        {
            northContext.Categories.Add(newCategories);

            northContext.SaveChanges();

        }

        public void Update(Categories categories)
        {
            var categoriesUpdate = northContext.Categories.Find(categories.CategoryID);

            categoriesUpdate.CategoryName = categories.CategoryName;

            northContext.SaveChanges();
        }

        public void Delete(int idCategories)
        {
            var categoriesDelete= northContext.Categories.Find(idCategories);


            northContext.Categories.Remove(categoriesDelete);

            northContext.SaveChanges();
        }
    }
}
