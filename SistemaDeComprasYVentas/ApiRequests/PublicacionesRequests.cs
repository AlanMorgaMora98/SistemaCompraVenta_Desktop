using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.ViewModels;
using System.Net.Http;
using System.IO;
using SistemaDeComprasYVentas.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class PublicacionesRequests
	{
		private string publicacionesURL = "http://192.168.1.68:5000/publicaciones";
		private string carritoURL = "http://192.168.1.68:5000/usuarios";
		private string favoritoURL = "http://192.168.1.68:5000/usuarios";

		public PublicacionesRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< List< Publicacion > > RecuperarPublicacionesBuscar()
		{
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( publicacionesURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					List< Publicacion > publicaciones = await response.Content.ReadAsAsync< List< Publicacion > >();
					return publicaciones;
				} 
				else
				{
					return null;
				}
			}
		}

		public async Task< Publicacion > AgregarACarrito( CarritoFavoritoData publicacion, string accessToken )
		{
			string requestURL = carritoURL + "/" + publicacion.clave_usuario_usuario + "/carritos";
			var json = JsonConvert.SerializeObject( publicacion );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using ( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( requestURL, data ) )
			{
				if( response.IsSuccessStatusCode )
				{
					Publicacion respuesta = await response.Content.ReadAsAsync< Publicacion >();
					return respuesta;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task< Publicacion > AgregarAFavorito( CarritoFavoritoData publicacion, string accessToken )
		{
			string requestURL = favoritoURL + "/" + publicacion.clave_usuario_usuario + "/favoritos";
			var json = JsonConvert.SerializeObject( publicacion );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using ( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( requestURL, data ) )
			{
				if( response.IsSuccessStatusCode )
				{
					Publicacion respuesta = await response.Content.ReadAsAsync< Publicacion >();
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
