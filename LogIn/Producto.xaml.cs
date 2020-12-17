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
        public static int[] id = new int[15];
        public static string[] nom = new string[15];
        public static int[] cod = new int[15];
        public static float[] pv = new float[15];
        public static float[] pc = new float[15];
        public static int[] can = new int[15];

        public int i;
        public Producto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(btn1.Content) == "Registrar")
            {
                if (i < 15)
                {
                    id[i] = int.Parse(txt1.Text);
                    nom[i] = txt2.Text;
                    cod[i] = int.Parse(txt3.Text);
                    pc[i] = float.Parse(txt4.Text);
                    pv[i] = float.Parse(txt5.Text);
                    can[i] = int.Parse(txt6.Text);
                    txt1.Text = "";
                    txt2.Text = "";
                    txt3.Text = "";
                    txt4.Text = "";
                    txt5.Text = "";
                    txt6.Text = "";
                    i++;
                }
            }
            else
            {
                if (Convert.ToString(btn1.Content) == "Modificar")
                {
                    int b;
                    b = int.Parse(txt1.Text);
                    for (int f = 0; f < 15; f++)
                    {

                        if (b == id[f])
                        {
                            nom[f] = txt2.Text;
                            cod[f] = int.Parse(txt3.Text);
                            pc[f] = float.Parse(txt4.Text);
                            pv[f] = float.Parse(txt5.Text);
                            can[f] = int.Parse(txt6.Text);
                            txt1.Text = "";
                            txt2.Text = "";
                            txt3.Text = "";
                            txt4.Text = "";
                            txt5.Text = "";
                            txt6.Text = "";
                        }
                    }
                    btn1.Content = "Registrar";

                }
                else
                {
                    int b;
                    b = int.Parse(txt1.Text);
                    for (int f = 0; f < 15; f++)
                    {
                        if (b == id[f])
                        {
                            id[f] = 0;
                            nom[f] = "";
                            cod[f] = 0;
                            pc[f] = 0;
                            pv[f] = 0;
                            can[f] = 0;
                            txt1.Text = "";
                            txt2.Text = "";
                            txt3.Text = "";
                            txt4.Text = "";
                            txt5.Text = "";
                            txt6.Text = "";
                            f = 16;
                        }
                    }
                    btn1.Content = "Registrar";

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            MostrarProducto objMostrarProducto = new MostrarProducto();
            this.Visibility = Visibility.Hidden;
            objMostrarProducto.Show();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Principal().ShowDialog();
        }
    }
}
