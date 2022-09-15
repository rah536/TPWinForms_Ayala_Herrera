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

namespace WindowsFormsApp1
{
    public partial class VerDetalle : Form
    {
        public VerDetalle()
        {
            InitializeComponent();
        }
        public void cargarDetalles(Articulo articulo)
        {
            lblIdArticulo.Text = articulo.Id.ToString();
            lblCodigoArticulo.Text = articulo.Codigo.ToString();
            lblNombreArticulo.Text = articulo.Nombre.ToString();
            lblDescripcionArticulo.Text = articulo.Descripcion.ToString();
            lblIdMarcaArticulo.Text = articulo.MarcaArticulo.Id.ToString();
            lblMarcaArticulo.Text = articulo.MarcaArticulo.Descripcion.ToString();
            lblIdCategoriaArticulo.Text = articulo.CategoriaArticulo.Id.ToString();
            lblCategoriaArticulo.Text = articulo.CategoriaArticulo.Descripcion.ToString();
            lblPrecioArticulo.Text = articulo.Precio.ToString();
            cargarImagen(articulo.ImagenUrl);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbUrlImagen.Load(imagen);
            }
            catch (Exception)
            {

                pbUrlImagen.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }


    }
}
