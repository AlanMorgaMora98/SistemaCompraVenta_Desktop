﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SistemaDeComprasYVentas.ViewModels;
using SistemaDeComprasYVentas.Stores;

namespace SistemaDeComprasYVentas
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup( StartupEventArgs startUpEvents )
		{
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new IniciarSesionViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel( navigationStore )
            };
            MainWindow.Show();

            base.OnStartup( startUpEvents );
		}
    }
}
