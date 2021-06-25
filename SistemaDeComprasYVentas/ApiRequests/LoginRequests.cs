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
		private string loginURL = "http://192.168.1.68:5000/login";

		public LoginRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< LoginResponseData > RealizarLogin( string nombre_usuario, string contrasena )
		{
			using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( loginURL,
												  new StringContent( JsonConvert.SerializeObject(
												  new LoginRequestData( nombre_usuario, contrasena ) ) ) ) )
			{
				if( response.IsSuccessStatusCode )
				{
					LoginResponseData respuesta = await response.Content.ReadAsAsync< LoginResponseData >();
					Console.WriteLine( respuesta.Clave_Usuario );
					Console.WriteLine( respuesta.Access_Token );
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
