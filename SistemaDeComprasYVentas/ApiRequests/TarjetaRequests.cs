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
	public class TarjetaRequests
	{
		private string tarjetasGeneralURL = "http://192.168.1.68:5000/usuarios";

		public TarjetaRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< List< Tarjeta > > RecuperarTarjetasUsuario( int claveUsuario, string accessToken )
		{
			string requestURL = tarjetasGeneralURL + "/" + claveUsuario;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					List< Tarjeta > tarjetas = await response.Content.ReadAsAsync< List< Tarjeta > >();
					return tarjetas;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
