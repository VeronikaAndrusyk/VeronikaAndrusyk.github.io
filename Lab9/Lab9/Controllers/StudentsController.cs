using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab9.Models;
using Lab9.Controllers;


namespace Lab9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly StudentRepository _repo = new StudentRepository(new AppDbContext());
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _repo.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Student> Post([FromBody] Student value)
        {
            return await _repo.Create(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(int id, [FromBody] Student value)
        {
            var student = await _repo.Update(id, value);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _repo.Delete(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}