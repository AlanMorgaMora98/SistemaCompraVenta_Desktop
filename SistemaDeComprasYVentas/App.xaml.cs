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
using SistemaDeComprasYVentas.Utilities;

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
            NavigationServiceCreator.GetInstance().NavigationStore = _navigationStore;
		}


        protected override void OnStartup( StartupEventArgs startUpEvents )
		{
            INavigationService< IniciarSesionViewModel > iniciarSesionNavigationService = NavigationServiceCreator.GetInstance().CreateIniciarSesionNavigationService();
            iniciarSesionNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel( _navigationStore )
            };
            MainWindow.Show();

            base.OnStartup( startUpEvents );
		}
    }
}