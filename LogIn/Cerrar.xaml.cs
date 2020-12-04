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
using System.Windows.Shapes;

namespace LogIn
{
    /// <summary>
    /// Lógica de interacción para Cerrar.xaml
    /// </summary>
    public partial class Cerrar : Window
    {
        public Cerrar()
        {
            InitializeComponent();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            Principal objPrincipal = new Principal();
            this.Visibility = Visibility.Hidden;
            objPrincipal.Show();
        }

        private void BtnSi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
