using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartBusiness.Entities
{
    public class TiposProducto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public TiposProducto(string codigo)
        {
            this.Codigo = codigo;
            this.Descripcion = this.Codigo;
        }

    }
}
