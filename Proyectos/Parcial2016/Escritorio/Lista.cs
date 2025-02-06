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
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno alumnoSeleccionado = (Alumno)comboBox1.SelectedItem;
            MessageBox.Show($"Alumno seleccionado: {alumnoSeleccionado.ApellidoNombre}, ID: {alumnoSeleccionado.Id}, Email: {alumnoSeleccionado.Email}");
        }

        private void Lista_Load(object sender, EventArgs e)
        {
            var alumnos = new List<Alumno>();
            alumnos = new Negocio.AlumnoNegocio().RecuperarTodos();
            comboBox1.DataSource = alumnos;
            comboBox1.DisplayMember = "ApellidoNombre";
            comboBox1.ValueMember = "Id";
        }
    }
}
