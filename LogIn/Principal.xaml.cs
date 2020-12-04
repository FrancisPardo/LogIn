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

namespace LogIn
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnSomos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            Quienes objQuienes = new Quienes();
            this.Visibility = Visibility.Hidden;
            objQuienes.Show();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            Cerrar objCerrar = new Cerrar();
            this.Visibility = Visibility.Hidden;
            objCerrar.Show();
        }

        private void Producto(object sender, RoutedEventArgs e)
        {
            Producto objProducto = new Producto();
            this.Visibility = Visibility.Hidden;
            objProducto.Show();
        }
    }
}
