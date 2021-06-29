﻿using System;
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
using System.Collections.ObjectModel;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class PublicacionesRequests
	{
		private string publicacionesURL = "http://192.168.56.1:5000/publicaciones";
		private string carritoURL = "http://192.168.56.1:5000/usuarios";
		private string favoritoURL = "http://192.168.56.1:5000/usuarios";

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

		public async Task< ObservableCollection< Publicacion > > RecuperarPublicacionesCarrito( int claveUsuario, string accessToken )
		{
			string requestURL = carritoURL + "/" + claveUsuario + "/carritos";
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					ObservableCollection< Publicacion > publicaciones = await response.Content.ReadAsAsync< ObservableCollection< Publicacion > >();
					return publicaciones;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task< ObservableCollection< Publicacion > > RecuperarPublicacionesFavoritos( int claveUsuario, string accessToken )
		{
			string requestURL = favoritoURL + "/" + claveUsuario + "/favoritos";
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					ObservableCollection< Publicacion > publicaciones = await response.Content.ReadAsAsync< ObservableCollection< Publicacion > >();
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

		public async Task< Publicacion > EliminarDeCarrito( int claveUsuario, int clavePublicacion, string accessToken )
		{
			string requestURL = carritoURL + "/" + claveUsuario + "/carritos/" + clavePublicacion;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			using( HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync( requestURL ) )
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

		public async Task< Publicacion > EliminarDeFavoritos( int claveUsuario, int clavePublicacion, string accessToken )
		{
			string requestURL = favoritoURL + "/" + claveUsuario + "/favoritos/" + clavePublicacion;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync( requestURL ) )
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

		public async Task<ObservableCollection<Publicacion>> RecuperarPublicacionDeUsuario(int claveUsuario, string accessToken)
		{
			string requestURL = publicacionesURL + "/" + claveUsuario;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(requestURL))
			{
				if (response.IsSuccessStatusCode)
				{
					ObservableCollection<Publicacion> publicaciones = await response.Content.ReadAsAsync<ObservableCollection<Publicacion>>();
					return publicaciones;
				}
				else
				{
					return null;
				}
			}
		}

		public async Task< Publicacion > EliminarPublicacion(int claveUsuario, int clavePublicacion, string accessToken)
		{
			string requestURL = publicacionesURL + "/"+ clavePublicacion;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(requestURL))
			{
				if (response.IsSuccessStatusCode)
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
