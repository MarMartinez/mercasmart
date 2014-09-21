using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartBusiness.ViewModels;
using mercasmartBusiness.Services;

namespace mercasmartBusiness.Entities
{
    public class mmpListaCompra
    {
        private ProductoListaCompra productoLista;
        public ProductoListaCompra getProductoListaCompra() { return productoLista; }
        public void setProductoListaCompra(ProductoListaCompra productoLista) { this.productoLista = productoLista; }

        public PrecioEstablecimientoListaCompra getCalculoPreciosEstablecimientoListaCompra()
        {
            PrecioEstablecimientoListaCompra precioEstablecimientoInsertado = new PrecioEstablecimientoListaCompra();
            
            // Recorrer establecimientos
            List<Establecimiento> listaEstablecimientos = getListaEstablecimientos();
            listaEstablecimientos.ForEach(establecimiento =>
            {

                // Nuevo precio establecimiento
                precioEstablecimientoInsertado = new PrecioEstablecimientoListaCompra(establecimiento);

                // Analizamos el productoLista

                    ProductoEstablecimientoPrecio productoPrecio;

                    // Si no tenemos el producto buscaremos el producto mas economico por tipo
                    if (productoLista.Producto == null)
                        productoPrecio = getProductoEconomicoByEstablecimientoTipoProducto(establecimiento.Codigo, productoLista.TipoProducto.Codigo);
                    else
                        productoPrecio = getProductoByEstablecimientoIdProducto(establecimiento.Codigo, productoLista.Producto.IdProducto);

                    if (productoPrecio == null)
                        precioEstablecimientoInsertado.addProductoListaCompraNoDisponible(productoLista);
                    else
                        precioEstablecimientoInsertado.addProductoDisponible(productoPrecio.Producto, productoPrecio.Precio, productoLista.Cantidad);
               
            });

            return precioEstablecimientoInsertado;
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
