using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.Entities;

namespace mercasmartBusiness.ViewModels
{
    public class PrecioProductoListaCompra
    {
        public Producto Producto { get; set; }
        public double PrecioUnidad { get; set; } // Precio del producto en el establecimiento seleccionado
        public double PrecioTotal { get; set; }        
    }
}
