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
using mercasmartBusiness.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace mercasmartWPF.ListaCompra
{
    /// <summary>
    /// Interaction logic for PrecioListaPorEstablecimiento.xaml
    /// </summary>
    public partial class PrecioListaPorEstablecimiento : Window
    {
        private List<PrecioEstablecimientoListaCompra> calculoPrecioListaCompra;

        public class ElementosAMostrarPorPantalla
        {
            public string nombreEstablecimiento { get; set; }
            public int numeroProductos { get; set; }
            public double precioTotal { get; set; }
            public List<PrecioProductoListaCompra> listaDisponibles { get; set; }
            public List<ProductoListaCompra> listaNoDisponibles { get; set; }
        }

        public List<ElementosAMostrarPorPantalla> listadoProductosDisponibles = new List<ElementosAMostrarPorPantalla>();
        public List<ElementosAMostrarPorPantalla> listadoProductosNoDisponibles = new List<ElementosAMostrarPorPantalla>();

        private Thread updateProductosDisponibles;
        private Thread updateProductosNoDisponibles;
        public PrecioListaPorEstablecimiento(List<PrecioEstablecimientoListaCompra> calculoPrecioListaCompra)
        {
            InitializeComponent();
            this.calculoPrecioListaCompra = calculoPrecioListaCompra;        
        }

        private void dgridListadoPrecios_Load(object sender, RoutedEventArgs e)
        {
            //Hilo para cargar productos disponibles
            updateProductosDisponibles = new Thread(getProductosDisponibles);
            updateProductosDisponibles.Start();
        }

        private void dgridListadoNoDisponibles_Load(object sender, RoutedEventArgs e)
        {
            //Hilo para cargar productos no disponibles
            updateProductosNoDisponibles = new Thread(getProductosNoDisponibles);
            updateProductosNoDisponibles.Start();
        }
        
        private void getProductosDisponibles()
        {                     
            foreach (var prod in calculoPrecioListaCompra)
            {
                ElementosAMostrarPorPantalla ItemLista = new ElementosAMostrarPorPantalla();

                if (prod.ProductosDisponibles.Count() > 0)
                {
                    ItemLista.nombreEstablecimiento = prod.Establecimiento.Nombre;
                    ItemLista.numeroProductos = prod.ProductosDisponibles.Count();
                    ItemLista.precioTotal = prod.Total;
                    ItemLista.listaDisponibles = prod.ProductosDisponibles;
                    listadoProductosDisponibles.Add(ItemLista);
                    Dispatcher.BeginInvoke(new ThreadStart(() => dgridListadoPrecios.ItemsSource = listadoProductosDisponibles));
                }       
            }
        }

        private void getProductosNoDisponibles()
        {
            foreach (var prod in calculoPrecioListaCompra)
            {
                ElementosAMostrarPorPantalla ItemLista = new ElementosAMostrarPorPantalla();

                if (prod.ProductosListaCompraNoDisponibles.Count() > 0)
                {
                    ItemLista.nombreEstablecimiento = prod.Establecimiento.Nombre;
                    ItemLista.numeroProductos = prod.ProductosListaCompraNoDisponibles.Count();
                    ItemLista.listaNoDisponibles = prod.ProductosListaCompraNoDisponibles;
                    listadoProductosNoDisponibles.Add(ItemLista);
                    Dispatcher.BeginInvoke(new ThreadStart(() => dgridProductosNoDisponibles.ItemsSource = listadoProductosNoDisponibles));
                }
            }     
                           
        }       

        public void MostrarListadoDisponible(object sender, RoutedEventArgs e)
        {
            ElementosAMostrarPorPantalla establecimientoSeleccionado = (ElementosAMostrarPorPantalla)dgridListadoPrecios.SelectedItem;
            List<PrecioProductoListaCompra> productosDisponibles = establecimientoSeleccionado.listaDisponibles;

            popUp_listaProductosDisponibles vistaProductosEnLista = new popUp_listaProductosDisponibles(productosDisponibles);
            vistaProductosEnLista.Show();

        }

        public void MostrarListadoNoDisponible(object sender, RoutedEventArgs e)
        {
            ElementosAMostrarPorPantalla establecimientoSeleccionado = (ElementosAMostrarPorPantalla)dgridProductosNoDisponibles.SelectedItem;
            List<ProductoListaCompra> productosNoDisponibles = establecimientoSeleccionado.listaNoDisponibles;

            popUp_listaProductosNoDisponibles vistaProductosEnLista = new popUp_listaProductosNoDisponibles(productosNoDisponibles);
            vistaProductosEnLista.Show();

        }       
    }
}
