﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.Entities;

namespace mercasmartBusiness.ViewModels
{
    public class ProductoListaCompra
    {
        public Producto Producto { get; set; }
        public TiposProducto TipoProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
