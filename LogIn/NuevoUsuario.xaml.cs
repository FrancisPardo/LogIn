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
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Window
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string[] lineas = { txt1.Text, txt2.Text, };
            System.IO.File.WriteAllLines(@"D:\user" + txt1.Text + ".txt", lineas);
            MessageBox.Show("Usuario ha sido creado");
            txt1.Text = "";
            txt2.Text = "";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Principal().ShowDialog();
        }
    }
}
