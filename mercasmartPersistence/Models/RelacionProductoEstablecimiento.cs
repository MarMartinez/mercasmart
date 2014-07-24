using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.Models
{
    public class RelacionProductoEstablecimiento
    {
        public int IdRelacion { get; set; }
        public int IdProducto { get; set; }
        public string CodigoEstablecimiento { get; set; }

        public Producto Producto { get; set; }
        public Establecimiento Establecimiento { get; set; }

        public RelacionProductoEstablecimientoPrecioVigencia RelacionProductoEstablecimientoPrecioVigencia { get; set; }
        
    }
}
