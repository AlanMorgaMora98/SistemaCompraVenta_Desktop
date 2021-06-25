﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Services;
using SistemaDeComprasYVentas.ViewModels;

namespace SistemaDeComprasYVentas.Utilities
{
	class NavigationServiceCreator
	{
		private static NavigationServiceCreator creator;
		private NavigationStore _navigationStore;
		public NavigationStore NavigationStore
		{
			get { return _navigationStore; }
			set { _navigationStore = value; }
		}


		private NavigationServiceCreator()
		{
			_navigationStore = null;
		}

		public static NavigationServiceCreator GetInstance()
		{
			if( creator == null )
			{
				creator = new NavigationServiceCreator();
			}
			return creator;
		}

        public INavigationService< RegistrarUsuarioViewModel > CreateRegistrarUsuarioNavigationService()
		{
            return new LayoutNavigationService<RegistrarUsuarioViewModel>(
                _navigationStore,
                () => new RegistrarUsuarioViewModel(), CreateNavigationBarViewModel );
		}

        public INavigationService< BuscarPublicacionesViewModel > CreateBuscarNavigationService()
        {
            return new LayoutNavigationService<BuscarPublicacionesViewModel>(
                _navigationStore,
                () => new BuscarPublicacionesViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< IniciarSesionViewModel > CreateIniciarSesionNavigationService()
        {
            return new LayoutNavigationService<IniciarSesionViewModel>(
                _navigationStore,
                () => new IniciarSesionViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< PerfilViewModel > CreatePerfilNavigationService()
        {
            return new LayoutNavigationService<PerfilViewModel>(
                _navigationStore,
                () => new PerfilViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< DomiciliosViewModel > CreateDomicilioNavigationService()
        {
            return new LayoutNavigationService<DomiciliosViewModel>(
                _navigationStore,
                () => new DomiciliosViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< CarritoComprasViewModel > CreateCarritoCompraNavigationService()
        {
            return new LayoutNavigationService<CarritoComprasViewModel>(
                _navigationStore,
                () => new CarritoComprasViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< FavoritosViewModel > CreateFavoritosViewModel()
        {
            return new LayoutNavigationService<FavoritosViewModel>(
                _navigationStore,
                () => new FavoritosViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< PublicacionesViewModel > CreatePublicacionesNavigaionService()
        {
            return new LayoutNavigationService<PublicacionesViewModel>(
                _navigationStore,
                () => new PublicacionesViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< HistorialComprasViewModel > CreateHistorialComprasNavigationService()
        {
            return new LayoutNavigationService<HistorialComprasViewModel>(
                _navigationStore,
                () => new HistorialComprasViewModel(), CreateNavigationBarViewModel );
        }

        public INavigationService< HistorialVentasViewModel > CreateHistorialVentasNavigationService()
        {
            return new LayoutNavigationService<HistorialVentasViewModel>(
                _navigationStore,
                () => new HistorialVentasViewModel(), CreateNavigationBarViewModel );
        }

        public NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel( CreateBuscarNavigationService(),
                CreateIniciarSesionNavigationService(), CreatePerfilNavigationService(), CreateDomicilioNavigationService(),
                CreateCarritoCompraNavigationService(), CreateFavoritosViewModel(), CreatePublicacionesNavigaionService(),
                CreateHistorialComprasNavigationService(), CreateHistorialVentasNavigationService() );
        }
    }
}