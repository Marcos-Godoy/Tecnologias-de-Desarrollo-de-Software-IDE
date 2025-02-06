using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Detalle : Form
    {
        private Producto producto;
        public bool EditMode { get; set; } = false;
        public Producto Producto
        {
            get { return producto; }
            set { producto = value;
                this.SetProducto();
            }
        }
        public Detalle()
        {
            InitializeComponent();
        }

        private void SetProducto()
        {
            if (this.EditMode)
            {                
                this.textBox1.Text = this.producto.Codigo;
                this.textBox2.Text = this.producto.Descripcion;
                this.textBox3.Text = Convert.ToString(this.producto.Precio);
                this.label4.Text = "Editar Producto " + this.producto.Id;
            } else
            {
                this.label4.Text = "Agregar Producto";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                this.producto.Codigo = this.textBox1.Text;
                this.producto.Descripcion = this.textBox2.Text;
                this.producto.Precio = Convert.ToDecimal(this.textBox3.Text);
                if(this.EditMode)
                {
                    await ProductoApiClient.UpdateAsync(producto);
                } else
                {
                    await ProductoApiClient.AddAsync(producto);
                }
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            if (textBox2.Text.Length > 50)
            {
                MessageBox.Show("La descripcion no puede tener mas de 50 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDecimal(textBox3.Text) <= 0)
            {
                MessageBox.Show("El precio tiene que ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Validar que el código cumpla las reglas
            string codigo = textBox1.Text;
            if (codigo.Length != 4)
            {
                MessageBox.Show("El código debe tener exactamente 4 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (codigo[0] != 'A')
            {
                MessageBox.Show("El código debe comenzar con la letra 'A'", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            for (int i = 1; i < codigo.Length; i++)
            {
                if (!char.IsDigit(codigo[i]))
                {
                    MessageBox.Show("Los últimos 3 caracteres del código deben ser números", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
    }
}
