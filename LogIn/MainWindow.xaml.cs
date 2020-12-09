using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathName = @".\usuarios.txt";
        public MainWindow()
        {
            InitializeComponent();
            VerificarArchivo();
        }

        private void VerificarArchivo()
        {
            try
            {
                if (!File.Exists(pathName))
                {
                    File.Create(pathName).Dispose();
                    Escribir("administrador,administrador,user,a123");
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void Escribir(string mensaje)
        {
            StreamWriter tuberiaEscritura = File.AppendText(pathName);
            tuberiaEscritura.WriteLine(mensaje);
            tuberiaEscritura.Close();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string usuario = txbUsuario.Text.Trim();
                string password = txbPassword.Password.Trim();
                if (usuario != "" && password != "")
                {
                    if (ValidarUsuario(usuario, password))
                    {
                        lblMensaje.Content = "Bienvenido";
                        new Principal().ShowDialog();
                        this.Close();
                    }
                    else
                    {
              
                        lblMensaje.Content = "datos incorrectos";
                    }
                }
                else
                {
                    lblMensaje.Content = "Ingresa los datos";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidarUsuario(string usuario, string password)
        {
            bool resultado = false;
            string[] datosUsuario;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datosUsuario = linea.Split(',');
                if (datosUsuario[2] == usuario && datosUsuario[3] == password)
                {
                    resultado = true;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return resultado;
        }
    }
}
