using Godoy.Domain;

namespace Godoy.Presentacion
{
    public partial class PropiedadLista : Form
    {
        public PropiedadLista()
        {
            InitializeComponent();
        }

        // Busca todos las entidades y las carga en el dgv
        private async void GetAllAndLoad()
        {
            PropiedadApiClient client = new PropiedadApiClient();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = await PropiedadApiClient.GetAllAsync();

            if (this.dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.Rows[0].Selected = true;
                this.button3.Enabled = true;
                this.button2.Enabled = true;
            }
            else
            {
                this.button3.Enabled = false;
                this.button2.Enabled = false;
            }
        }

        // Devuelve el objeto seleccionado en el dgv
        private Propiedad SelectedItem()
        {
            Propiedad propiedad;
            propiedad = (Propiedad)dataGridView1.SelectedRows[0].DataBoundItem;
            return propiedad;
        }

        // Boton de Eliminar
        private async void button3_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().Id;
            await PropiedadApiClient.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        // Boton de alta
        private async void button1_Click(object sender, EventArgs e)
        {
            PropiedadDetalle propiedadDetalle = new PropiedadDetalle();
            Propiedad propiedadNuevo = new Propiedad();
            propiedadDetalle.Propiedad = propiedadNuevo;
            propiedadDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        // Boton de Modificacion
        private async void button2_Click(object sender, EventArgs e)
        {
            PropiedadDetalle propiedadDetalle = new PropiedadDetalle();
            int id = this.SelectedItem().Id;
            Propiedad propiedad = await PropiedadApiClient.GetAsync(id);
            propiedadDetalle.EditMode = true;
            propiedadDetalle.Propiedad = propiedad;
            propiedadDetalle.ShowDialog();
            this.GetAllAndLoad();

        }
        private void PropiedadLista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
    }
}
