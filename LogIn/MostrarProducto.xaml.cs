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
using System.Data;

namespace LogIn
{
    /// <summary>
    /// Lógica de interacción para MostrarProducto.xaml
    /// </summary>
    public partial class MostrarProducto : Window
    {
        public MostrarProducto()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String")); //o del tipo de dato que requieras
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
            dt.Columns.Add("CodigoBarra", Type.GetType("System.String"));
            dt.Columns.Add("Preciocompra", Type.GetType("System.String"));
            dt.Columns.Add("Precioventa", Type.GetType("System.String"));
            dt.Columns.Add("cantidad", Type.GetType("System.String"));

            DataRow dr;

            for (int x = 0; x < Producto.id.Length; x++)
            {
                if (Producto.id[x] != 0)
                {
                    dr = dt.NewRow();
                    dr["Id"] = Producto.id[x];
                    dr["Nombre"] = Producto.nom[x];
                    dr["CodigoBarra"] = Producto.cod[x];
                    dr["Preciocompra"] = Producto.pc[x];
                    dr["Precioventa"] = Producto.pv[x];
                    dr["cantidad"] = Producto.can[x];
                    dt.Rows.Add(dr);
                }
            }
            dg1.ItemsSource = dt.DefaultView;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView datos = dg1.SelectedItem as DataRowView;
            if (datos != null)
            {
                txt1.Text = datos["Id"].ToString();
                txt2.Text = datos["Nombre"].ToString();
                txt3.Text = datos["CodigoBarra"].ToString();
                txt4.Text = datos["PrecioCompra"].ToString();
                txt5.Text = datos["PrecioVenta"].ToString();
                txt6.Text = datos["cantidad"].ToString();
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Producto x = new Producto();
            x.btn1.Content = "Modificar";
            x.txt1.Text = txt1.Text;
            x.txt2.Text = txt2.Text;
            x.txt3.Text = txt3.Text;
            x.txt4.Text = txt4.Text;
            x.txt5.Text = txt5.Text;
            x.txt6.Text = txt6.Text;

            x.Show();
            this.Close();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Producto x = new Producto();
            x.btn1.Content = "Eliminar";
            x.txt1.Text = txt1.Text;
            x.txt2.Text = txt2.Text;
            x.txt3.Text = txt3.Text;
            x.txt4.Text = txt4.Text;
            x.txt5.Text = txt5.Text;
            x.txt6.Text = txt6.Text;

            x.Show();
            this.Close();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Producto().ShowDialog();
        }
    }
}
