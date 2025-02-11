using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dominio
{
    public class VehiculoService
    {
        public void Add(Vehiculo propiedad)
        {
            if (VehiculoValidation.IsValid(propiedad))
            {
                using var context = new VehiculoContext();

                context.Vehiculos.Add(propiedad);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using var context = new VehiculoContext();

            Vehiculo propiedadToDelete = context.Vehiculos.Find(id);

            if (propiedadToDelete != null)
            {
                context.Vehiculos.Remove(propiedadToDelete);
                context.SaveChanges();
            }
        }

        public Vehiculo Get(int id)
        {
            using var context = new VehiculoContext();

            return context.Vehiculos.Find(id);
        }

        public IEnumerable<VehiculoDto> GetAll()
        {
            using var context = new VehiculoContext();
            //Método para regularidad
            //return context.Vehiculos.ToList();

            
            var propiedades = context.Vehiculos
                .Include(x => x.TipoPropiedad)
                .Where(b => b.FechaIngreso >= DateTime.Now.AddDays(-30))
                .OrderByDescending(b => b.FechaIngreso)
                .ToList();
            
            List<VehiculoDto> dtos = new List<VehiculoDto>();
            foreach (var propiedad in propiedades)
            {
                dtos.Add(this.ToDto(propiedad));
            }
            return dtos;
        }

        public void Update(Vehiculo propiedad)
        {
            using var context = new VehiculoContext();

            Vehiculo propiedadToUpdate = context.Vehiculos.Find(propiedad.Id);

            if (propiedadToUpdate != null)
            {
                propiedadToUpdate.Precio = propiedad.Precio;
                propiedadToUpdate.Patente = propiedad.Patente;
                propiedadToUpdate.CantidadPuertas = propiedad.CantidadPuertas;
                propiedadToUpdate.FechaIngreso = propiedad.FechaIngreso;
                propiedadToUpdate.Marca = propiedad.Marca;
                propiedadToUpdate.Modelo = propiedad.Modelo;
                propiedadToUpdate.TipoPropiedad = propiedad.TipoPropiedad;
                context.SaveChanges();
            }
        }

        
        public VehiculoDto ToDto(Vehiculo entidad)
        {
            VehiculoDto dto = new VehiculoDto();
            dto.Id = entidad.Id;
            dto.CantidadPuertas = entidad.CantidadPuertas;
            dto.Marca = entidad.Marca;

            dto.TipoPropiedadId = entidad.TipoPropiedadId;
            if (entidad.TipoPropiedad != null)
            {
                dto.TipoPropiedadDescripcion = entidad.TipoPropiedad.Descripcion;
            }

            dto.Modelo = entidad.Modelo;
            dto.Patente = entidad.Patente;
            dto.Precio = entidad.Precio;
            dto.FechaIngreso = entidad.FechaIngreso;
            return dto;
        }
    }
}
