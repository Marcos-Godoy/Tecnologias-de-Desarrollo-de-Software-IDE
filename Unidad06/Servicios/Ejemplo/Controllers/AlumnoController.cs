using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejemplo.Context;
using Ejemplo.Models;

namespace Ejemplo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AlumnoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAlumno")]
        public ActionResult<IEnumerable<Alumnos>> GetAll()
        {
            return _context.Alumnos.ToList();
        }

        [HttpGet("{DNI}")]
        public ActionResult<Alumnos> GetById(String DNI)
        {
            var alumno = _context.Alumnos.Find(DNI);
            if (alumno == null)
            {
                return NotFound();
            }
            return alumno;
        }

        [HttpPost]
        public ActionResult<Alumnos> Create(Alumnos alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { DNI = alumno.DNI }, alumno);
        }

        [HttpPut("{DNI}")]
        public ActionResult Update(string DNI, Alumnos alumno)
        {
            if (DNI != alumno.DNI)
            {
                return BadRequest();
            }
            _context.Entry(alumno).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{DNI}")]
        public ActionResult<Alumnos> Delete(String DNI)
        {
            var alumno = _context.Alumnos.Find(DNI);
            if(alumno == null)
            {
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();
            return alumno;

        }


        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
