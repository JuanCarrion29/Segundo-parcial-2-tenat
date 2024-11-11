using Microsoft.AspNetCore.Mvc;
using Segundo_parcial_2.Models;
using Segundo_parcial_2.Data;

namespace Segundo_parcial_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<Apartment>> GetApartments()
        {
            return _context.Apartments.ToList();
        }

        
        [HttpGet("{id}")]
        public ActionResult<Apartment> GetApartment(int id)
        {
            var apartment = _context.Apartments.Find(id);

            if (apartment == null)
                return NotFound();

            return apartment;
        }

        
        [HttpPost]
        public ActionResult<Apartment> PostApartment(Apartment apartment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Apartments.Add(apartment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetApartment), new { id = apartment.Id }, apartment);
        }

        
        [HttpPut("{id}")]
        public IActionResult PutApartment(int id, Apartment apartment)
        {
            if (id != apartment.Id)
                return BadRequest();

            _context.Entry(apartment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteApartment(int id)
        {
            var apartment = _context.Apartments.Find(id);

            if (apartment == null)
                return NotFound();

            _context.Apartments.Remove(apartment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
