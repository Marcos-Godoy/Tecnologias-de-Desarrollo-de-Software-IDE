using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Podria llamarse PropiedadController (MVC) y habria que modificar también el Program.cs (osea sacarle los endpoints) de la WebApi
// Estaria en una carpeta en la solucion llamada WebApi y sería un Controlador MVC vacio.

namespace Godoy.Domain
{
    public class PropiedadService
    {
        
        public void Add(Propiedad entidad)
        {
            if(Validaciones.IsValid(entidad))
            {
                using var context = new MyDbContext();
                context.Propiedades.Add(entidad);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using var context = new MyDbContext();
            Propiedad? entidadToDelete = context.Propiedades.Find(id);
            if (entidadToDelete != null)
            {
                context.Propiedades.Remove(entidadToDelete);
                context.SaveChanges();
            }
        }

        public Propiedad? Get(int id)
        {
            using var context = new MyDbContext();
            return context.Propiedades.Find(id);
        }

        public IEnumerable<Propiedad> GetAll()
        {
            using var context = new MyDbContext();
            //string query = "SELECT * FROM Propiedades";
            //return context.Propiedades.FromSqlRaw(query).Where<Propiedad>(b => b.FechaAlta >= DateTime.Now.AddDays(-30)).OrderByDescending(b => b.FechaAlta).ToList();
            //return context.Propiedades.ToList();

            // Tendria que mostrar la descripcion de la propiedad
            var entidades = context.Propiedades
                //.Include(x => x.IdTipoPropiedad)
                .Where(b => b.FechaAlta >= DateTime.Now.AddDays(-30))
                .OrderByDescending(b => b.FechaAlta)
                .ToList();
            return entidades;
        }

        public void Update(Propiedad entidad)
        {
            using var context = new MyDbContext();
            Propiedad? entidadToUpdate = context.Propiedades.Find(entidad.Id);
            if (entidadToUpdate != null)
            {
                entidadToUpdate.Precio = entidad.Precio;
                entidadToUpdate.M2 = entidad.M2;
                entidadToUpdate.CantidadHabitaciones = entidad.CantidadHabitaciones;
                entidadToUpdate.FechaAlta = entidad.FechaAlta;
                entidadToUpdate.Titulo = entidad.Titulo;
                entidadToUpdate.Descripcion = entidad.Descripcion;
                entidadToUpdate.IdTipoPropiedad = entidad.IdTipoPropiedad;
                context.SaveChanges();
            }
        }
        

        // METODOS ADO.NET
        // Agregar: using Microsoft.Data.SqlClient; using System.Data;
        /*
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=PCProductos;Integrated Security=True;trustServerCertificate=True";
        private SqlConnection conexion;
        public SqlConnection Conexion
        {
            get { return conexion; }
            set
            { conexion = value; }
        }
        protected void AbrirConexion()
        {
            Conexion = new SqlConnection(connectionString);
            Conexion.Open();
        }
        protected void CerrarConexion()
        {
            Conexion.Close();
            Conexion = null;
        }
        public void Add(Producto entity)
        {
            AbrirConexion();
            SqlCommand comando = new SqlCommand("INSERT INTO Productos (Codigo, Descripcion, Precio) VALUES (@Codigo, @Descripcion, @Precio)", Conexion);
            comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = entity.Codigo;
            comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 50).Value = entity.Descripcion;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = entity.Precio;
            comando.ExecuteNonQuery();
            CerrarConexion();
        }
        public IEnumerable<Producto> GetAll()
        {
            var productos = new List<Producto>();
            AbrirConexion();
            string query = "SELECT * FROM Productos WHERE Codigo != 'A010' AND Codigo != 'A020' ORDER BY Precio DESC";
            SqlCommand comando = new SqlCommand(query, Conexion);
            //comando.Parameters.Add("@Codigo1", SqlDbType.NVarChar, 50, "Codigo");
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Producto p = new Producto();
                p.Id = Convert.ToInt32(reader["Id"]);
                p.Codigo = Convert.ToString(reader["Codigo"]);
                p.Descripcion = Convert.ToString(reader["Descripcion"]);
                p.Precio = Convert.ToDecimal(reader["Precio"]);
                productos.Add(p);
            }
            CerrarConexion();
            return productos;
        }
        public void Update(Producto entity)
        {
            AbrirConexion();
            SqlCommand comando = new SqlCommand("UPDATE Productos SET Codigo = @Codigo, Descripcion = @Descripcion, Precio = @Precio WHERE Id = @Id", Conexion);
            comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = entity.Codigo;
            comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 50).Value = entity.Descripcion;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = entity.Precio;
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = entity.Id;
            comando.ExecuteNonQuery();
            CerrarConexion();
        }
        public void Delete(int id)
        {
            AbrirConexion();
            SqlCommand comando = new SqlCommand("DELETE FROM Productos WHERE Id = @Id", Conexion);
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            comando.ExecuteNonQuery();
            CerrarConexion();
        }
        public Producto? Get(int id)
        {
            AbrirConexion();
            SqlCommand comando = new SqlCommand("SELECT * FROM Productos WHERE Id = @Id", Conexion);
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            SqlDataReader reader = comando.ExecuteReader();
            Producto p = new Producto();
            if (reader.Read())
            {
                p.Id = Convert.ToInt32(reader["Id"]);
                p.Codigo = Convert.ToString(reader["Codigo"]);
                p.Descripcion = Convert.ToString(reader["Descripcion"]);
                p.Precio = Convert.ToDecimal(reader["Precio"]);
            }
            CerrarConexion();
            reader.Close();
            return p;
        }
        */
    }
}
