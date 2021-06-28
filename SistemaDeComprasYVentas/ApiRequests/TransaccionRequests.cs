﻿using Newtonsoft.Json;
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
	public class TransaccionRequests
	{
		private string publicacionClaveURL = "http://192.168.1.68:5000/publicaciones";
		private string transaccionURL = "http://192.168.1.68:5000/transacciones";

		public TransaccionRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< UsuarioPublicacion > RecuperarClaveUsuario( int clavePublicacion, string accessToken )
		{
			string requestURL = publicacionClaveURL + "/" + clavePublicacion;
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( requestURL ) )
			{
				if( response.IsSuccessStatusCode )
				{
					UsuarioPublicacion usuarioPublicacion = await response.Content.ReadAsAsync< UsuarioPublicacion >();
					return usuarioPublicacion;
				}
				else
				{
					return null;
				}
			}
		}
		public async Task< Transaccion > AgregarTransaccion( int claveUsuario, Transaccion transaccion, string accessToken)
		{
			string requestURL = transaccionURL + "/" + claveUsuario;
			var json = JsonConvert.SerializeObject( transaccion );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( requestURL, data ) )
			{
				if( response.IsSuccessStatusCode )
				{
					Transaccion result = await response.Content.ReadAsAsync< Transaccion >();
					return result;
				}
				else
				{
					return null;
				}
			}
		}
	}
}