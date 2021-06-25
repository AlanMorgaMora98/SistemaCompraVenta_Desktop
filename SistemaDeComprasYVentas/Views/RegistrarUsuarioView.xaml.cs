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
    /// Lógica de interacción para RegistrarUsuario.xaml
    /// </summary>
    public partial class RegistrarUsuarioView : UserControl
    {
        public RegistrarUsuarioView()
        {
            InitializeComponent();
        }

        private void Contrasena_Changed( object sender, RoutedEventArgs e )
        {
            if( DataContext != null )
            { ( ( dynamic )DataContext ).Contrasena = ( ( PasswordBox )sender ).SecurePassword; }
        }

        private void ConfirmarContrasena_Changed( object sender, RoutedEventArgs e )
        {
            if( DataContext != null )
            { ( ( dynamic )DataContext ).ConfirmarContrasena = ( ( PasswordBox )sender ).SecurePassword; }
        }
    }
}
