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
        public List<PrecioProductoListaCompra> ProductosDisponibles { get; private set; }
        public List<ProductoListaCompra> ProductosListaCompraNoDisponibles { get; private set; }

        private double _total;
        public double Total
        {
            get { return ProductosDisponibles.Sum(producto => producto.PrecioTotal); }
            set { _total = value; }
        }

        public PrecioEstablecimientoListaCompra(Establecimiento establecimiento)
        {
            this.Establecimiento = establecimiento;
            this.ProductosDisponibles = new List<PrecioProductoListaCompra>();
            this.ProductosListaCompraNoDisponibles = new List<ProductoListaCompra>();
        }

        public void addProductoDisponible(Producto producto, double precioUnidad, int cantidad)
        {
            ProductosDisponibles.Add(new PrecioProductoListaCompra(producto, precioUnidad, cantidad));
        }

        public void addProductoListaCompraNoDisponible(ProductoListaCompra productoListaCompra)
        {
            ProductosListaCompraNoDisponibles.Add(productoListaCompra);
        }

    }
}
