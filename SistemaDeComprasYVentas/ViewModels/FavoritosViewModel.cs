using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class FavoritosViewModel : ViewModelBase
	{
		private PublicacionesRequests requests;
		public ICommand NavigateVisualizarPublicacion { get; }

		public ObservableCollection< Publicacion > PublicacionesFavoritos
		{
			get { return SelectionContainerStore.GetInstance().PublicacionesFavoritos; }
			set
			{
				SelectionContainerStore.GetInstance().PublicacionesFavoritos = value;
				OnPropertyChanged( nameof( PublicacionesFavoritos ) );
			}
		}

		public Publicacion ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().PublicacionSeleccionadaFavorito = value;
				SelectionContainerStore.GetInstance().PublicacionSeleccionadaBusqueda = value;
			}
		}

		public bool PublicacionSeleccionada
		{
			get
			{
				return SelectionContainerStore.GetInstance().PublicacionSeleccionadaFavorito != null;
			}
		}

		public FavoritosViewModel()
		{
			SelectionContainerStore.GetInstance().PublicacionSeleccionadaBusqueda = null;
			SelectionContainerStore.GetInstance().PublicacionSeleccionadaFavorito = null;
			requests = new PublicacionesRequests();
			NavigateVisualizarPublicacion = new NavigateCommand< VisualizarPublicacionCompradorViewModel >(
												NavigationServiceCreator.GetInstance().CreateVisualizarPublicacionCompradorService() );
			RecuperarPublicacionesFavoritos();
		}

		private void RecuperarPublicacionesFavoritos()
		{
			requests.RecuperarPublicacionesFavoritos( LoginSession.GetInstance().ClaveUsuario,
													  LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
				{
					if( Task.Exception == null )
					{
						PublicacionesFavoritos = Task.Result;
					}
				} );
		}

		public void EliminarPublicacionDeFavoritos()
		{
			if( SelectionContainerStore.GetInstance().PublicacionSeleccionadaFavorito != null )
			{
				requests.EliminarDeFavoritos( LoginSession.GetInstance().ClaveUsuario,
											  SelectionContainerStore.GetInstance().PublicacionSeleccionadaFavorito.clave_publicacion,
											  LoginSession.GetInstance().AccessToken).ContinueWith( Task =>
				  {
					  if( Task.Exception == null )
					  {
						  System.Windows.Application.Current.Dispatcher.Invoke( delegate
						  {
							  SelectionContainerStore.GetInstance().EliminarPublicacionDeListaFavoritos();
							  SelectionContainerStore.GetInstance().PublicacionSeleccionadaFavorito = null;
							  RecuperarPublicacionesFavoritos();
						  } );
					  }
				  } );
			}
		}
	}
}
