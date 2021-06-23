using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class NavigationBarViewModel : ViewModelBase
	{
		public ICommand NavigateToHomeCommand { get; }
		public ICommand NavigateToLoginCommand { get; }
		public ICommand NavigateToProfileCommand { get; }
		public ICommand NavigateToAddressesCommand { get; }
		public ICommand NavigateToCartCommand { get; }
		public ICommand NavigateToFavoritesCommand { get; }
		public ICommand NavigateToPublicationsCommand { get; }
		public ICommand NavigateToBuyHistoryCommand { get; }
		public ICommand NavigateToSellHistoryCommand { get; }
		public ICommand LogoutCommand { get; }

	}
}
