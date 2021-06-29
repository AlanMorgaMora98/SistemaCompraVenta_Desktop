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
	public class DomicilioRequests
	{
		private string domicilioURL = "http://192.168.56.1:5000/usuarios";

		public DomicilioRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< List< Domicilio > > RecuperarDomiciliosUsuario2( int claveUsuario, string accessToken )
		{
			string requestURL = domicilioURL + "/" + claveUsuario;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					List< Domicilio > domicilios = await response.Content.ReadAsAsync< List< Domicilio > >();
					return domicilios;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task< Domicilio > RegistrarDomicilio( int claveUsuario, string accessToken, Domicilio domicilio )
		{
			string requestURL = domicilioURL + "/" + claveUsuario + "/domicilios";
			var json = JsonConvert.SerializeObject( domicilio );
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( requestURL, data ) )
			{
				if( response.IsSuccessStatusCode )
				{
					Domicilio respuesta = await response.Content.ReadAsAsync< Domicilio >();
					return respuesta;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task< Domicilio > EliminarDomicilio( int claveUsuario, int discriminanteDomicilio, string accessToken )
		{
			string requestURL = domicilioURL + "/" + claveUsuario + "/domicilios/" + discriminanteDomicilio;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					Domicilio respuesta = await response.Content.ReadAsAsync< Domicilio >();
					return respuesta;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task< ObservableCollection< Domicilio > > RecuperarDomiciliosUsuario( int claveUsuario, string accessToken )
		{
			string requestURL = domicilioURL + "/" + claveUsuario + "/domicilios";
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					ObservableCollection< Domicilio > domicilios = await response.Content.ReadAsAsync< ObservableCollection< Domicilio > >();
					return domicilios;
				}
				else
				{
					return null;
				}
			}
		}

	}
}