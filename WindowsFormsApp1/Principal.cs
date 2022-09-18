using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listado ventana = new Listado();
            //ventana.MdiParent = this;
            ventana.ShowDialog();
        }

      

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar ventana = new Agregar();
            //dejar comentado! , debe abrir formulario fuera del principal
            //ventana.MdiParent = this;
            ventana.ShowDialog();
            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
