using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
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

		public PublicacionesViewModel()
		{
			requests = new PublicacionesRequests();
			NavigateAgregarPublicacionCommand = new NavigateCommand<PublicarProductoViewModel>(
											NavigationServiceCreator.GetInstance().CreateAgregarPublicacionNavigationService());
		}
	}
}
