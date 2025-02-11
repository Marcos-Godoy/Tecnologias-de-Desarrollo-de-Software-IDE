using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Domain
{
    public class ProductoService
    {
        // Alta de un nuevo Producto  
        public void Add(Producto entity)
        {
            using var context = new ProductoContext();
            context.Productos.Add(entity);
            context.SaveChanges();
        }
        // Consulta de todos los productos
        public IEnumerable<Producto> GetAll()
        {
            using var context = new ProductoContext();
            //return context.Productos.ToList();
            var productos = context.Productos
                .Where(b => b.Codigo != "A010" && b.Codigo != "A020")
                .OrderByDescending(b => b.Precio)
                .ToList();
            return productos;
        }
        // Update
        public void Update(Producto producto)
        {
            using var context = new ProductoContext();
            Producto? productoToUpdate = context.Productos.Find(producto.Id);
            if (productoToUpdate != null)
            {
                productoToUpdate.Precio = producto.Precio;
                productoToUpdate.Codigo = producto.Codigo;
                productoToUpdate.Descripcion = producto.Descripcion;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using var context = new ProductoContext();
            Producto? productoToDelete = context.Productos.Find(id);
            if (productoToDelete != null)
            {
                context.Productos.Remove(productoToDelete);
                context.SaveChanges();
            }
        }
        public Producto? Get(int id)
        {
            using var context = new ProductoContext();
            return context.Productos.Find(id);
        }/*

        // METODOS ADO.NET

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
