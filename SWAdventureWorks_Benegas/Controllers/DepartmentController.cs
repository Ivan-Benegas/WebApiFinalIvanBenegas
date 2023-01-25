using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Benegas.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Benegas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly AdventureWorks2019Context context;
        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }


        // GET: api/department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Department.ToList();

        }


        // GET api/department/1
        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            Department department = (from a in context.Department
                                     where a.DepartmentId == id
                                   select a).SingleOrDefault();
            return department;
        }


        //GET: api/department/hola
        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Department>> GetEdad(string name)
        {
            List<Department> department = (from a in context.Department
                                           where a.Name == name
                                   select a).ToList();
            return department;
        }


        // POST api/department
        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Department.Add(department);
            context.SaveChanges();
            return Ok();

        }


        // PUT api/department/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }


        // DELETE api/department/1
        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(int id)
        {
            var department = (from a in context.Department
                              where a.DepartmentId == id
                             select a).SingleOrDefault();

            if (department == null)
            {
                return NotFound();
            }
            context.Department.Remove(department);
            context.SaveChanges();
            return department;
        }


    }
}
