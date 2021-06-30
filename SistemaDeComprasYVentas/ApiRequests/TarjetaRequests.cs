using SistemaDeComprasYVentas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public async Task< ObservableCollection< Tarjeta > > RecuperarTarjetasUsuario( int claveUsuario, string accessToken )
		{
			string requestURL = tarjetasGeneralURL + "/" + claveUsuario + "/tarjetas";
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					ObservableCollection< Tarjeta > tarjetas = await response.Content.ReadAsAsync< ObservableCollection< Tarjeta > >();
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
