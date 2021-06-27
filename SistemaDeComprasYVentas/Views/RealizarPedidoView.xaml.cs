using SistemaDeComprasYVentas.Models;
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
	/// Interaction logic for RealizarPedido.xaml
	/// </summary>
	public partial class RealizarPedidoView : UserControl
	{
		public RealizarPedidoView()
		{
			InitializeComponent();
		}

		public void DomicilioChanged( object sender, RoutedEventArgs e )
		{
			if( ( ( ComboBox )sender ).SelectedIndex > -1 )
			{
				( ( dynamic )DataContext ).ItemSeleccionado = ( Domicilio )( ( ComboBox )sender ).SelectedItem;
			}
		}

		public void TarjetaChanged( object sender, RoutedEventArgs e )
		{

		}
	}
}
