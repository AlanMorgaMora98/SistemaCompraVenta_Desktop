using Newtonsoft.Json;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class UsuarioRequests
	{
		private OutputMessages messages;
		private string usuarioGeneralURL = "http://192.168.1.108:5000/usuarios";

		public UsuarioRequests()
		{
			ApiHelper.InitializeClient();
			messages = new OutputMessages();
		}

		public async Task< Usuario > RegistrarUsuario( Usuario usuario )
		{
			try
			{
				var json = JsonConvert.SerializeObject(usuario);
				var data = new StringContent( json, Encoding.UTF8, "application/json" );
				using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( usuarioGeneralURL, data ) )
				{
					if( response.IsSuccessStatusCode )
					{
						Usuario respuesta = await response.Content.ReadAsAsync< Usuario >();
						return respuesta;
					}
					else
					{
						MessageBox.Show( messages.RegistrarUsuarioError(), messages.ErrorTitle() );
						return null;
					}
				}
			} catch( Exception )
			{
				MessageBox.Show( messages.NoHayConexionAlServido(), messages.SinConexionTitle() );
				return null;
			}
		}

		public async Task< Usuario > GetUsuarioInformation( int claveUsuario, string accessToken )
		{
			try
			{
				string requestURL = usuarioGeneralURL + "/" + claveUsuario;
				ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
				using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
				{
					if( response.IsSuccessStatusCode )
					{
						Usuario respuesta = await response.Content.ReadAsAsync< Usuario >();
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

		public async Task< Usuario > ActualizarUsuarioInformation( int claveUsuario, string accessToken, Usuario usuario )
		{
			try
			{
				string requestURL = usuarioGeneralURL + "/" + claveUsuario;
				var json = JsonConvert.SerializeObject(usuario);
				var data = new StringContent( json, Encoding.UTF8, "application/json" );
				ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
				using( HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync( requestURL, data ) )
				{
					if( response.IsSuccessStatusCode )
					{
						Usuario respuesta = await response.Content.ReadAsAsync< Usuario >();
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

		public async Task< Usuario > DeleteUsuario( int claveUsuario, string accessToken )
		{
			try
			{
				string requestURL = usuarioGeneralURL + "/" + claveUsuario;
				ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
				using( HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync( requestURL ) )
				{
					if( response.IsSuccessStatusCode )
					{
						Usuario respuesta = await response.Content.ReadAsAsync< Usuario >();
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
