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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        string pathName = @".\usuarios.txt";
        string pathNameAuxiliar = @".\usuarios.txt";
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idproductUPDATE = txtidproducto.Text;
                string datosModificados1 = txtnombreproducto.Text;
                string datosModificados2 = txtcodebarra.Text;
                string datosModificados3 = txtPrecioCompra.Text;
                string datosModificados4 = txtPrecioVenta.Text;
                string datosModificados5 = txtcantidadproducto.Text;
                string linea;
                string[] datosProducto;
                char separador = ',';
                bool modificado = false;

                string ID = idproductUPDATE.ToString();
                string PC = datosModificados3.ToString();
                string PV = datosModificados4.ToString();
                string C = datosModificados5.ToString();

                StreamReader tuberiaLectura = File.OpenText(pathName);
                StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosProducto = linea.Split(separador);
                    if (idproductUPDATE == datosProducto[0])
                    {
                        modificado = true;
                        tuberiaEscritura.WriteLine(idproductUPDATE + "," + datosModificados1 + "," + datosModificados2 + "," + datosModificados3 + "," + datosModificados4 + "," + datosModificados5);
                    }
                    else
                    {
                        tuberiaEscritura.WriteLine(linea);
                    }
                    linea = tuberiaLectura.ReadLine();
                }
                if (modificado)
                {
                    MessageBox.Show("La mascota se modifico con exito");
                }
                else
                {
                    MessageBox.Show("Mascota no encontrada");
                }

                tuberiaEscritura.Close();
                tuberiaLectura.Close();

                File.Delete(pathName);
                File.Move(pathNameAuxiliar, pathName);
                File.Delete(pathNameAuxiliar);
                txtidproducto.Text = "";
                txtnombreproducto.Text = "";
                txtcodebarra.Text = "";
                txtPrecioCompra.Text = "";
                txtPrecioVenta.Text = "";
                txtcantidadproducto.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el prducto \nPor favor verifique si ingreso todos los datos del producto " + ex.Message);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MostrarProductos();
        }

        private void dgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void MostrarProductos()
        {
            try
            {
                if (File.Exists(pathName))
                {
                    Productosdg producto;
                    List<Productosdg> listaProductos = new List<Productosdg>();
                    string[] datosProducto;
                    string id, nombre, codebarra, preciocompra, precioventa, cantidad;
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    string linea = tuberiaLectura.ReadLine();
                    while (linea != null)
                    {
                        datosProducto = linea.Split(',');
                        id = datosProducto[0];
                        nombre = datosProducto[1];
                        codebarra = datosProducto[2];
                        preciocompra = datosProducto[3];
                        precioventa = datosProducto[4];
                        cantidad = datosProducto[5];
                        producto = new Productosdg(id, nombre, codebarra, preciocompra, precioventa, cantidad);

                        listaProductos.Add(producto);
                        producto = null;
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaLectura.Close();
                    dgProductos.ItemsSource = listaProductos;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
