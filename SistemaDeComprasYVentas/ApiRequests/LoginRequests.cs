using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Utilities;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class LoginRequests
	{
		private OutputMessages messages;
		private string loginURL = "http://192.168.1.68:5000/login";

		public LoginRequests()
		{
			ApiHelper.InitializeClient();
			messages = new OutputMessages();
		}

		public async Task< LoginResponseData > RealizarLogin( string nombre_usuario, string contrasena )
		{
			try
			{
				var json = JsonConvert.SerializeObject( new LoginRequestData( nombre_usuario, contrasena ) );
				var data = new StringContent( json, Encoding.UTF8, "application/json" );
				using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( loginURL, data ) )
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
			} catch( Exception )
			{
				MessageBox.Show( messages.NoHayConexionAlServido(), messages.SinConexionTitle() );
				return null;
			}
		}
	}
}
