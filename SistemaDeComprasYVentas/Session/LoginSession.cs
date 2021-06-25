using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Models;

namespace SistemaDeComprasYVentas.Session
{
	class LoginSession
	{
		private static LoginSession loginInstance;
		public Usuario Usuario { get; set; }
		public int ClaveUsuario { get; set; }
		public string AccessToken { get; set; }
		public bool IsLoggedIn
		{
			get { return ClaveUsuario > -1; }
		}


		private LoginSession()
		{
			Usuario = null;
			ClaveUsuario = -1;
			AccessToken = "";
		}

		public static LoginSession GetInstance()
		{
			if( loginInstance == null )
			{
				loginInstance = new LoginSession();
			}
			return loginInstance;
		}

		public void Logout()
		{
			if( IsLoggedIn )
			{
				ClaveUsuario = -1;
				AccessToken = "";
				Usuario = null;
			}
		}

		public void Login( int claveIn, string tokenIn )
		{
			if( !IsLoggedIn && ClaveUsuario == -1 )
			{
				ClaveUsuario = claveIn;
				AccessToken = tokenIn;
			}
		}
	}
}
