using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic logic = new CategoriesLogic();
        // GET: Categories
        public ActionResult Index()
        {
            List<Entities.Categories> categ = logic.GetAll();
            List<CategoriesView> categView = categ.Select(c => new CategoriesView
            {
                Id = c.CategoryID,
                NombreCategoria = c.CategoryName,
                Descripcion = c.Description
            }).ToList();

            return View(categView);
        }

        public ActionResult Delete(int id)
        {
            logic.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoriesView cat)
        {
            try
            {
                Categories categories = new Categories
                {
                    CategoryName = cat.NombreCategoria,
                    Description = cat.Descripcion
                };

                logic.Add(categories);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("IndexE", "Error");
            }
        }

        public ActionResult Update(int id)
        {
            CategoriesView catView = new CategoriesView();
            var ctEntity = logic.GetId(id);
            catView.Id = ctEntity.CategoryID;
            catView.NombreCategoria = ctEntity.CategoryName;
            catView.Descripcion = ctEntity.Description;

            return View(catView);
        }

        [HttpPost]
        public ActionResult Update(CategoriesView cat)
        {
            try
            {
                logic.Update(new Categories
                {
                    CategoryID = cat.Id,
                    CategoryName = cat.NombreCategoria,
                    Description = cat.Descripcion
                });

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}