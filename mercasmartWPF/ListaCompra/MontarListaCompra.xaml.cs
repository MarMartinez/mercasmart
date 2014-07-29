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
using mercasmartBusiness.ViewModels;
using mercasmartBusiness.Entities;
using mercasmartWPF.ListaCompra;

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
                dgridProducto.AutoGenerateColumns = true;
                //dgridProducto.Columns[1].MinWidth = dgridProducto.Width;
                dgridProducto.ItemsSource = listaTiposProducto;
                dgridProducto.Columns[0].Visibility = System.Windows.Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBoxResult mensajeError = MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void dgridProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                producto = new mercasmartBusiness.Services.ProductoService();
                
                TiposProducto tipoProductoSeleccionado = (TiposProducto)(sender as DataGrid).SelectedItem;
                string codigoTipoProducto = tipoProductoSeleccionado.Codigo;
                List<Producto> listaProductosConMarca = new List<Producto>();
                listaProductosConMarca = producto.getProductosPorTipo(codigoTipoProducto);
                dgridMarca.ItemsSource = listaProductosConMarca;
            }
            catch (Exception ex)
            {
                MessageBoxResult mensajeError = MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnAñadirProducto_Click(object sender, RoutedEventArgs e)
        {
            TiposProducto tipoProductoSeleccionado = (TiposProducto)dgridProducto.SelectedItem;
            ProductoListaCompra productoLista = new ProductoListaCompra(tipoProductoSeleccionado, 1);            
            dgridLista.Items.Add(productoLista);
        }

        private void btnAñadirMarca_Click(object sender, RoutedEventArgs e)
        {
            Producto marcaProductoSeleccionado = (Producto)dgridMarca.SelectedItem;
            ProductoListaCompra productoLista = new ProductoListaCompra(marcaProductoSeleccionado, 1);
            dgridLista.Items.Add(productoLista);
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            mercasmartBusiness.Entities.ListaCompra listaCompra = new mercasmartBusiness.Entities.ListaCompra();
            foreach (var item in dgridLista.Items)
            {
                listaCompra.addProductoListaCompra((ProductoListaCompra)item);
            }
            //var x = listaCompra.getCalculoPreciosEstablecimientoListaCompra();

            //Cambiar ventana
            
            PrecioListaPorEstablecimiento establecimientos = new PrecioListaPorEstablecimiento(listaCompra);
            establecimientos.Show();
        }
    }
}

        
    