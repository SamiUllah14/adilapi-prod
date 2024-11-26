using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var persons = await _context.Persons.ToListAsync();
            return Ok(persons);
        }

        // GET: api/person/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound("Person not found.");
            return Ok(person);
        }

        // POST: api/person
        [HttpPost]
        public async Task<ActionResult<Person>> Create([FromBody] PersonDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Password cannot be null or empty.");

            var existingPerson = await _context.Persons
                .FirstOrDefaultAsync(p => p.Name == dto.Name);

            if (existingPerson != null)
                return Conflict("A person with this name already exists. Please use a unique name.");

            var person = new Person
            {
                Name = dto.Name,
                Address = dto.Address,
                MobileNumber = dto.MobileNumber,
                Password = dto.Password // Storing plain text password
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        // PUT: api/person/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PersonDto dto)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound("Person not found.");

            person.Name = dto.Name;
            person.Address = dto.Address;
            person.MobileNumber = dto.MobileNumber;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                person.Password = dto.Password; // Updating plain text password
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/person/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound("Person not found.");

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/person/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(p => p.MobileNumber == dto.MobileNumber);

            if (person == null || person.Password != dto.Password)
                return Unauthorized("Invalid mobile number or password.");

            return Ok(new { Message = "Login successful", Person = person });
        }

        // POST: api/person/reset-password
        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NewPassword))
                return BadRequest("New password cannot be null or empty.");

            var person = await _context.Persons
                .FirstOrDefaultAsync(p => p.Name == dto.Name);

            if (person == null)
                return BadRequest("No person found with the provided name.");

            person.Password = dto.NewPassword; // Resetting plain text password

            await _context.SaveChangesAsync();

            return Ok("Password updated successfully.");
        }
    }
}


