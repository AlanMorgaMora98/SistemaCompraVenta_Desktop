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

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class PublicacionesRequests
	{
		private string publicacionesURL = "http://192.168.1.68:5000/publicaciones";

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

		public async Task< Publicacion > AgregarACarrito( Publicacion publicacion )
		{
			string requestURL = publicacionesURL +
			var json = JsonConvert.SerializeObject( publicacion );
			var data = new StringContent( json, Encoding.UTF8, "application/json" );
			using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( usuarioGeneralURL, data ) )
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
