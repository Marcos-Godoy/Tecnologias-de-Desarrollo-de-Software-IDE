using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios
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
        public ActionResult<IEnumerable<Alumno>> GetAll()
        {
            return _context.Alumnos.ToList();
            /*var fechaLimite = DateTime.Now.AddDays(-30);
            return _context.Propiedades
                .Include(prop => prop.TipoPropiedad)
                .Where(prop => prop.FechaAlta >= fechaLimite)
                .OrderByDescending(prop => prop.FechaAlta)
                .ToList();*/
        }

        [HttpGet("{DNI}")]
        public ActionResult<Alumno> GetById(String DNI)
        {
            var alumno = _context.Alumnos.Find(DNI);
            if (alumno == null)
            {
                return NotFound();
            }
            return alumno;
        }

        [HttpPost]
        public ActionResult<Alumno> Create(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { DNI = alumno.DNI }, alumno);
        }

        [HttpPut("{DNI}")]
        public ActionResult Update(string DNI, Alumno alumno)
        {
            if (DNI != alumno.DNI)
            {
                return BadRequest();
            }
            _context.Entry(alumno).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{DNI}")]
        public ActionResult<Alumno> Delete(string DNI)
        {
            var alumno = _context.Alumnos.Find(DNI);
            if (alumno == null)
            {
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();
            return alumno;
        }

    }
}
