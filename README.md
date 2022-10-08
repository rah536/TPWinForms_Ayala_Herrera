SISTEMA DE GESTION DE ARTICULOS CON WINDOWS FORMS.
En esta ocasion, se realizo una aplicacion de escritorio con Windows Forms, la cual realiza un ABM sobre una base de datos.

Dicha base de datos cuenta con tres tablas: Articulos, Categorias y Marcas.

Dentro del proyecto Negocio podra encontrar el script para la creacion de dicha base de datos, con Sql Server.

La estructura de nuestra solucion esta formada por 3 proyectos:

a)Dominio

 Alli se encuentran las clases que representan a las tablas en la base de datos, con sus atributos correspondientes.
b)Negocio

Alli se encuentran las clases que se encargan de manejar la logica de nuestra aplicacion.
c)Vistas (TpWinForms)

 Alli se encuentran las clases que se encargan de interactuar con el usuario (Forms).
La aplicacion permite:

1)Listar artículos

Trae el listado completo de todos los articulos en base de datos, y los muestra en un DataGridView. Ademas carga la imagen
del articulo. Si dicho articulo no posee imagen, se carga una imagen por defecto.
2)Búsqueda de artículos por distintos criterios

Permite filtrar sobre el listado completo de articulos por nombre, categoria y marca.
3)Agregar artículos.

Permite agregar articulos a la base de datos, desde nuestra aplicacion. Tanto la marca como la categoria, apareceran 
en un combobox, en la cual podremos seleccionar la marca y categoria que querramos. El campo precio no permite ingresar
valores que no sean numericos. El campo codigo, nombre y precio son requeridos.
4)Modificar artículos.

Permite modificar articulos, seleccionando previamente el articulo en el listado. Dichas modificaciones impactan en la base de datos.El campo precio no permite ingresar
valores que no sean numericos. El campo codigo, nombre y precio son requeridos.
5)Eliminar artículos.

Permite eliminar articulos, seleccionando previamente el articulo en el listado. Se elimina el registro de manera fisica
en la base de datos.
6)Ver detalle de un artículo.

Permite ver todos los datos de un articulo seleccionado en la lista de articulos, incluyendo todos los datos de marca
y categoria de dicho articulo.
