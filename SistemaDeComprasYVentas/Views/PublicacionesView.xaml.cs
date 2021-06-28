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
	/// Interaction logic for PublicacionesView.xaml
	/// </summary>
	public partial class PublicacionesView : UserControl
	{
		public PublicacionesView()
		{
			InitializeComponent();
		}

		public void SelectionChanged(object sender, RoutedEventArgs e)
		{
			if (((ListBox)sender).SelectedIndex > -1)
			{
				((dynamic)DataContext).ItemSeleccionado = (Publicacion)((ListBox)sender).SelectedItem;
			}
		}

		public void EliminarPublicacion(object sender, RoutedEventArgs e)
		{
			((dynamic)DataContext).EliminarPublicacionDeCarrito();
		}
	}
}
