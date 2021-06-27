using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class UsuarioPublicacion
	{
		public int clave_publicacion_publicacion { get; set; }
		public int clave_usuario_usuario { get; set; }

		public UsuarioPublicacion()
		{
			clave_publicacion_publicacion = -1;
			clave_usuario_usuario = -1;
		}

		public UsuarioPublicacion( UsuarioPublicacion original )
		{
			clave_publicacion_publicacion = original.clave_publicacion_publicacion;
			clave_usuario_usuario = original.clave_usuario_usuario;
		}

		public UsuarioPublicacion( int clavePublicacionIn, int claveUsuarioIn )
		{
			clave_publicacion_publicacion = clavePublicacionIn;
			clave_usuario_usuario = claveUsuarioIn;
		}
	}
}
