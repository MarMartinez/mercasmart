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

namespace mercasmartWPF.ListaCompra
{
    /// <summary>
    /// Interaction logic for PrecioListaPorEstablecimiento.xaml
    /// </summary>
    public partial class PrecioListaPorEstablecimiento : Window
    {
        public PrecioListaPorEstablecimiento()
        {
            InitializeComponent();
        }

        public PrecioListaPorEstablecimiento(mercasmartBusiness.Entities.ListaCompra listaCompra)
        {
            // barra d'estat carregant per fils cada establiment.
            InitializeComponent();
            dgridListadoPrecios.ItemsSource = listaCompra.getCalculoPreciosEstablecimientoListaCompra();
            dgridListadoPrecios.AutoGenerateColumns = true;
        }

        //s'ha de poder modificar la llista!!
        // listView amb preu total per establiment de la llista seleccionada
        // al seleccionar un establiment, s'hauria de poder ensenyar els preus de cada producto, quin hi ha, quin no hi ha...(quin no hi ha??)
    }
}
