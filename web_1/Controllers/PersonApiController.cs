using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using web_1.Context;
using web_1.Models;

namespace web_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonApiController : Controller
    {

        private readonly ApplicationDBContext _context;

        // Constructor to initialize the controller with the database context
        public PersonApiController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Person> Get()
        {
            var personlar = _context.Persons.ToList();
            // normalde json formatına cevirip gondermem lazım  [ApiController] bunu otomatik yapıyor
            return personlar;
        }
        // GET api/<PERDONApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var person = _context.Persons.FirstOrDefault(e => e.person_id == id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
        // POST api/<YazarApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            //if (ModelState.IsValid)  [ApiController] doğrulamayı yapoıypr
            _context.Persons.Add(person);
            _context.SaveChanges();
            return Ok(person);
        }
        // PUT api/<YazarApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] Person person)
        {
            if (id is null)
            {
                return NotFound();
            }
            var _person = _context.Persons.FirstOrDefault(e => e.person_id == id);
            if (_person == null)
            {
                return NotFound();
            }

            _person.ad = person.ad;
            _person.telefon = person.telefon;
            _person.soyad = person.soyad;
            _person.dogum_tarihi = person.dogum_tarihi;
            _person.gmail = person.gmail;
            _person.sifre = person.sifre;

            _context.Update(_person);
            _context.SaveChanges();
            return Ok(_person);
        }

        // DELETE api/<YazarApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var person = _context.Persons.FirstOrDefault(z => z.person_id == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return Ok(person);
        }

    }
}