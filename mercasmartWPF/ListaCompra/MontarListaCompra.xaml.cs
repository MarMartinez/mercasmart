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
            //canvi de producto por tipo producto !! (tipoProducto)
            //producto = new mercasmartBusiness.Services.ProductoService();
            //List<mercasmartBusiness.Entities.Producto> listadoProductos = producto.getProductosPorTipo();
            List<string> datosComboboxProductos = new List<string>();
            //foreach (mercasmartBusiness.Entities.Producto prod in listadoProductos)
            //{
            //    datosComboboxProductos.Add(prod.nombre);
            //}
            datosComboboxProductos.Add("yogur");
            datosComboboxProductos.Add("champu");
            datosComboboxProductos.Add("leche");
            cboxProductos.ItemsSource = datosComboboxProductos;            
        }

        private void cboxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string productoSeleccionado = (sender as ComboBox).SelectedItem.ToString();
            producto = new mercasmartBusiness.Services.ProductoService();
            List<mercasmartBusiness.Entities.Producto> listadoProductosPorTipo = producto.getProductosPorTipo();
            dgridProductos.ItemsSource = listadoProductosPorTipo;
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            

        }


        
        

        
    }
}
