using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad_3___Laboratorio_1
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /*
        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }

        }
        */
        // permite con el showdialog que no se pueda interatctuar con otros forms
        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
        //En el método btnIngresar_Click del formLogin habíamos hecho que al registrarse correctamente el resultado del formulario(DialogResult) fuera OK entonces cualquier otro resultado significa que el usuario no se ha registrado correctamente.



        private void formMain_Load(object sender, EventArgs e)
        {

        }
    }
}
