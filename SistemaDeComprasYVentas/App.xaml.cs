using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SistemaDeComprasYVentas.ViewModels;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Services;

namespace SistemaDeComprasYVentas
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
		{
            _navigationStore = new NavigationStore();
		}


        protected override void OnStartup( StartupEventArgs startUpEvents )
		{
            INavigationService< IniciarSesionViewModel > iniciarSesionNavigationService = CreateIniciarSesionNavigationService();
            iniciarSesionNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel( _navigationStore )
            };
            MainWindow.Show();

            base.OnStartup( startUpEvents );
		}

        private INavigationService< BuscarPublicacionesViewModel > CreateBuscarNavigationService()
		{
            return new LayoutNavigationService< BuscarPublicacionesViewModel >( 
                _navigationStore, 
                () => new BuscarPublicacionesViewModel(), CreateNavigationBarViewModel );
		}

        private INavigationService< IniciarSesionViewModel > CreateIniciarSesionNavigationService()
        {
            return new LayoutNavigationService< IniciarSesionViewModel >(
                _navigationStore,
                () => new IniciarSesionViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< PerfilViewModel > CreatePerfilNavigationService()
        {
            return new LayoutNavigationService< PerfilViewModel >(
                _navigationStore,
                () => new PerfilViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< DomiciliosViewModel > CreateDomicilioNavigationService()
        {
            return new LayoutNavigationService< DomiciliosViewModel >(
                _navigationStore,
                () => new DomiciliosViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< CarritoComprasViewModel > CreateCarritoCompraNavigationService()
        {
            return new LayoutNavigationService< CarritoComprasViewModel >(
                _navigationStore,
                () => new CarritoComprasViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< FavoritosViewModel > CreateFavoritosViewModel()
        {
            return new LayoutNavigationService< FavoritosViewModel >(
                _navigationStore,
                () => new FavoritosViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< PublicacionesViewModel > CreatePublicacionesNavigaionService()
        {
            return new LayoutNavigationService< PublicacionesViewModel >(
                _navigationStore,
                () => new PublicacionesViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< HistorialComprasViewModel > CreateHistorialComprasNavigationService()
        {
            return new LayoutNavigationService< HistorialComprasViewModel >(
                _navigationStore,
                () => new HistorialComprasViewModel(), CreateNavigationBarViewModel );
        }

        private INavigationService< HistorialVentasViewModel > CreateHistorialVentasNavigationService()
        {
            return new LayoutNavigationService< HistorialVentasViewModel >(
                _navigationStore,
                () => new HistorialVentasViewModel(), CreateNavigationBarViewModel );
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
		{
            return new NavigationBarViewModel( CreateBuscarNavigationService(),
                CreateIniciarSesionNavigationService(), CreatePerfilNavigationService(), CreateDomicilioNavigationService(),
                CreateCarritoCompraNavigationService(), CreateFavoritosViewModel(), CreatePublicacionesNavigaionService(),
                CreateHistorialComprasNavigationService(), CreateHistorialVentasNavigationService() );
		}
    }
}