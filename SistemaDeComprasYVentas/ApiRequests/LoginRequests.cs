using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class LoginRequests
	{
		private string loginURL = "http://201.105.180.242:5000/login";

		public LoginRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< LoginResponseData > RealizarLogin( string nombre_usuario, string contrasena )
		{
			var json = JsonConvert.SerializeObject( new LoginRequestData( nombre_usuario, contrasena ) );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			using ( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( loginURL, data ) )
			{
				if( response.IsSuccessStatusCode )
				{
					LoginResponseData respuesta = await response.Content.ReadAsAsync< LoginResponseData >();
					return respuesta;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
