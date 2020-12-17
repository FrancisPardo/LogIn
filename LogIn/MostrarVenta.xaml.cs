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
    /// Lógica de interacción para MostrarVenta.xaml
    /// </summary>
    /// <summary>
    /// Lógica de interacción para nuevaventa.xaml
    /// </summary>
    public partial class MostrarVenta : Window
    {

        public static string[] ci = new string[50];
        public static string[] raz = new string[50];
        public static string[] fec = new string[50];
        public static float[] tot = new float[50];

        public int j;

        float total;

        public MostrarVenta()
        {
            InitializeComponent();
        }

        void cargaproductos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String")); //o del tipo de dato que requieras
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
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
                    dr["Precioventa"] = Producto.pv[x];
                    dr["cantidad"] = Producto.can[x];
                    dt.Rows.Add(dr);
                }
            }
            dg1.ItemsSource = dt.DefaultView;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ci[j] = txt1.Text;
            raz[j] = txt2.Text;
            fec[j] = txt3.Text;
            tot[j] = total;
            lb7.Items.Add(ci[j] + " - " + raz[j] + " - " + fec[j] + " - " + Convert.ToString(tot[j]));
            j++;
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            lb1.Items.Clear();
            lb2.Items.Clear();
            lb3.Items.Clear();
            lb4.Items.Clear();
            lb5.Items.Clear();
            lb6.Items.Clear();
            total = 0;
            lbltot.Content = "0";
        }

        private void nv_Activated(object sender, EventArgs e)
        {
            cargaproductos();
            total = 0;
            lblf.Content = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss");
        }

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*var row = (sender as DataGrid).CurrentItem;
            txt3.Text = row.Cells[0].Value.ToString(); */
            DataRowView datos = dg1.SelectedItem as DataRowView;
            if (datos != null)
            {
                txt3.Text = datos["Id"].ToString();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (txt3.Text != "")
            {
                int b;
                b = int.Parse(txt3.Text);
                for (int f = 0; f < 15; f++)
                {
                    if (b == Producto.id[f])
                    {
                        lb1.Items.Add(Producto.id[f]);
                        lb2.Items.Add(Producto.nom[f]);
                        lb3.Items.Add(Producto.cod[f]);
                        lb4.Items.Add(Producto.pc[f]);
                        lb5.Items.Add(Producto.pv[f]);
                        lb6.Items.Add("1");
                        total = total + Producto.pv[f];
                        lbltot.Content = Convert.ToString(total);
                    }
                }
                txt3.Text = "";
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            TotalVentas objtotal = new TotalVentas();
            this.Visibility = Visibility.Hidden;
            objtotal.Show();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Principal().ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String")); //o del tipo de dato que requieras
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
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
                    dr["Precioventa"] = Producto.pv[x];
                    dr["cantidad"] = Producto.can[x];
                    dt.Rows.Add(dr);
                }
            }
            dg1.ItemsSource = dt.DefaultView;
        }
    }
}

