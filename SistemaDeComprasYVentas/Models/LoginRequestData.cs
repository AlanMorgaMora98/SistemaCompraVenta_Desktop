using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class LoginRequestData
	{
		public string Nombre_Usuario { get; set; }
		public string Contrasena { get; set; }

		public LoginRequestData()
		{
			Nombre_Usuario = "";
			Contrasena = "";
		}

		public LoginRequestData( LoginRequestData original )
		{
			Nombre_Usuario = original.Nombre_Usuario;
			Contrasena = original.Contrasena;
		}

		public LoginRequestData( string nombreIn, string contrasenaIn )
		{
			Nombre_Usuario = nombreIn;
			Contrasena = contrasenaIn;
		}
	}
}
