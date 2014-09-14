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
using mercasmartBusiness.Entities;
using mercasmartBusiness.Services;
using mercasmartBusiness.ViewModels;

namespace mercasmartWPF
{
    /// <summary>
    /// Interaction logic for ListadoProductos.xaml
    /// </summary>
    public partial class ListadoProductos : Window
    {
        EstablecimientosService establecimientosServ = new EstablecimientosService();
        TiposProductoService tipoProductoServ = new TiposProductoService();
        ProductoService productoServ = new ProductoService();
        List<TiposProducto> selectorProductos = new List<TiposProducto>();
        List<Producto> listaProductosSegunSeleccion = new List<Producto>();
        List<PrecioProductoListaCompra> listaPreciosPorEstablecimiento = new List<PrecioProductoListaCompra>();
        mercasmartBusiness.Entities.ListaCompra entityListaCompra = new mercasmartBusiness.Entities.ListaCompra();
        
        public ListadoProductos()
        {
            InitializeComponent();
            selectorProductos = tipoProductoServ.getTiposProductoAll();
            cboxSeleccionProducto.ItemsSource = selectorProductos.Select(prod => prod.Descripcion);
        }
        
        private void cboxSeleccionProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string productoSeleccionado = (string)(sender as ComboBox).SelectedItem;
            string tipoProductoSeleccionado = selectorProductos.Where(prod => prod.Descripcion == productoSeleccionado).FirstOrDefault().Codigo;
            listaProductosSegunSeleccion = productoServ.getProductosPorTipo(tipoProductoSeleccionado);
            
            //Obtener precio producto según establecimiento

            List<Establecimiento> listadoEstablecimientos = establecimientosServ.getEstablecimientosAll();
            ProductoEstablecimientoPrecio precioItemPorEstablecimiento = new ProductoEstablecimientoPrecio();
            List<ProductoEstablecimientoPrecio> listadoProductosPrecios = new List<ProductoEstablecimientoPrecio>();
            
            foreach (var establecimiento in listadoEstablecimientos)
            {
                foreach (var item in listaProductosSegunSeleccion)
                {                    
                    precioItemPorEstablecimiento = entityListaCompra.getProductoByEstablecimientoIdProducto(establecimiento.Codigo, item.IdProducto);
                    if (precioItemPorEstablecimiento != null)
                    {
                        listadoProductosPrecios.Add(precioItemPorEstablecimiento);
                    }                    
                }
            }
            dgridProducto.ItemsSource = listadoProductosPrecios.OrderBy(prod => prod.Producto.Marca.Nombre);
        }
    }
}
