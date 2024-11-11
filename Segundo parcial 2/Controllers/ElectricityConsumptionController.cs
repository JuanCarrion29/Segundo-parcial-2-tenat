using Microsoft.AspNetCore.Mvc;
using Segundo_parcial_2.Data;
using Segundo_parcial_2.Models;


namespace Segundo_parcial_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityConsumptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ElectricityConsumptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<ElectricityConsumption>> GetElectricityConsumptions()
        {
            return _context.ElectricityConsumptions.ToList();
        }

        
        [HttpGet("{id}")]
        public ActionResult<ElectricityConsumption> GetElectricityConsumption(int id)
        {
            var consumption = _context.ElectricityConsumptions.Find(id);

            if (consumption == null)
                return NotFound();

            return consumption;
        }

        
        [HttpPost]
        public ActionResult<ElectricityConsumption> PostElectricityConsumption(ElectricityConsumption consumption)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ElectricityConsumptions.Add(consumption);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetElectricityConsumption), new { id = consumption.Id }, consumption);
        }

        
        [HttpPut("{id}")]
        public IActionResult PutElectricityConsumption(int id, ElectricityConsumption consumption)
        {
            if (id != consumption.Id)
                return BadRequest();

            _context.Entry(consumption).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteElectricityConsumption(int id)
        {
            var consumption = _context.ElectricityConsumptions.Find(id);

            if (consumption == null)
                return NotFound();

            _context.ElectricityConsumptions.Remove(consumption);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
