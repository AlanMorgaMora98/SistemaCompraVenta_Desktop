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
	public class EvaluacionRequests
	{
		private OutputMessages messages;
		private string evaluacionURL = "http://192.168.1.68:5000/usuarios";

		public EvaluacionRequests()
		{
			ApiHelper.InitializeClient();
			messages = new OutputMessages();
		}

		public async Task< EvaluacionUsuario > AgregarEvaluacion( EvaluacionUsuario evaluacion, string accessToken )
		{
			try
			{
				string requestURL = evaluacionURL + "/" + evaluacion.clave_usuario + "/evaluaciones";
				var json = JsonConvert.SerializeObject( evaluacion );
				var data = new StringContent( json, Encoding.UTF8, "application/json" );
				ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", accessToken );
				using( HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync( requestURL, data ) )
				{
					if( response.IsSuccessStatusCode )
					{
						EvaluacionUsuario result = await response.Content.ReadAsAsync< EvaluacionUsuario >();
						return result;
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
