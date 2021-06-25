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
    /// Lógica de interacción para ModificarDatosPersonalesView.xaml
    /// </summary>
    public partial class ModificarDatosPersonalesView : UserControl
    {
        public ModificarDatosPersonalesView()
        {
            InitializeComponent();
        }

        private void ContrasenaChanged( Object sender, RoutedEventArgs e )
		{
            if( DataContext != null )
            { ( ( dynamic )DataContext ).Contrasena = ( ( PasswordBox )sender ).SecurePassword; }
        }

        private void ConfirmarContrasenaChanged( Object sender, RoutedEventArgs e )
        {
            if( DataContext != null )
            { ( ( dynamic )DataContext ).ConfirmarContrasena = ( ( PasswordBox )sender ).SecurePassword; }
        }
    }
}
