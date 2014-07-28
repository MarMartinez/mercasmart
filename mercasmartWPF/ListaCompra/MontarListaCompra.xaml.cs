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

        private class productoListadoMarca
        {
            internal Producto Producto { get; set; }
            internal string DescripcionProducto { get; set; }
            internal string NombreMarca { get; set; }
        }
        List<productoListadoMarca> listaProductosPorTipoYMarca;

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
                productoListadoMarca productoPorMarca = new productoListadoMarca();
                listaProductosPorTipoYMarca = new List<productoListadoMarca>();

                TiposProducto tipoProductoSeleccionado = (TiposProducto)(sender as DataGrid).SelectedItem;
                string codigoTipoProducto = tipoProductoSeleccionado.Codigo;
                List<Producto> listaProductosConMarca = new List<Producto>();
                listaProductosConMarca = producto.getProductosPorTipo(codigoTipoProducto);
                foreach (var prod in listaProductosCompra)
                {
                    productoPorMarca.Producto = prod.Producto;
                    productoPorMarca.DescripcionProducto = prod.TipoProducto.Codigo;
                    productoPorMarca.NombreMarca = prod.Producto.Marca.Nombre;
                    listaProductosPorTipoYMarca.Add(productoPorMarca);
                }
                dgridMarca.ItemsSource = listaProductosCompra;
                dgridMarca.AutoGenerateColumns = true;
                dgridLista.Columns[0].Visibility = System.Windows.Visibility.Hidden;

            }
            catch (Exception ex)
            {
                MessageBoxResult mensajeError = MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}

        
    