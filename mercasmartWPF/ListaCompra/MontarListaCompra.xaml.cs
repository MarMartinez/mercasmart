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
using System.Collections;

namespace mercasmartWPF
{
    /// <summary>
    /// Interaction logic for ListaCompraSupermercado.xaml
    /// </summary>
    public partial class MontarListaCompra : Window
    {
        public mercasmartBusiness.Services.EstablecimientosService establecimiento;
        public mercasmartBusiness.Services.ProductoService producto;
        public mercasmartBusiness.Services.MarcasServices marca;
        public mercasmartBusiness.Services.TiposProductoService tiposProducto;
        List<ProductoListaCompra> listaProductosCompra = new List<ProductoListaCompra>();

        private class ProductoListaCompra
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
        }

        public MontarListaCompra()
        {
            InitializeComponent();
        }

        private void ListaCompraSupermercado_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tiposProducto = new mercasmartBusiness.Services.TiposProductoService();
                List<mercasmartBusiness.Entities.TiposProducto> listaTiposProducto = tiposProducto.getTiposProductoAll();
                List<string> datosComboboxProductos = new List<string>();
                foreach (mercasmartBusiness.Entities.TiposProducto prod in listaTiposProducto)
                {
                    datosComboboxProductos.Add(prod.Descripcion);
                }
                cboxProductos.ItemsSource = datosComboboxProductos; 
            }
            catch (Exception ex)
            {   
                MessageBoxResult mensajeError = MessageBox.Show("ERROR: " + ex.Message);
            }         
        }

        private void cboxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string productoSeleccionado = (sender as ComboBox).SelectedItem.ToString();
            producto = new mercasmartBusiness.Services.ProductoService();
            List<mercasmartBusiness.Entities.Producto> listadoProductosPorTipo = producto.getProductosPorTipo(productoSeleccionado);
            dgridProductos.ItemsSource = listadoProductosPorTipo;
            dgridProductos.AutoGenerateColumns = true;
        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            // fer gridView amb ProductoListaCompra de sortida
            // mirar com s'afegeixen nous camps a un gridView
            
            //ProductoListaCompra productoListaCompra = new ProductoListaCompra();
            //var productoSeleccionado = dgridProductos.SelectedItem;

            //string nombreProducto = (productoSeleccionado as mercasmartBusiness.Entities.Producto).nombre;
            //productoListaCompra.Nombre = nombreProducto;
            //productoListaCompra.Cantidad = 1;
            ////lViewListaProductos.
            

            //if (lViewListaProductos.Items.Contains(productoListaCompra))
            //{
            //    listaProductosCompra.Where(prod => prod.Nombre.Equals(nombreProducto)).First().Cantidad += 1;
            //}
            //else
            //{
            //    lViewListaProductos.Items.Add(productoListaCompra);                
            //}         

        }
        
    }
}
