using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence;
using mercasmartPersistence.EntityFramework;

namespace mercasmartBusiness.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }        
    }
}
