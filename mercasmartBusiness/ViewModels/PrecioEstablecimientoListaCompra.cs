using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.Entities;

namespace mercasmartBusiness.ViewModels
{
    public class PrecioEstablecimientoListaCompra
    {
        public Establecimiento Establecimiento { get; set; }
        public List<PrecioProductoListaCompra> ProductosDisponibles { get; set; }
        public List<Producto> ProductosNoDisponibles { get; set; }

        private double _total;
        public double Total
        {
            get { return ProductosDisponibles.Sum(producto => producto.PrecioTotal); }
            set { _total = value; }
        }

    }
}
