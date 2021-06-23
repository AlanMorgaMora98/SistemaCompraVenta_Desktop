using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Services;
using SistemaDeComprasYVentas.Commands;

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
			NavigateToHomeCommand = new NavigateCommand< IniciarSesionViewModel >( iniciarSesionNavigationService );
			NavigateToHomeCommand = new NavigateCommand< PerfilViewModel >( perilNavigationService );
			NavigateToHomeCommand = new NavigateCommand< DomiciliosViewModel >( domiciliosNavigationService );
			NavigateToHomeCommand = new NavigateCommand< CarritoComprasViewModel >( carritoComprasNavigationService );
			NavigateToHomeCommand = new NavigateCommand< FavoritosViewModel >( favoritosNavigationService );
			NavigateToHomeCommand = new NavigateCommand< PublicacionesViewModel >( publicacionesNavigationService );
			NavigateToHomeCommand = new NavigateCommand< HistorialComprasViewModel >( historialComprasNavigationService );
			NavigateToHomeCommand = new NavigateCommand< HistorialVentasViewModel >( historialVentasNavigationService );
		}

	}
}