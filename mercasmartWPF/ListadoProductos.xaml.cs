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
    /// Interaction logic for ListadoProductos.xaml
    /// </summary>
    public partial class ListadoProductos : Window
    {
        public ListadoProductos()
        {
            InitializeComponent();
        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Sacar datos de base de datos.            
        }
    }
}
