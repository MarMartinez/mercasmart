using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartBusiness.ViewModels
{
    class ProductoListaCompra
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string CodigoTipo { get; set; }
        public string CodigoMarca { get; set; }
        public bool esMarcaBlanca { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
