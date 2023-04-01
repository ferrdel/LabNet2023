using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WEBApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Lab.EF.WEBApi.Controllers
{
    public class CategoriesController : ApiController
    {
        CategoriesLogic logic = new CategoriesLogic();

        // GET api/

        [System.Web.Mvc.HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Categories> categories = logic.GetAll();

                List<CategoriesView> listaCategorias = categories
                    .Select(e => new CategoriesView()
                    {
                        Id = e.CategoryID,
                        NombreCategoria = e.CategoryName,
                        Descripcion = e.Description
                    })
                    .ToList();

                return Ok(listaCategorias);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { Error = ex.Message });
            }
        }

        [System.Web.Mvc.HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Categories categories = logic.GetId(id);

                CategoriesView categId = new CategoriesView()
                {
                    Id = categories.CategoryID,
                    NombreCategoria = categories.CategoryName,
                    Descripcion = categories.Description
                };

                return Ok(categId);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { Error = ex.Message });
            }
        }

        [System.Web.Mvc.HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Categories categoria)
        {
            try
            {
                Categories categories = new Categories()
                {
                    CategoryName = categoria.CategoryName,
                    Description = categoria.Description
                };

                logic.Add(categories);
                return Content(HttpStatusCode.Created, new { CategoryName = categoria.CategoryName, Description = categoria.Description });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { Error = ex.Message });
            }
        }

        [System.Web.Http.HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult Update(int id, [FromBody] Categories categoria)
        {
            try
            {
                if (categoria == null || categoria.CategoryID != id)
                {
                    throw new ArgumentException("El ID de la categoria no coincide.");
                }

                var existingCateg = logic.GetId(id);
                if (existingCateg == null)
                {
                    throw new ArgumentException($"Categoria con ID {id} no existente.");
                }

                existingCateg.CategoryName = categoria.CategoryName;
                existingCateg.Description = categoria.Description;
                logic.Update(existingCateg);

                return Content(HttpStatusCode.OK, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [System.Web.Mvc.HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return Ok("La categoria se Elimino");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}