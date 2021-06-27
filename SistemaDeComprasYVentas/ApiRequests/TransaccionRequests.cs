using SistemaDeComprasYVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class TransaccionRequests
	{
		private string publicacionClaveURL = "http://192.168.1.68:5000/publicaciones/";

		public TransaccionRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< UsuarioPublicacion > RecuperarClaveUsuario( int clavePublicacion, string accessToken )
		{
			string requestURL = publicacionClaveURL + clavePublicacion;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					UsuarioPublicacion usuarioPublicacion = await response.Content.ReadAsAsync< UsuarioPublicacion >();
					return usuarioPublicacion;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
