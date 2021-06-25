using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ApiRequests
{
	class ApiHelper
	{
		public static HttpClient ApiClient { get; set; }
		private static bool IsInitialized = false;

		public static void InitializeClient()
		{
			if( !IsInitialized )
			{
				IsInitialized = true;
				ApiClient = new HttpClient();
				ApiClient.DefaultRequestHeaders.Accept.Clear();
				ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			}
		}
	}
}