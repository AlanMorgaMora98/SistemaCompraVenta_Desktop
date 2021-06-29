﻿using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Utilities;
using SistemaDeComprasYVentas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.Commands
{
	public class EliminarCuentaCommand : CommandBase
	{
		private UsuarioRequests requests;
		private ICommand NavigateBuscarProductosCommand { get; }

		public EliminarCuentaCommand()
		{
			requests = new UsuarioRequests();
			NavigateBuscarProductosCommand = new NavigateCommand< BuscarPublicacionesViewModel >( 
												 NavigationServiceCreator.GetInstance().CreateBuscarNavigationService() );
		}

		public override void Execute( object parameter )
		{
			requests.DeleteUsuario( LoginSession.GetInstance().ClaveUsuario, LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					LoginSession.GetInstance().Logout();
					NavigateBuscarProductosCommand.Execute( this );
				}
			} );
		}
	}
}
