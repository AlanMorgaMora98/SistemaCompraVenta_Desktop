using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class DomicilioRequests
	{
		private string usuarioGeneralURL = "http://192.168.1.68:5000/usuarios";

		public DomicilioRequests()
		{
			ApiHelper.InitializeClient();
		}

		public Task< Domicilio > RecuperarDomiciliosUsuario( int claveUsuario, string accessToken )
		{

		}
	}
}
