using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace WindowsForms
{
    public partial class ClienteDetalle : Form
    {
        private Cliente cliente;
        public Cliente Cliente
        {
            get { return cliente; }
            set 
                { cliente = value;
                this.SetCliente();
            }
        }
        public bool EditMode { get; set; } = false;
        public ClienteDetalle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // cancelar
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e) // aceptar
        {
            ClienteApiClient client = new ClienteApiClient();
            if (this.ValidateCliente())
            {
                this.Cliente.Nombre = textBox1.Text;
                if (this.EditMode)
                {
                    await ClienteApiClient.UpdateAsync(this.Cliente);
                }
                else
                {
                    await ClienteApiClient.AddAsync(this.Cliente);
                }
                this.Close();
            }
        }

        private void SetCliente()
        {
            this.textBox1.Text = this.Cliente.Nombre;
        }

        private bool ValidateCliente()
        {
            bool isValid = true;
            errorProvider1.SetError(textBox1, string.Empty);
            if (this.textBox1.Text == string.Empty || this.textBox1.Text.Length > 50)
            {
                isValid = false;
                errorProvider1.SetError(textBox1, "El Nombre es Requerido o pusiste algo muy largo");
            }
            return isValid;
        }
    }
}
