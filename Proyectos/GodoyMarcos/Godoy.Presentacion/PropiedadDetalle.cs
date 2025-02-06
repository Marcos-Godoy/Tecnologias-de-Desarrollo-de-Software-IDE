using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Godoy.Domain;

namespace Godoy.Presentacion
{
    public partial class PropiedadDetalle : Form
    {
        private Propiedad propiedad;
        public bool EditMode { get; set; } = false;

        public Propiedad Propiedad
        {
            get { return propiedad; }
            set
            {
                propiedad = value;
                this.SetPropiedad();
            }
        }

        public async void SetPropiedad()
        {
            // Lleno el ComboBox
            var tipoPropiedades = await TipoPropiedadApiClient.GetAllAsync();
            // Mostrar la descripción en el ComboBox
            this.comboBox1.DisplayMember = "Descripcion";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DataSource = tipoPropiedades;
            if (this.EditMode)
            {
                this.numericUpDown3.Value = this.propiedad.Precio;
                this.numericUpDown2.Value = this.propiedad.M2;
                this.numericUpDown1.Value = this.propiedad.CantidadHabitaciones;
                this.textBox2.Text = this.propiedad.Titulo;
                this.textBox3.Text = this.propiedad.Descripcion;
                this.labelFecha.Text = Convert.ToString(this.propiedad.FechaAlta);
            }
        }
        public PropiedadDetalle()
        {
            InitializeComponent();
        }

        // Boton CANCELAR
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Boton Aceptar
        private async void button1_Click(object sender, EventArgs e)
        {
            PropiedadApiClient client = new PropiedadApiClient();
            if(this.Validate())
            {
                this.propiedad.Precio = this.numericUpDown3.Value;
                this.propiedad.M2 = Convert.ToInt32(this.numericUpDown2.Value);
                this.propiedad.CantidadHabitaciones = Convert.ToInt32(this.numericUpDown1.Value);
                this.propiedad.Titulo = this.textBox2.Text;
                this.propiedad.Descripcion = this.textBox3.Text;
                this.propiedad.IdTipoPropiedad = Convert.ToInt32(this.comboBox1.SelectedValue);
                if (this.EditMode)
                {
                    await PropiedadApiClient.UpdateAsync(this.propiedad);
                }
                else
                {
                    this.propiedad.FechaAlta = DateTime.Now;
                    await PropiedadApiClient.AddAsync(this.propiedad);
                }
                this.Close();
            }          
        }

        private async void PropiedadDetalle_Load(object sender, EventArgs e)
        {
            /*
            var tipoPropiedades = await TipoPropiedadApiClient.GetAllAsync();
            // Mostrar la descripción en el ComboBox
            this.comboBox1.DisplayMember = "Descripcion";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DataSource = tipoPropiedades;
            */
        }

        // Esto podria hacerse en el metodo Add del Dominio (PropiedadService)
        private bool Validate()
        {
            // validar descripcion
            if(this.textBox3.Text == string.Empty)
            {
                MessageBox.Show("La descripción es requerida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // validar titulo
            if(this.textBox2.Text.Length > 50)
            {
                MessageBox.Show("El titulo no puede tener mas de 50 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.numericUpDown1.Value < 0 || this.numericUpDown1.Value > 10)
            {
                MessageBox.Show("El valor debe estar entre 0 y 10", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Comprobar si el valor tiene decimales
            if (this.numericUpDown1.Value != Math.Floor(this.numericUpDown1.Value))
            {
                MessageBox.Show("El valor debe ser un número entero sin decimales", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
