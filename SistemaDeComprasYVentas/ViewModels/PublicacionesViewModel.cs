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

	public class PublicacionesViewModel : ViewModelBase
	{
		private PublicacionesRequests requests;
		public ICommand NavigateAgregarPublicacionCommand { get; }

		public ObservableCollection< Publicacion > Publicaciones
		{
			get { return SelectionContainerStore.GetInstance().PublicacionesUsuario; }
			set
			{
				SelectionContainerStore.GetInstance().PublicacionesUsuario = value;
				OnPropertyChanged(nameof(Publicaciones));
			}
		}

		public Publicacion ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().PublicacionSeleccionadaUsuario = value;
			}
		}

		public bool PublicacionSeleccionada
		{
			get
			{
				return SelectionContainerStore.GetInstance().PublicacionSeleccionadaUsuario != null;
			}
		}

		public PublicacionesViewModel()
		{
			requests = new PublicacionesRequests();
			NavigateAgregarPublicacionCommand = new NavigateCommand<PublicarProductoViewModel>(
											NavigationServiceCreator.GetInstance().CreateAgregarPublicacionNavigationService());
			SelectionContainerStore.GetInstance().PublicacionSeleccionadaUsuario = null;
			RecuperarPublicacionesDeUsuario();
		}

		private void RecuperarPublicacionesDeUsuario()
		{
			requests.RecuperarPublicacionDeUsuario( LoginSession.GetInstance().ClaveUsuario,
													LoginSession.GetInstance().AccessToken ).ContinueWith(Task =>
			{
				if (Task.Exception == null)
				{
					Publicaciones = Task.Result;
				}
			});
		}

		public void EliminarPublicacionDeUsuario()
		{
			if( SelectionContainerStore.GetInstance().PublicacionSeleccionadaUsuario != null )
			{
				requests.EliminarPublicacion( LoginSession.GetInstance().ClaveUsuario,
											  SelectionContainerStore.GetInstance().PublicacionSeleccionadaUsuario.clave_publicacion,
											  LoginSession.GetInstance().AccessToken).ContinueWith( Task =>
				  {
					  if( Task.Exception == null )
					  {
						  System.Windows.Application.Current.Dispatcher.Invoke( delegate
						  {
							  SelectionContainerStore.GetInstance().EliminarPublicacionDeUsuario();
							  SelectionContainerStore.GetInstance().PublicacionSeleccionadaUsuario = null;
							  RecuperarPublicacionesDeUsuario();
						  } );
					  }
				  } );
			}
		}
	}
}
