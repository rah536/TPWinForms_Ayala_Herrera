using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WindowsFormsApp1
{
    public partial class Listado : Form
    {
        private List<Articulo> listaArticulos;
        public Listado()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //cambiar nombre de menu_load a Listado_Load -
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                cargarImagen(listaArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns[0].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            //dgvArticulos.Columns[1].Visible = false;
            dgvArticulos.Columns["Precio"].Visible = false;

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.ImagenUrl);
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulos.Load(imagen);
            }
            catch (Exception)
            {

                pbxArticulos.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;

            if (txtFiltro.Text != "")
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Codigo.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.CategoriaArticulo.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.MarcaArticulo.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            }
            else 
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;

            if (txtFiltro.Text.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Codigo.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.CategoriaArticulo.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.MarcaArticulo.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Desea eliminar el registro?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargarGrilla();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            Agregar modificar = new Agregar(seleccionado);

                //ventana.MdiParent = this;
                modificar.ShowDialog();

            
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            VerDetalle detalle = new VerDetalle();
            detalle.cargarDetalles(seleccionado);
            detalle.ShowDialog();
            
        }
    }
}
