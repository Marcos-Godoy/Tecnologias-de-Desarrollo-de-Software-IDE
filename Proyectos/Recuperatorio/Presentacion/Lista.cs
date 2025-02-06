using Domain;

namespace Presentacion
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }

        private void Lista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = await ProductoApiClient.GetAllAsync();
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

        private Producto SelectedItem()
        {
            Producto p;
            p = (Producto)dataGridView1.SelectedRows[0].DataBoundItem;
            return p;
        }

        // Boton Agregar
        private void button1_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle();
            Producto nuevo = new Producto();
            detalle.Producto = nuevo;
            detalle.ShowDialog();
            this.GetAllAndLoad();
        }

        // Boton Modificar
        private async void button2_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle();
            int id = this.SelectedItem().Id;
            Producto producto = await ProductoApiClient.GetAsync(id);
            detalle.EditMode = true;
            detalle.Producto = producto;
            detalle.ShowDialog();
            this.GetAllAndLoad();
        }

        // Boton Eliminar
        private async void button3_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().Id;
            await ProductoApiClient.DeleteAsync(id);
            this.GetAllAndLoad();
        }
    }
}
