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
    public partial class Agregar : Form
    {

        private Articulo articulo = null;
        public Agregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar articulo";
        }

        

        public Agregar()
        {
            InitializeComponent();
            Text = " Agregar articulo ";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //es el boton CANCELAR
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           // Articulo articulo = new Articulo();

            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {


                if (validaciones() == true)
                {
                    if (articulo == null) { articulo = new Articulo(); }

                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.MarcaArticulo = (Marca)cboMarca.SelectedItem;
                    articulo.CategoriaArticulo = (Categoria)cboCategoria.SelectedItem;
                    articulo.Precio = float.Parse(txtPrecio.Text);
                    articulo.ImagenUrl = txtImagenUrl.Text;
                }

                else
                {
                    MessageBox.Show("Compruebe que los campos obligatorios esten completos");
                }

                if(articulo.Id != 0 && validaciones() == true)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    MessageBox.Show("Compruebe que los campos obligatorios esten completos");
                }
                if (articulo.Id == 0 && validaciones() == true )
                { 
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("Compruebe que los campos obligatorios esten completos");
                }
                Close();
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Agregar_Load(object sender, EventArgs e)

        {
            
                MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
          
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {

                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);
                    txtPrecio.Text = articulo.Precio.ToString();
                    cboMarca.SelectedValue = articulo.MarcaArticulo.Id;
                    cboCategoria.SelectedValue = articulo.CategoriaArticulo.Id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbAgregar.Load(imagen);
            }
            catch (Exception)
            {

                pbAgregar.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }

        private bool validaciones()
        {
            if(string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                return false;
            }

            foreach (char item in txtPrecio.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Ingresa un valor numerico");
                    return false;
                }
            }
            return true;

        }

        private void txtPrcio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
