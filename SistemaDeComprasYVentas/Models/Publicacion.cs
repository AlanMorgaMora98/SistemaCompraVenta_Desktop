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
		public int clave_publicacion { get; set; }
		public string nombre { get; set; }
		public string descripcion { get; set; }
		public Categoria categoria { get; set; }
		public double precio { get; set; }
		public int cantidad_disponible { get; set; }
		public double calificacion_general { get; set; }
		public string unidad_medida { get; set; }
		public int numero_ventas { get; set; }
		public string imagen { get; set; }

		public Publicacion()
		{
			clave_publicacion = 0;
			nombre = "";
			descripcion = "";
			categoria = Categoria.tecnologia;
			precio = 0.0f;
			cantidad_disponible = -1;
			calificacion_general = 0.0f;
			unidad_medida = "";
			numero_ventas = 0;
			imagen = "";
		}

		public Publicacion( Publicacion original )
		{
			clave_publicacion = original.clave_publicacion;
			nombre = original.nombre;
			descripcion = original.descripcion;
			categoria = original.categoria;
			precio = original.precio;
			cantidad_disponible = original.cantidad_disponible;
			calificacion_general = original.calificacion_general;
			unidad_medida = original.unidad_medida;
			numero_ventas = original.numero_ventas;
			imagen = original.imagen;
		}

		public Publicacion( int claveIn, string nombreIn, string descripcionIn, Categoria categoriaIn,
							double precioIn, int cantidadIn, double calificacionIn, string unidadIn, 
							int ventasIn, string imagenIn )
		{
			clave_publicacion = claveIn;
			nombre = nombreIn;
			descripcion = descripcionIn;
			categoria = categoriaIn;
			precio = precioIn;
			cantidad_disponible = cantidadIn;
			calificacion_general = calificacionIn;
			unidad_medida = unidadIn;
			numero_ventas = ventasIn;
			imagen = imagenIn;
		}

	}
}
