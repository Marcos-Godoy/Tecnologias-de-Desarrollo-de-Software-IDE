using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace WinFormsApp
{
    public partial class Detalle : Form
    {
        private Vehiculo vehiculo;

        public bool EditMode { get; set; } = false;
        public Vehiculo Vehiculo
        {   get { return vehiculo; }
            set 
            {
                vehiculo = value;
                this.SetVehiculo();   
            }
        }

        public async void SetVehiculo()
        {
            // Lleno el ComboBox
            var tipoPropiedades = await TipoPropiedadApiClient.GetAllAsync();
            // Mostrar la descripción en el ComboBox
            this.comboBox1.DisplayMember = "Descripcion";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DataSource = tipoPropiedades;
            if (this.EditMode)
            {
                comboBox1.SelectedValue = vehiculo.TipoPropiedadId;
                textBox2.Text = vehiculo.Marca;
                textBox3.Text = vehiculo.Modelo;
                textBox4.Text = vehiculo.Patente;
                textBox5.Text = vehiculo.Precio.ToString();
                textBox1.Text = vehiculo.CantidadPuertas.ToString();
            }
        }
        public Detalle()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                this.vehiculo.Precio = Convert.ToDecimal(this.textBox5.Text);
                this.vehiculo.Marca = this.textBox2.Text;
                this.vehiculo.CantidadPuertas = Convert.ToInt32(this.textBox1.Text);
                this.vehiculo.Modelo = this.textBox3.Text;
                this.vehiculo.Patente = this.textBox4.Text;
                this.vehiculo.TipoPropiedadId = Convert.ToInt32(this.comboBox1.SelectedValue);
                if (this.EditMode)
                {
                    await VehiculoApiClient.UpdateAsync(this.vehiculo);
                }
                else
                {
                    //this.propiedad.FechaAlta = DateTime.Now;
                    await VehiculoApiClient.AddAsync(this.vehiculo);
                }
                this.Close();
            }
        }
    }
}
