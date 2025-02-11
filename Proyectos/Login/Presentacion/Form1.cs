namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool resultado = await UsuarioApiClient.ValidarAsync(textBox1.Text, textBox2.Text);
            if (resultado)
            {
                MessageBox.Show("Usuario v�lido");
            }
            else
            {
                MessageBox.Show("Usuario inv�lido");
            }
        }
    }
}
