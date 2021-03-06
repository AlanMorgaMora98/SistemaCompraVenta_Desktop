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
	/// Interaction logic for PublicarProductoView.xaml
	/// </summary>
	public partial class PublicarProductoView : UserControl
	{
		public PublicarProductoView()
		{
			InitializeComponent();
		}

		public void SeleccionDeCategoria(object sender, RoutedEventArgs e)
		{
			if (((ComboBox)sender).SelectedIndex > -1)
			{
				((dynamic)DataContext).seleccion = (string)((ComboBox)sender).SelectedItem;
			}
		}


		private void AbrirExploradorArchivos( object sender, RoutedEventArgs e )
        {
			Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
			fileDialog.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
			bool? response = fileDialog.ShowDialog();
			if( response == true )
			{
				string filepath = fileDialog.FileName;
				( ( dynamic )DataContext ).GetImage( filepath );
			}
		}
    }
}
