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
		private int clave_publicacion;
		private string nombre;
		private string descripcion;
		private Categoria categoria;
		private double precio;
		private int cantidad_disponible;
		private double calificacion_general;
		private string unidad_medida;
		private int numero_ventas;
		private string imagen;

		public int ClavePublicacion
		{
			get => clave_publicacion;
		}
		public string Nombre
		{
			get => nombre;
			set { nombre = value; }
		}
		public string Descripcion
		{
			get => descripcion;
			set { descripcion = value; }
		}
		public Categoria Categoria
		{
			get => categoria;
			set { categoria = value; }
		}
		public double Precio
		{
			get => precio;
			set { precio = value; }
		}
		public int CantidadDisponible
		{
			get => cantidad_disponible;
			set { cantidad_disponible = value; }
		}
		public double CalificacionGeneral
		{
			get => calificacion_general;
			set { calificacion_general = value; }
		}
		public string UnidadMedida
		{
			get => unidad_medida;
			set { unidad_medida = value; }
		}
		public int NumeroVentas
		{
			get => numero_ventas;
			set { numero_ventas = value; }
		}
		public string Imagen
		{
			get => imagen;
			set { imagen = value; }
		}

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
							int ventasIn, string imagenIn)
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
