using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class Detalle : Form
    {
        private Alumno entidad;

        public bool EditMode { get; set; } = false;
        public Alumno Alumno
        {
            get { return entidad; }
            set
            {
                entidad = value;
                if (EditMode)
                {
                    textBox1.Text = entidad.DNI;
                    textBox2.Text = entidad.ApellidoNombre;
                    textBox3.Text = entidad.Email;
                    dateTimePicker1.Value = entidad.FechaNacimiento;
                    numericUpDown1.Value = (decimal)entidad.NotaPromedio;
                }
            }
        }
        public Detalle()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            entidad.DNI = textBox1.Text;
            entidad.ApellidoNombre = textBox2.Text;
            entidad.Email = textBox3.Text;
            entidad.FechaNacimiento = dateTimePicker1.Value;
            entidad.NotaPromedio = (decimal)numericUpDown1.Value;
            if(EditMode)
            {
                await Negocio.Negocio.Update(entidad);
            }
            else
            {
                await Negocio.Negocio.Add(entidad);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
