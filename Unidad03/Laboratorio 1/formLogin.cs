using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad_3___Laboratorio_1
{
    public partial class formLogin : Form
    {
        /* propiedades del formlogin:
         MaximizeBox (Botón de maximizar): False
•	MinimizeBox (Botón de minimizar): False
•	FormBorderStyle (Estilo del borde del formulario): FixedSingle
•	StartPosition (Posición inicial): CenterParent
*/

        /*14)	Tercer objetivo lograr que el Enter ejecute la acción por defecto deseada en este caso lo mismo que clic en el btnIngresar.
Para ello en las propiedades del frmLogin en AcceptButton elegimos el botón btnIngresar. */
        public formLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //para que se cierre automaticamente cuando terminee
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (this.txtUsuario.Text == "Admin" && this.txtContraseña.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*12)	Ahora cuando el usuario se registra correctamente se setea la propiedad DialogResult del formulario. 
         * Cuando se setea dicha propiedad en un formulario que se mostró con el método DialogResult el formulario se cierra automáticamente. 
         * Adicionalmente el método ShowDialog con el cual se mostró el formLogin devuelve el valor que se le asigna a la propiedad DialogResult del formulario. 
         * Por defecto al cerrar el formulario desde la cruz la respuesta es DialogResult.Cancel.*/

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
