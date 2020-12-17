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
    /// Lógica de interacción para TotalVentas.xaml
    /// </summary>
    public partial class TotalVentas : Window
    {
        float toto = 0;

        public TotalVentas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Ci", Type.GetType("System.String")); //o del tipo de dato que requieras
            dt.Columns.Add("Razon", Type.GetType("System.String"));
            dt.Columns.Add("Fecha", Type.GetType("System.String"));
            dt.Columns.Add("Total", Type.GetType("System.String"));

            DataRow dr;

            for (int x = 0; x < MostrarVenta.ci.Length; x++)
            {
                if (MostrarVenta.ci[x] != "")
                {
                    dr = dt.NewRow();
                    dr["Ci"] = MostrarVenta.ci[x];
                    dr["Razon"] = MostrarVenta.raz[x];
                    dr["Fecha"] = MostrarVenta.fec[x];
                    dr["Total"] = MostrarVenta.tot[x];
                    dt.Rows.Add(dr);
                }
            }
            dg1.ItemsSource = dt.DefaultView;
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Principal().ShowDialog();
        }
    }
}
