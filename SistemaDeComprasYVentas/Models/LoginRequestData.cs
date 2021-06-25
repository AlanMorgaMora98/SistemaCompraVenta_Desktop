using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class LoginRequestData
	{
		public string username { get; set; }
		public string password { get; set; }

		public LoginRequestData()
		{
			username = "";
			password = "";
		}

		public LoginRequestData( LoginRequestData original )
		{
			username = original.username;
			password = original.password;
		}

		public LoginRequestData( string nombreIn, string contrasenaIn )
		{
			username = nombreIn;
			password = contrasenaIn;
		}
	}
}
