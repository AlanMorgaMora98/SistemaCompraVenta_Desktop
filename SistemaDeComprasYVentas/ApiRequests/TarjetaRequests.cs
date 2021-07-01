using Newtonsoft.Json;
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

		public async Task<Tarjeta> EliminarTarjeta(int claveUsuario, int claveTarjeta, string accessToken)
		{
			string requestURL = tarjetasGeneralURL + "/" + claveUsuario + "/tarjetas/" + claveTarjeta;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(requestURL))
			{
				if (response.IsSuccessStatusCode)
				{
					Tarjeta respuesta = await response.Content.ReadAsAsync<Tarjeta>();
					return respuesta;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task<Tarjeta> RegistrarTarjeta(int claveUsuario, string accessToken, Tarjeta tarjeta)
		{
			string requestURL = tarjetasGeneralURL + "/" + claveUsuario + "/tarjetas";
			var json = JsonConvert.SerializeObject(tarjeta);
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(requestURL, data))
			{
				if (response.IsSuccessStatusCode)
				{
					Tarjeta respuesta = await response.Content.ReadAsAsync<Tarjeta>();
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
