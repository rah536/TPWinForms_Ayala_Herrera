using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, C.Id, C.Descripcion as CatDescripcion, M.Id, M.Descripcion as MarDescripcion from Articulos as A Inner Join CATEGORIAS as C On A.IdCategoria = C.Id Inner Join MARCAS as M On M.Id = C.Id");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    //aux.Precio = (float)datos.Lector["Precio"];

                    //por composicion hay que crear el objeto marca
                    //aparte, ya que no se crea solo al crear el articulo
                    aux.MarcaArticulo = new Marca();
                    aux.MarcaArticulo.Descripcion = (string)datos.Lector["MarDescripcion"];
                    //aca lo mismo pero con categoria
                    aux.CategoriaArticulo = new Categoria();
                    aux.CategoriaArticulo.Descripcion = (string)datos.Lector["CatDescripcion"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


            
        }
        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, ImagenUrl) values('"+articulo.Codigo+"', '"+articulo.Nombre+"', '"+articulo.Descripcion+"', "+articulo.MarcaArticulo.Id+", "+articulo.CategoriaArticulo.Id+", "+articulo.Precio+", '"+articulo.ImagenUrl+"')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }
    }
}
