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
using System.Windows.Shapes;
using mercasmartWPF.ListaCompra;
using mercasmartBusiness.ViewModels;

namespace mercasmartWPF.ListaCompra
{
    /// <summary>
    /// Interaction logic for popUp_listaProductos.xaml
    /// </summary>
    public partial class popUp_listaProductosNoDisponibles : Window
    {
        public popUp_listaProductosNoDisponibles(List<ProductoListaCompra> productosNoDisponibles)
        {
            InitializeComponent();
            dgridListaProductos.ItemsSource = productosNoDisponibles;
        }
    }
}
