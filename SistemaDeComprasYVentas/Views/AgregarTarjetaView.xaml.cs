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
	/// Interaction logic for AgregarTarjetaView.xaml
	/// </summary>
	public partial class AgregarTarjetaView : UserControl
	{
		public AgregarTarjetaView()
		{
			InitializeComponent();
		}

		public void SeleccionDeTarjeta(object sender, RoutedEventArgs e)
		{
			if (((ComboBox)sender).SelectedIndex > -1)
			{
				((dynamic)DataContext).seleccion = (string)((ComboBox)sender).SelectedItem;
			}
		}
	}
}
