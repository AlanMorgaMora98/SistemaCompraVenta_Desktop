using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Enumerations;

namespace SistemaDeComprasYVentas.Models
{
	public class Publicacion
	{
		public int Clave_Publicacion { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public Categoria Categoria { get; set; }
		public double Precio { get; set; }
		public int Cantidad_Disponible { get; set; }
		public double Calificacion_General { get; set; }
		public string Unidad_Medida { get; set; }
		public int Numero_Ventas { get; set; }
		public string Imagen { get; set; }

		public Publicacion()
		{
			Clave_Publicacion = 0;
			Nombre = "";
			Descripcion = "";
			Categoria = Categoria.tecnologia;
			Precio = 0.0f;
			Cantidad_Disponible = -1;
			Calificacion_General = 0.0f;
			Unidad_Medida = "";
			Numero_Ventas = 0;
			Imagen = "";
		}

		public Publicacion( Publicacion original )
		{
			Clave_Publicacion = original.Clave_Publicacion;
			Nombre = original.Nombre;
			Descripcion = original.Descripcion;
			Categoria = original.Categoria;
			Precio = original.Precio;
			Cantidad_Disponible = original.Cantidad_Disponible;
			Calificacion_General = original.Calificacion_General;
			Unidad_Medida = original.Unidad_Medida;
			Numero_Ventas = original.Numero_Ventas;
			Imagen = original.Imagen;
		}

		public Publicacion( int claveIn, string nombreIn, string descripcionIn, Categoria categoriaIn,
							double precioIn, int cantidadIn, double calificacionIn, string unidadIn, 
							int ventasIn, string imagenIn)
		{
			Clave_Publicacion = claveIn;
			Nombre = nombreIn;
			Descripcion = descripcionIn;
			Categoria = categoriaIn;
			Precio = precioIn;
			Cantidad_Disponible = cantidadIn;
			Calificacion_General = calificacionIn;
			Unidad_Medida = unidadIn;
			Numero_Ventas = ventasIn;
			Imagen = imagenIn;
		}

	}
}
