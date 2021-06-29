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
	public class DomiciliosViewModel : ViewModelBase
	{
		private DomicilioRequests requests;
		public ICommand NavigateAgregarDomicilioCommand { get; }

		public ObservableCollection< Domicilio > Domicilios
		{
			get { return SelectionContainerStore.GetInstance().DomiciliosUsuario; }
			set
			{
				SelectionContainerStore.GetInstance().DomiciliosUsuario = value;
				OnPropertyChanged(nameof( Domicilios ));
			}
		}

		public Domicilio ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().DomicilioSeleccionado = value;
			}
		}

		public DomiciliosViewModel()
		{
			requests = new DomicilioRequests();
			NavigateAgregarDomicilioCommand = new NavigateCommand<AgregarDomicilioViewModel>(
											NavigationServiceCreator.GetInstance().CreateAgregarDomicilioNavigationService());
			RecuperarDomiciliosDeUsuario();
		}

		private void RecuperarDomiciliosDeUsuario()
		{
			requests.RecuperarDomiciliosUsuario( LoginSession.GetInstance().ClaveUsuario,
												 LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
			{
				if( Task.Exception == null )
				{
					Domicilios = Task.Result;
				}
			} );
		}

		public void EliminarDomicilioDeUsuario()
		{
			requests.EliminarDomicilio(LoginSession.GetInstance().ClaveUsuario,
										SelectionContainerStore.GetInstance().DomicilioSeleccionado.discriminante_domicilio,
										LoginSession.GetInstance().AccessToken).ContinueWith(Task =>
				{
					if (Task.Exception == null)
					{
						System.Windows.Application.Current.Dispatcher.Invoke(delegate
						{
							SelectionContainerStore.GetInstance().EliminarDomicilioDeUsuario();
							RecuperarDomiciliosDeUsuario();
						});
					}
				});
		}

	}


}
