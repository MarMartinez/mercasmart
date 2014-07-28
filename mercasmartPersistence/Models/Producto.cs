using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public TiposProducto TipoProducto { get; set; }
    }
}
