namespace Escritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            lista.ShowDialog();
        }
    }
}
