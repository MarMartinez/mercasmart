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

        public ListaCompra()
        {
            _productosListaCompra = new List<ProductoListaCompra>();
        }

        public List<PrecioEstablecimientoListaCompra> getCalculoPreciosEstablecimientoListaCompra()
        {
            PrecioEstablecimientoListaCompra precioEstablecimientoInsertado;
            List<PrecioEstablecimientoListaCompra> preciosEstablecimientoListaCompra = new List<PrecioEstablecimientoListaCompra>();

            // Recorrer establecimientos
            List<Establecimiento> listaEstablecimientos = getListaEstablecimientos();
            listaEstablecimientos.ForEach(establecimiento =>
            {

                // Nuevo precio establecimiento
                precioEstablecimientoInsertado = new PrecioEstablecimientoListaCompra(establecimiento);

                // Recorrer productos lista compra
                _productosListaCompra.ForEach(productoListaCompra =>
                {

                    ProductoEstablecimientoPrecio productoPrecio;

                    // Si no tenemos el producto buscaremos el producto mas economico por tipo
                    if (productoListaCompra.Producto == null)
                        productoPrecio = getProductoEconomicoByEstablecimientoTipoProducto(establecimiento.Codigo, productoListaCompra.TipoProducto.Codigo);
                    else
                        productoPrecio = getProductoByEstablecimientoIdProducto(establecimiento.Codigo, productoListaCompra.Producto.IdProducto);

                    if (productoPrecio == null)
                        precioEstablecimientoInsertado.addProductoListaCompraNoDisponible(productoListaCompra);
                    else
                        precioEstablecimientoInsertado.addProductoDisponible(productoPrecio.Producto, productoPrecio.Precio, productoListaCompra.Cantidad);

                });

                // Add del calculo para el establecimiento
                preciosEstablecimientoListaCompra.Add(precioEstablecimientoInsertado);

            });

            return preciosEstablecimientoListaCompra;
        }

        private List<ProductoListaCompra> _productosListaCompra { get; set; }
        public void addProductoListaCompra(ProductoListaCompra productoListaCompra)
        {
            _productosListaCompra.Add(productoListaCompra);
        }

        public ProductoEstablecimientoPrecio getProductoByEstablecimientoIdProducto(string codigoEstablecimiento, int idProducto)
        {
            // Get lista productos establecimiento
            var productosEstablecimiento = getProductosByCodigoEstablecimiento(codigoEstablecimiento);

            // Select producto por id
            var productoById = productosEstablecimiento.FirstOrDefault(producto => producto.Producto.IdProducto.Equals(idProducto));

            return productoById;
        }

        private ProductoEstablecimientoPrecio getProductoEconomicoByEstablecimientoTipoProducto(string codigoEstablecimiento, string codigoTipoProducto)
        {
            // Get lista productos establecimiento
            var productosEstablecimiento = getProductosByCodigoEstablecimiento(codigoEstablecimiento);

            // Select producto con precio mas bajo
            var productoEconomico = productosEstablecimiento.Where(producto => producto.Producto.TipoProducto.Codigo.Equals(codigoTipoProducto)).OrderBy(producto => producto.Precio).FirstOrDefault();

            return productoEconomico;
        }

        List<ProductoEstablecimientoPrecio> _productosByCodigoEstablecimiento;
        private List<ProductoEstablecimientoPrecio> getProductosByCodigoEstablecimiento(string codigoEstablecimiento)
        {
            if (_productosByCodigoEstablecimiento == null)
                _productosByCodigoEstablecimiento = new List<ProductoEstablecimientoPrecio>();

            if (!_productosByCodigoEstablecimiento.Any(producto => producto.Establecimiento.Codigo.Equals(codigoEstablecimiento)))
                _productosByCodigoEstablecimiento.AddRange(new EstablecimientosService().getProductosPorCodigoEstablecimiento(codigoEstablecimiento));

            return _productosByCodigoEstablecimiento.Where(producto => producto.Establecimiento.Codigo.Equals(codigoEstablecimiento)).ToList();
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
