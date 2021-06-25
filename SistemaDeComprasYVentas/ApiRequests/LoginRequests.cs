using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ApiRequests
{
	public class LoginRequests
	{
		private string loginURL = "http://192.168.1.68:5000/login";

		public LoginRequests()
		{
			ApiHelper.InitializeClient();
		}

		public async Task< List< Publicacion > > RealizarLogin()
		{
			using( HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync( loginURL ) )
			{
				if (response.IsSuccessStatusCode)
				{
					List<Publicacion> publicaciones = await response.Content.ReadAsAsync<List<Publicacion>>();
					return publicaciones;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
