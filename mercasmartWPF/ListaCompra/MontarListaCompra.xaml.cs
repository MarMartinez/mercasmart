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
    public partial class MontarListaCompra : Window
    {
        public mercasmartBusiness.Services.EstablecimientosService establecimiento;
        public mercasmartBusiness.Services.ProductoService producto;
        public mercasmartBusiness.Services.MarcasServices marca;
        public mercasmartBusiness.Services.TiposProductoService tiposProducto;

        public class listaComprasProductos
        {
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
            // Si el producto no existe en el listView: agregar producto
            // Si el producto ya existe en el listView: sumar producto

            var productoSeleccionado = dgridProductos.SelectedItem;
            string nombreProducto = (productoSeleccionado as mercasmartBusiness.Entities.Producto).nombre;

            if (lViewListaProductos.Items.Contains(producto))
            {
                //S'haurà d'adaptar el sender com a item del grid view.
                //buscar si el llistat de productes ja conté el item selected
                //si el conté --> sumar, sino: afegir.
            }
            else
            {
                
            }
         

        }


        
        

        
    }
}
