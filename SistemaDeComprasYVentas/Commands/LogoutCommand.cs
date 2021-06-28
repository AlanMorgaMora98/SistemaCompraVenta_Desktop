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
	public class LogoutCommand : CommandBase
	{
		private ICommand NavigateToHomeCommand { get; }

		public LogoutCommand()
		{
			NavigateToHomeCommand = new NavigateCommand< BuscarPublicacionesViewModel >( 
										NavigationServiceCreator.GetInstance().CreateBuscarNavigationService() );
		}

		public override void Execute( object parameter )
		{
			LoginSession.GetInstance().Logout();
			NavigateToHomeCommand.Execute( this );
		}
	}
}
