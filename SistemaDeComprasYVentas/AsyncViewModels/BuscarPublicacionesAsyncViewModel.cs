using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.ViewModels;

namespace SistemaDeComprasYVentas.AsyncViewModels
{
	public class BuscarPublicacionesAsyncViewModel
	{
		private PublicacionesRequests requests;
		private List< Publicacion > publicacionesTotales;
		public List< Publicacion > PublicacionesTotales 
		{
			get { return publicacionesTotales; } 
			set
			{
				publicacionesTotales = value;
			}
		}

		public BuscarPublicacionesAsyncViewModel()
		{
			requests = new PublicacionesRequests();
			publicacionesTotales = new List< Publicacion >();
		}

		public static BuscarPublicacionesAsyncViewModel CargarPublicaciones()
		{
			BuscarPublicacionesAsyncViewModel asyncViewModel = new BuscarPublicacionesAsyncViewModel();
			asyncViewModel.LoadPublications();
			return asyncViewModel;
		}

		private void LoadPublications()
		{
			requests.RecuperarPublicacionesBuscar().ContinueWith( task =>
			{ 
				if( task.Exception == null )
				{
					PublicacionesTotales = task.Result;
				}
			} );
		}
	}
}
