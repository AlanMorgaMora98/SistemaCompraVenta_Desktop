using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class LoginResponseData
	{
		public int Clave_Usuario { get; set; }
		public string Access_Token { get; set; }

		public LoginResponseData()
		{
			Clave_Usuario = -1;
			Access_Token = "";
		}

		public LoginResponseData( LoginResponseData original )
		{
			Clave_Usuario = original.Clave_Usuario;
			Access_Token = original.Access_Token;
		}

		public LoginResponseData( int claveIn, string accessIn )
		{
			Clave_Usuario = claveIn;
			Access_Token = accessIn;
		}
	}
}
