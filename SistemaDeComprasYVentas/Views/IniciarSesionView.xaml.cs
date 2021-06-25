using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeComprasYVentas.Views
{
	/// <summary>
	/// Interaction logic for IniciarSesionView.xaml
	/// </summary>
	public partial class IniciarSesionView : UserControl
	{
		public IniciarSesionView()
		{
			InitializeComponent();
		}

		private void PasswordBox_PasswordChanged( object sender, RoutedEventArgs e )
		{
			if( DataContext != null )
			{ ( ( dynamic )DataContext ).Contrasena = ( ( PasswordBox )sender ).SecurePassword; }
		}

		private void Login_Click( object sender, RoutedEventArgs e )
		{

		}

		private void Exit_Click( object sender, RoutedEventArgs e )
		{

		}
	}
}
