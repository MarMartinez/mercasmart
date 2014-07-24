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
using mercasmartBusiness;

namespace mercasmartWPF
{
    /// <summary>
    /// Interaction logic for ListaCompraSupermercado.xaml
    /// </summary>
    public partial class ListaCompraSupermercado : Window
    {
        public mercasmartBusiness.Services.EstablecimientosService establecimiento;
        public mercasmartBusiness.Services.ProductoService producto;
        public mercasmartBusiness.Services.MarcasServices marca;
        public ListaCompraSupermercado()
        {
            InitializeComponent();          
        }

        private void ListaCompraSupermercado_Loaded(object sender, RoutedEventArgs e)
        {
            producto = new mercasmartBusiness.Services.ProductoService();
            List<mercasmartBusiness.Entities.Producto> listadoProductos = producto.getProductosPorTipo();
            List<string> datosComboboxProductos = new List<string>();
            foreach (mercasmartBusiness.Entities.Producto prod in listadoProductos)
            {
                datosComboboxProductos.Add(prod.nombre);
            }
            cboxProductos.ItemsSource = datosComboboxProductos;
        }

        private void chekMarca_checked(object sender, RoutedEventArgs e)
        {
            cboxMarcas.IsEnabled = true;
            marca = new mercasmartBusiness.Services.MarcasServices();
            List<mercasmartBusiness.Entities.Marca> listadoMarcas = marca.getMarcasNoBlancasAll();
            List<string> datosComboboxMarcas = new List<string>();
            foreach (mercasmartBusiness.Entities.Marca marqa in listadoMarcas)
            {
                datosComboboxMarcas.Add(marqa.Nombre);
            }
            cboxMarcas.ItemsSource = datosComboboxMarcas;
        }

        
    }
}
