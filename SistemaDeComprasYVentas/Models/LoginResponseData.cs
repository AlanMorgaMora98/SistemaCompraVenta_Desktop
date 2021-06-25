using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class LoginResponseData
	{
		public int clave_usuario { get; set; }
		public string access_token { get; set; }

		public LoginResponseData()
		{
			clave_usuario = -1;
			access_token = "";
		}

		public LoginResponseData( LoginResponseData original )
		{
			clave_usuario = original.clave_usuario;
			access_token = original.access_token;
		}

		public LoginResponseData( int claveIn, string accessIn )
		{
			clave_usuario = claveIn;
			access_token = accessIn;
		}
	}
}
