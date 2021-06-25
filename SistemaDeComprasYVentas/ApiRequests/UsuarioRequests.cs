using Newtonsoft.Json;
using SistemaDeComprasYVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class UsuarioRequests
	{
		private string usuarioGeneralURL = "http://192.168.1.68:5000/usuarios";

		public UsuarioRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< Usuario > RegistrarUsuario( Usuario usuario )
		{
			var json = JsonConvert.SerializeObject( usuario );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			using ( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( usuarioGeneralURL, data ) )
			{
				if( response.IsSuccessStatusCode )
				{
					Usuario respuesta = await response.Content.ReadAsAsync< Usuario >();
					Console.WriteLine( respuesta.clave_usuario );
					return respuesta;
				}
				else
				{
					Console.WriteLine( response.Content.ReadAsStringAsync() );
					return null;
				}
			}
		}
	}
}
