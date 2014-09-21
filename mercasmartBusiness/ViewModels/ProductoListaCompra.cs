using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.Entities;
using System.Collections.ObjectModel;

namespace mercasmartBusiness.ViewModels
{
    public class ProductoListaCompra : ObservableCollection<ProductoListaCompra>
    {
        public Producto Producto { get; set; }
        public TiposProducto TipoProducto { get; set; }
        public int Cantidad { get; set; }

        public ProductoListaCompra(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.TipoProducto = this.Producto.TipoProducto;
            this.Cantidad = cantidad;
        }
        public ProductoListaCompra(TiposProducto tipoProducto, int cantidad)
        {            
            this.TipoProducto = tipoProducto;
            this.Cantidad = cantidad;
        }

    }
}
