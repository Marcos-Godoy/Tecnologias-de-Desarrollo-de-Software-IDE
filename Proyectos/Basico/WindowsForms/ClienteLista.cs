using Domain;

namespace WindowsForms
{
    public partial class ClienteLista : Form
    {
        public ClienteLista()
        {
            InitializeComponent();
        }

        private void ClienteLista_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            ClienteApiClient client = new ClienteApiClient();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = await ClienteApiClient.GetAllAsync();
            if (this.dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.Rows[0].Selected = true;
                this.button1.Enabled = true;
                this.button2.Enabled = true;
            }
            else
            {
                this.button1.Enabled = false;
                this.button2.Enabled = false;
            }
        }

        private async void button1_Click(object sender, EventArgs e) // elim
        {
            int id;
            id = this.SelectedItem().Id;
            await ClienteApiClient.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void button2_Click(object sender, EventArgs e) // modificar
        {
            ClienteDetalle clienteDetalle = new ClienteDetalle();
            int id;
            id = this.SelectedItem().Id;
            Cliente cliente = await ClienteApiClient.GetAsync(id);
            clienteDetalle.EditMode = true;
            clienteDetalle.Cliente = cliente;
            clienteDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void button3_Click(object sender, EventArgs e) // agregar
        {
            ClienteDetalle clienteDetalle = new ClienteDetalle();
            Cliente clienteNuevo = new Cliente();
            clienteDetalle.Cliente = clienteNuevo;
            clienteDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private Cliente SelectedItem()
        {
            Cliente cliente;
            cliente = (Cliente)dataGridView1.SelectedRows[0].DataBoundItem;
            return cliente;
        }
    }
}
