using System.Windows.Forms;

namespace AcademiaABM
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            // no se si es Usuario o Usuarios, tendria sentido q sea una clase nueva
            List<Usuario1> listaUsuarios = new List<Usuario1>();
            listaUsuarios.Add(new Usuario1(1, "Lionel", "Messi", "lio10", "liomessi.com", true));
            listaUsuarios.Add(new Usuario1(2, "Angel", "Di Maria", "ad0", "adm.com", true));
            listaUsuarios.Add(new Usuario1(3, "Lautaro", "Martinez", "lm10", "lm.com", true));

            // Limpiar los datos existentes en la grilla
            dgvUsuarios.Rows.Clear();

            // Agregar cada usuario a la grilla
            foreach (var usuario in listaUsuarios)
            {
                dgvUsuarios.Rows.Add(usuario.ID, usuario.Nombre, usuario.Apellido, usuario.Usuario, usuario.EMail, usuario.Habilitado);
            }
        }

        private void Usuarios_Load(object sender, System.EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
