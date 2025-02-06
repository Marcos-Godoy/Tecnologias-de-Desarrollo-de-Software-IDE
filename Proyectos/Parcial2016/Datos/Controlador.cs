using Entidades;
using Microsoft.Data.SqlClient;

namespace Datos
{ // Podria haber usado entity framework tambien y hacer un context
    public class Controlador
    {
        private readonly string connectionString = "Server=DESKTOP-32F2S83\\SQLEXPRESS;Initial Catalog=NetGenerica;Integrated Security=True;TrustServerCertificate=True";
        
        public Controlador(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Controlador() { }

        public string ConnectionString { get { return connectionString; } }

        public List<Alumno> RecuperarTodos()
        {
            var alumnos = new List<Alumno>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "SELECT * FROM Alumnos";
            SqlCommand comando = new SqlCommand(query, con);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Alumno a = new Alumno();
                a.Id = Convert.ToInt32(reader["Id"]);
                //a.Edad = Convert.ToInt32(reader["Edad"]);
                a.ApellidoNombre = Convert.ToString(reader["ApellidoNombre"]);
                a.Email = Convert.ToString(reader["Email"]);
                a.Dni = Convert.ToString(reader["Dni"]);
                a.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                a.NotaPromedio = Convert.ToDecimal(reader["NotaPromedio"]);
                alumnos.Add(a);
            }
            con.Close();
            return alumnos;
        }

    }
}
