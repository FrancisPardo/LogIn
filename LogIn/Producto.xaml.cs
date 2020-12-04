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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        string pathName = @"c:\productos.txt";
        string pathNameAuxiliar = @"c:\auxiliar.txt";
        public Producto()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombreEliminar = txtnombreproducto.Text;
                string linea;
                string[] datosProducto;
                char separador = ',';
                bool eliminado = false;
                StreamReader tuberiaLectura = File.OpenText(pathName);
                StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosProducto = linea.Split(separador);
                    if (nombreEliminar == datosProducto[1])
                    {
                        eliminado = true;
                    }
                    else
                    {
                        tuberiaEscritura.WriteLine(linea);
                    }
                    linea = tuberiaLectura.ReadLine();
                }
                if (eliminado)
                {
                    MessageBox.Show("El producto se eliminó con exito");
                }
                else
                {
                    MessageBox.Show("Producto no encontrado, no se eliminó");
                }
                tuberiaEscritura.Close();
                tuberiaLectura.Close();

                File.Delete(pathName);
                File.Move(pathNameAuxiliar, pathName);
                File.Delete(pathNameAuxiliar);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al eliminar " + ex.Message);

            }

        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(pathName))
                {
                    int idProducto = int.Parse(txtidproducto.Text);
                    string nombreProducto = txtnombreproducto.Text.Trim();
                    string codigoBarra = txtcodebarra.Text.Trim();
                    double precioCompra = double.Parse(txtPrecioCompra.Text);
                    double precioVenta = double.Parse(txtPrecioVenta.Text);
                    int cantidad = int.Parse(txtcantidadproducto.Text);


                    string ID = idProducto.ToString();
                    string PC = precioCompra.ToString();
                    string PV = precioVenta.ToString();
                    string C = cantidad.ToString();



                    if (nombreProducto != "" && ID != "" && PC != "" && PV != "" && C != "")
                    {
                        if (codigoBarra == "")
                        {
                            codigoBarra = "NULL";
                        }
                        if (ValidarId(ID))
                        {
                            StreamWriter tuberiaEscritura = File.AppendText(pathName);
                            tuberiaEscritura.WriteLine(ID + "," + nombreProducto + "," + codigoBarra + "," + PC + "," + PV + "," + C);
                            tuberiaEscritura.Close();
                            MessageBox.Show("Producto agregado con exito");
                            txtnombreproducto.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Pruebe ingresando otro ID");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduzca los datos necesarios");
                    }
                }
                else
                {
                    CrearArchivo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private bool ValidarId(string ID)
        {
            bool respuesta = true;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string[] datos;
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datos = linea.Split(',');
                if (datos[0] == ID)
                {
                    respuesta = false;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return respuesta;
        }

        private void CrearArchivo()
        {
            File.CreateText(pathName);
        }
    }
}
