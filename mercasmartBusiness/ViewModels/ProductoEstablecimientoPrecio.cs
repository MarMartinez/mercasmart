using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.Entities;

namespace mercasmartBusiness.ViewModels
{
    public class ProductoEstablecimientoPrecio
    {
        public Producto Producto { get; set; }
        public Establecimiento Establecimiento { get; set; }
        public double Precio { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
