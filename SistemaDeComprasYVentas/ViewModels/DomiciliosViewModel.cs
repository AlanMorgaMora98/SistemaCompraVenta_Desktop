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
	public class DomiciliosViewModel : ViewModelBase
	{
		private DomicilioRequests requests;
		public ICommand NavigateAgregarDomicilioCommand { get; }

		public DomiciliosViewModel()
		{
			requests = new DomicilioRequests();
			NavigateAgregarDomicilioCommand = new NavigateCommand<AgregarDomicilioViewModel>(
											NavigationServiceCreator.GetInstance().CreateAgregarDomicilioNavigationService());
		}

	}


}
