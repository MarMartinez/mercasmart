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
using mercasmartBusiness.Entities;

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
            List<Producto> listadoProductosNoDisponibles = new List<Producto>();           

            foreach (ProductoListaCompra item in productosNoDisponibles)
            {
                if (item.Producto == null)
                {
                    Producto productoGenerico = new Producto();
                    productoGenerico.Nombre = item.TipoProducto.Descripcion;
                    productoGenerico.Marca = new Marca();
                    productoGenerico.Marca.Nombre = "Qualquier marca";
                    productoGenerico.TipoProducto = new TiposProducto(item.TipoProducto.Codigo);
                    productoGenerico.TipoProducto.Descripcion = item.TipoProducto.Descripcion;

                    listadoProductosNoDisponibles.Add(productoGenerico);
                }
                else
                {
                    Producto productoNoDisponible = new Producto();

                    productoNoDisponible.Nombre = item.Producto.Nombre;
                    productoNoDisponible.Marca = new Marca();
                    productoNoDisponible.Marca.Nombre = item.Producto.Marca.Nombre;
                    productoNoDisponible.TipoProducto = new TiposProducto(item.TipoProducto.Codigo);
                    productoNoDisponible.TipoProducto.Descripcion = item.TipoProducto.Descripcion;

                    listadoProductosNoDisponibles.Add(productoNoDisponible);
                }
            }
            dgridListaProductos.ItemsSource = listadoProductosNoDisponibles;
        }
    }
}
