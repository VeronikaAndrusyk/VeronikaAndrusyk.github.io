using labka9.models;
using Microsoft.AspNetCore.Mvc;



namespace StudentController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        StudentRepository _repo = new StudentRepository(new AppDbcontext());
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
            var flat = await _repo.GetById(id);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
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
            var flat = await _repo.Update(id, value);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var flat = await _repo.Delete(id);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
        }
    }
}
