using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.Entities;

namespace mercasmartBusiness.ViewModels
{
    public class PrecioProductoListaCompra
    {
        public Producto Producto { get; set; }
        public double PrecioUnidad { get; private set; }
        public double PrecioTotal { get; private set; }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; setPrecioTotal(); }
        }

        public PrecioProductoListaCompra(Producto producto, double precioUnidad, int cantidad)
        {
            this.Producto = producto;
            this.PrecioUnidad = precioUnidad;
            this.Cantidad = cantidad;
        }

        private void setPrecioTotal()
        {
            this.PrecioTotal = this.Cantidad * this.PrecioUnidad;
        }

    }
}
