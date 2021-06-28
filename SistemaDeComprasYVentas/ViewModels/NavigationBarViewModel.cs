using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Services;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Session;

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

		public bool IsLoggedIn => LoginSession.GetInstance().IsLoggedIn;
		public bool IsLoggedOut => LoginSession.GetInstance().IsLoggedOut;

		public NavigationBarViewModel( INavigationService< BuscarPublicacionesViewModel > buscarPublicacionesService,
			INavigationService< IniciarSesionViewModel > iniciarSesionNavigationService,
			INavigationService< PerfilViewModel > perilNavigationService,
			INavigationService< DomiciliosViewModel > domiciliosNavigationService,
			INavigationService< CarritoComprasViewModel > carritoComprasNavigationService,
			INavigationService< FavoritosViewModel > favoritosNavigationService,
			INavigationService< PublicacionesViewModel > publicacionesNavigationService,
			INavigationService< HistorialComprasViewModel > historialComprasNavigationService,
			INavigationService< HistorialVentasViewModel > historialVentasNavigationService )
		{
			NavigateToHomeCommand = new NavigateCommand< BuscarPublicacionesViewModel >( buscarPublicacionesService );
			NavigateToLoginCommand = new NavigateCommand< IniciarSesionViewModel >( iniciarSesionNavigationService );
			NavigateToProfileCommand = new NavigateCommand< PerfilViewModel >( perilNavigationService );
			NavigateToAddressesCommand = new NavigateCommand< DomiciliosViewModel >( domiciliosNavigationService );
			NavigateToCartCommand = new NavigateCommand< CarritoComprasViewModel >( carritoComprasNavigationService );
			NavigateToFavoritesCommand = new NavigateCommand< FavoritosViewModel >( favoritosNavigationService );
			NavigateToPublicationsCommand = new NavigateCommand< PublicacionesViewModel >( publicacionesNavigationService );
			NavigateToBuyHistoryCommand = new NavigateCommand< HistorialComprasViewModel >( historialComprasNavigationService );
			NavigateToSellHistoryCommand = new NavigateCommand< HistorialVentasViewModel >( historialVentasNavigationService );
		}

	}
}