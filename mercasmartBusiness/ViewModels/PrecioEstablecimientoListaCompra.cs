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
        public double Total { get; set; }
        public List<Producto> ProductosNoDisponibles { get; set; }
    }
}
