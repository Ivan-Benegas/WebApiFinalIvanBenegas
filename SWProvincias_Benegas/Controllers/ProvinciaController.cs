using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Benegas.Data;
using SWProvincias_Benegas.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Benegas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {

        private readonly DBPaisFinalContext context;
        public ProvinciaController(DBPaisFinalContext context)
        {
            this.context = context;
        }


        // GET: api/provincia
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();

        }


        // GET api/provincia/1
        [HttpGet("{id}")]
        public ActionResult<Provincia> GetById(int id)
        {
            Provincia provincia = (from a in context.Provincias
                                   where a.IdProvincia == id
                                   select a).SingleOrDefault();
            return provincia;
        }


        // POST api/provincia
        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia); 
            context.SaveChanges();
            return Ok(); 

        }


        // PUT api/provincia/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }
            context.Entry(provincia).State = EntityState.Modified; 
            context.SaveChanges(); 
            return NoContent();
        }


        // DELETE api/provincia/1
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from a in context.Provincias
                           where a.IdProvincia == id
                           select a).SingleOrDefault();

            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return provincia;
        }


    }
}
