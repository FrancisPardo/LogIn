﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogIn
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnSomos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            Quienes objQuienes = new Quienes();
            this.Visibility = Visibility.Hidden;
            objQuienes.Show();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            Cerrar objCerrar = new Cerrar();
            this.Visibility = Visibility.Hidden;
            objCerrar.Show();
            // Click = "Open"
        }

        private void Producto(object sender, RoutedEventArgs e)
        {
            Producto objProducto = new Producto();
            this.Visibility = Visibility.Hidden;
            objProducto.Show();
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Esta seguro que desea \"Salir\"?", "LogIn", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    this.Show();
                    break;
            }
        }

        private void Ventas(object sender, RoutedEventArgs e)
        {
            MostrarVenta objMostrarVenta = new MostrarVenta();
            this.Visibility = Visibility.Hidden;
            objMostrarVenta.Show();
        }

        private void BtnReportes_Click(object sender, RoutedEventArgs e)
        {
            TotalVentas objReporte = new TotalVentas();
            this.Visibility = Visibility.Hidden;
            objReporte.Show();
        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            NuevoUsuario objUsuario = new NuevoUsuario();
            this.Visibility = Visibility.Hidden;
            objUsuario.Show();
        }
    }
}
