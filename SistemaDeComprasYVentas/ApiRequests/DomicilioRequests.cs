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
	public class DomicilioRequests
	{
		private string domicilioURL = "http://192.168.1.68:5000/usuarios";

		public DomicilioRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< List< Domicilio > > RecuperarDomiciliosUsuario( int claveUsuario, string accessToken )
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
	}
}
