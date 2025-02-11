using Negocio;
using Entidades;

namespace Escritorio
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }

        private async void GetAllAndLoad()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = await Negocio.Negocio.GetAll();
        }

        private Alumno SelectedItem()
        {
            Alumno entidad;
            entidad = (Alumno)dataGridView1.SelectedRows[0].DataBoundItem;
            return entidad;
        }

        private void Lista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        // Agregar
        private void button1_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle();
            Alumno nuevo = new Alumno();
            detalle.Alumno = nuevo;
            detalle.ShowDialog();
            GetAllAndLoad();
        }

        // Modificar
        private void button2_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle();
            detalle.EditMode = true;
            detalle.Alumno = SelectedItem();
            detalle.ShowDialog();
            GetAllAndLoad();
        }

        // Eliminar
        private async void button3_Click(object sender, EventArgs e)
        {
            await Negocio.Negocio.Delete(SelectedItem());
            GetAllAndLoad();
        }
    }
}
