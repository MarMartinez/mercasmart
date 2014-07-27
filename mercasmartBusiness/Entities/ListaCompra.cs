using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.ViewModels;
using mercasmartBusiness.Services;

namespace mercasmartBusiness.Entities
{
    public class ListaCompra
    {

        public List<ProductoListaCompra> ProductosListaCompra { get; set; }

        public List<PrecioEstablecimientoListaCompra> getCalculoPreciosEstablecimientoListaCompra()
        {
            List<PrecioEstablecimientoListaCompra> preciosEstablecimientoListaCompra = new List<PrecioEstablecimientoListaCompra>();

            // Recorrer establecimientos
            List<Establecimiento> listaEstablecimientos = getListaEstablecimientos();
            listaEstablecimientos.ForEach(establecimiento =>
            {
                // Recorrer productos lista compra
                ProductosListaCompra.ForEach(productoListaCompra =>
                {

                    Producto producto;

                    // Si no tenemos el producto buscaremos el producto mas economico por tipo
                    if (productoListaCompra.Producto == null)
                        producto = getProductoEconomicoByEstablecimientoTipoProducto(establecimiento.Codigo, productoListaCompra.TipoProducto.Codigo);

                });
            });

            return preciosEstablecimientoListaCompra;
        }


        private Producto getProductoEconomicoByEstablecimientoTipoProducto(string codigoEstablecimiento, string codigoTipoProducto)
        {
            // Get lista productos establecimiento
            var productos = getProductosByCodigoEstablecimiento(codigoEstablecimiento);

            // Select producto con precio mas bajo
            var productoEconomico = productos.Where(producto => producto.Producto.TipoProducto.Codigo.Equals(codigoTipoProducto)).OrderBy(producto => producto.Precio).FirstOrDefault();

            return productoEconomico.Producto;
        }

        List<ProductoEstablecimientoPrecio> _productosByCodigoEstablecimiento;
        private List<ProductoEstablecimientoPrecio> getProductosByCodigoEstablecimiento(string codigoEstablecimiento)
        {
            if (_productosByCodigoEstablecimiento == null)
                _productosByCodigoEstablecimiento = new EstablecimientosService().getProductosPorCodigoEstablecimiento(codigoEstablecimiento);
            return _productosByCodigoEstablecimiento;
        }

        List<Establecimiento> _listaEstablecimientos;
        private List<Establecimiento> getListaEstablecimientos()
        {
            if (_listaEstablecimientos == null)
                _listaEstablecimientos = new EstablecimientosService().getEstablecimientosAll();
            return _listaEstablecimientos;
        }


    
    }
}
