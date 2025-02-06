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
        private Alumno alumno;

        public bool EditMode { get; set; } = false;
        public Alumno Alumno
        {
            get { return alumno; }
            set
            {
                alumno = value;
                if (EditMode)
                {
                    textBox1.Text = alumno.DNI;
                    textBox2.Text = alumno.ApellidoNombre;
                    textBox3.Text = alumno.Email;
                    dateTimePicker1.Value = alumno.FechaNacimiento;
                    numericUpDown1.Value = (decimal)alumno.NotaPromedio;
                }
            }
        }
        public Detalle()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            alumno.DNI = textBox1.Text;
            alumno.ApellidoNombre = textBox2.Text;
            alumno.Email = textBox3.Text;
            alumno.FechaNacimiento = dateTimePicker1.Value;
            alumno.NotaPromedio = (decimal)numericUpDown1.Value;
            if(EditMode)
            {
                await Negocio.AlumnoNegocio.Update(alumno);
            }
            else
            {
                await Negocio.AlumnoNegocio.Add(alumno);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
