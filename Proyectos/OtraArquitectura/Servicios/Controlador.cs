using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios
{
    [ApiController]
    [Route("api/[controller]")]
    public class Controlador : ControllerBase
    {
        private readonly MyDbContext _context;


        public Controlador(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "Get")]
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
            var entidad = _context.Alumnos.Find(DNI);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpPost]
        public ActionResult<Alumno> Create(Alumno entidad)
        {
            _context.Alumnos.Add(entidad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { DNI = entidad.DNI }, entidad);
        }

        [HttpPut("{DNI}")]
        public ActionResult Update(string DNI, Alumno entidad)
        {
            if (DNI != entidad.DNI)
            {
                return BadRequest();
            }
            _context.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{DNI}")]
        public ActionResult<Alumno> Delete(string DNI)
        {
            var entidad = _context.Alumnos.Find(DNI);
            if (entidad == null)
            {
                return NotFound();
            }
            _context.Alumnos.Remove(entidad);
            _context.SaveChanges();
            return entidad;
        }

    }
}
