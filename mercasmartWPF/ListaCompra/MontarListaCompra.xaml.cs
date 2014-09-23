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
using System.Collections.ObjectModel;

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
        private ObservableCollection<ProductoListaCompra> _obsProdListaCompra = new ObservableCollection<ProductoListaCompra>();
        
        public ObservableCollection<ProductoListaCompra> ObsProdListaCompra
        {
            get
            {
                if (_obsProdListaCompra == null)
                    _obsProdListaCompra = new ObservableCollection<ProductoListaCompra>();
                return _obsProdListaCompra;
            }
        }
        
        public class CantidadProductosSeleccionados
        {
            public int CantidadSeleccionada { get; set; }
        }

        List<CantidadProductosSeleccionados> numProductosSeleccionados = new List<CantidadProductosSeleccionados>();
       
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
                dgridProducto.Columns[1].Width = dgridProducto.Width;
                dgridProducto.Columns[1].Header = "Selecciona tipo de producto:";

                dgridLista.ItemsSource = new ObservableCollection<ProductoListaCompra>();

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
            
            if (tipoProductoSeleccionado == null)
            {
                MessageBoxResult alerta = MessageBox.Show("Por favor, seleccione un producto.");
            }
            else
            {                
                ProductoListaCompra productoLista = new ProductoListaCompra(tipoProductoSeleccionado, 1);
                _obsProdListaCompra.Add(productoLista);
                dgridLista.ItemsSource = _obsProdListaCompra;
                
            }            
        }

        private void btnAñadirMarca_Click(object sender, RoutedEventArgs e)
        {
            Producto marcaProductoSeleccionado = (Producto)dgridMarca.SelectedItem;
            if (marcaProductoSeleccionado == null)
            {
                MessageBoxResult alerta = MessageBox.Show("Por favor, seleccione una marca.");
            }
            else
            {
                ProductoListaCompra productoLista = new ProductoListaCompra(marcaProductoSeleccionado, 1);
                _obsProdListaCompra.Add(productoLista);
                dgridLista.ItemsSource = _obsProdListaCompra;
            }            
        }

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            ProductoListaCompra productoAEliminar = (ProductoListaCompra)dgridLista.SelectedItem;
            dgridLista.Items.Remove(productoAEliminar);
        }

        private void btnEliminarMarca_Click(object sender, RoutedEventArgs e)
        {
            ProductoListaCompra productoAEliminar = (ProductoListaCompra)dgridLista.SelectedItem;
            dgridLista.Items.Remove(productoAEliminar);
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            mercasmartBusiness.Entities.ListaCompra listaCompra = new mercasmartBusiness.Entities.ListaCompra();

            foreach (var item in dgridLista.Items)
            {
                listaCompra.addProductoListaCompra((ProductoListaCompra)item);
            }

            List<PrecioEstablecimientoListaCompra> calculoPrecioListaCompra = listaCompra.getCalculoPreciosEstablecimientoListaCompra();

            PrecioListaPorEstablecimiento establecimientos = new PrecioListaPorEstablecimiento(calculoPrecioListaCompra);
            establecimientos.Show();
        }

        
    }
}

        
    