using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mercasmartWPF.ListaCompra;
using System.Collections.ObjectModel;

namespace mercasmartWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnObtenerProductos_Click(object sender, RoutedEventArgs e)
        {
            ListadoProductos nuevaVentanaProductos = new ListadoProductos();
            nuevaVentanaProductos.Show();
            this.Close();
        }

        private void btnListaProductosSupermercado_Click(object sender, RoutedEventArgs e)
        {
            MontarListaCompra nuevaVentanaListaSupermercado = new MontarListaCompra();
            nuevaVentanaListaSupermercado.Show();
            this.Close();
        }
    }
}
