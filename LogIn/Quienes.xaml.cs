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
using System.Windows.Shapes;

namespace LogIn
{
    /// <summary>
    /// Lógica de interacción para Quienes.xaml
    /// </summary>
    public partial class Quienes : Window
    {
        public Quienes()
        {
            InitializeComponent();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Principal().ShowDialog();
        }
    }
}
