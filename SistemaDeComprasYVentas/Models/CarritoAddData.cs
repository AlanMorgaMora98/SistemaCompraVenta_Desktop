using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class CarritoAddData
	{
		public int clave_usuario_usuario { get; set; }
		public int clave_producto_producto { get; set; }

		public CarritoAddData()
		{
			clave_usuario_usuario = -1;
			clave_producto_producto = -1;
		}

		public CarritoAddData( CarritoAddData original )
		{
			clave_usuario_usuario = original.clave_usuario_usuario;
			clave_producto_producto = original.clave_producto_producto;
		}

		public CarritoAddData( int usuarioClaveIn, int publicacionClaveIn )
		{
			clave_usuario_usuario = usuarioClaveIn;
			clave_producto_producto = publicacionClaveIn;
		}
	}
}
