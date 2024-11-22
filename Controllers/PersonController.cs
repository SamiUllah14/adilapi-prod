using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adilapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/person
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_context.Persons.ToList());
        }

        // GET: api/person/{id}
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var person = _context.Persons.Find(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST: api/person
        [HttpPost]
        public ActionResult<Person> Create([FromBody] PersonDto dto)
        {
            if (string.IsNullOrEmpty(dto.Password))
                return BadRequest("Password cannot be null or empty.");

            var existingPerson = _context.Persons
                .FirstOrDefault(p => p.Name == dto.Name);

            if (existingPerson != null)
            {
                return Conflict("A person with this name already exists. Please use a unique name.");
            }

            var person = new Person
            {
                Name = dto.Name,
                Address = dto.Address,
                MobileNumber = dto.MobileNumber,
                Password = dto.Password // Save plain text password as requested
            };

            _context.Persons.Add(person);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        // PUT: api/person/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] PersonDto dto)
        {
            var person = _context.Persons.Find(id);
            if (person == null) return NotFound();

            person.Name = dto.Name;
            person.Address = dto.Address;
            person.MobileNumber = dto.MobileNumber;
            person.Password = dto.Password;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/person/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var person = _context.Persons.Find(id);
            if (person == null) return NotFound();

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/person/reset-password
        [HttpPost("reset-password")]
        public ActionResult ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (string.IsNullOrEmpty(dto.NewPassword))
                return BadRequest("New password cannot be null or empty.");

            var person = _context.Persons
                .FirstOrDefault(p => p.Name == dto.Name);

            if (person == null)
            {
                return BadRequest("No person found with the provided name.");
            }

            person.Password = dto.NewPassword;

            _context.SaveChanges();

            return Ok("Password updated successfully.");
        }
    }
}
