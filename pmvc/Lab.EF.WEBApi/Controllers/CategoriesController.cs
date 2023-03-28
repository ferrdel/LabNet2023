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

        public IEnumerable<Categories> Get()
        {
            return logic.GetAll();
        }

        // GET api/<controller>/5
        public Categories Get(int id)
        {
            return logic.GetId(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Categories categoria)
        {
            try
            {
                if (string.IsNullOrEmpty(categoria.CategoryName))
                {
                    throw new ArgumentException("Los campos Nombre es requerido.");
                }
                logic.Add(categoria);

                return Request.CreateResponse(HttpStatusCode.Created, categoria);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] Categories categoria)
        {
            try
            {
                if (categoria == null || categoria.CategoryID != id)
                {
                    throw new ArgumentException("El ID de l categoria no coincide.");
                }

                var existingCateg = logic.GetId(id);
                if (existingCateg == null)
                {
                    throw new ArgumentException($"Categoria con ID {id} no existente.");
                }

                existingCateg.CategoryName = categoria.CategoryName;
                existingCateg.Description = categoria.Description;
                logic.Update(existingCateg);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}