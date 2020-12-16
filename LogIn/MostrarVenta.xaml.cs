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
using System.Windows.Shapes;

namespace LogIn
{
    /// <summary>
    /// Lógica de interacción para MostrarVenta.xaml
    /// </summary>
    public partial class MostrarVenta : Window
    {
        string archivo = @".\ventasAux.txt";
        string pathName = @".\productos.txt";

        public MostrarVenta()
        {
            InitializeComponent();
            MostrarProductos();
            MostrarHoraActual();
            File.Delete(archivo);

        }

        private void MostrarHoraActual()
        {
            lblTiempo.Content = DateTime.Today.ToString("dd-MM-yyyy" + "/" + DateTime.Now.ToString("HH:mm:ss"));
        }

        private void MostrarProductos()
        {

            try
            {
                if (File.Exists(pathName))
                {

                    File.Copy(pathName, archivo);

                    Productosdg producto;
                    List<Productosdg> listaProductos = new List<Productosdg>();
                    string[] datosProducto;
                    string id, nombre, codebarra, preciocompra, precioventa;
                    StreamReader tuberiaLectura = File.OpenText(archivo);
                    string linea = tuberiaLectura.ReadLine();
                    while (linea != null)
                    {
                        datosProducto = linea.Split(',');
                        id = datosProducto[0];
                        nombre = datosProducto[1];
                        codebarra = datosProducto[2];
                        preciocompra = datosProducto[3];
                        precioventa = datosProducto[4];
                        datosProducto[5] = "1";
                        producto = new Productosdg(id, nombre, codebarra, preciocompra, precioventa, "1");

                        listaProductos.Add(producto);
                        producto = null;
                        linea = tuberiaLectura.ReadLine();

                    }
                    tuberiaLectura.Close();





                    dgParaVentas.ItemsSource = listaProductos;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void dgVentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Productosdg producto = new Productosdg();
            producto = (Productosdg)dgParaVentas.SelectedItem;


        }

        private void btnRealizarVenta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            new Principal().ShowDialog();
            this.Close();
        }
    }
}
