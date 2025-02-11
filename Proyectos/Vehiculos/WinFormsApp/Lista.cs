using Dominio;

namespace WinFormsApp
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

        private void button1_Click(object sender, EventArgs e)
        {
            // podria mapear el objeto seleccionado dto a un objeto Vehiculo para hacer el alta
            Detalle detalle = new Detalle();
            Vehiculo nuevo = new Vehiculo();
            detalle.Vehiculo = nuevo;
            detalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle();
            VehiculoDto dto = this.SelectedItem();
            Vehiculo vehiculo = this.ToVehiculo(dto);
            detalle.EditMode = true;
            detalle.Vehiculo = vehiculo;
            detalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().Id;
            await VehiculoApiClient.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            VehiculoApiClient client = new VehiculoApiClient();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = await VehiculoApiClient.GetAllAsync();

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

        private VehiculoDto SelectedItem()
        {
            VehiculoDto v;
            v = (VehiculoDto)dataGridView1.SelectedRows[0].DataBoundItem;
            return v;
        }

        // Agrego esto porque lo que se muestra en el dgv es un dto, y lo que tengo que mandar al api es un vehiculo
        private Vehiculo ToVehiculo(VehiculoDto dto)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Id = dto.Id;
            vehiculo.Marca = dto.Marca;
            vehiculo.Modelo = dto.Modelo;
            vehiculo.Patente = dto.Patente;
            vehiculo.Precio = dto.Precio;
            vehiculo.CantidadPuertas = dto.CantidadPuertas;
            vehiculo.TipoPropiedadId = dto.TipoPropiedadId;
            vehiculo.FechaIngreso = dto.FechaIngreso;
            return vehiculo;
        }

    }
}
