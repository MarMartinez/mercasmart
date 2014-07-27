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
            PrecioEstablecimientoListaCompra precioEstablecimientoInsertado;
            List<PrecioEstablecimientoListaCompra> preciosEstablecimientoListaCompra = new List<PrecioEstablecimientoListaCompra>();

            // Recorrer establecimientos
            List<Establecimiento> listaEstablecimientos = getListaEstablecimientos();
            listaEstablecimientos.ForEach(establecimiento =>
            {

                // Nuevo precio establecimiento
                precioEstablecimientoInsertado = new PrecioEstablecimientoListaCompra { Establecimiento = establecimiento };

                // Recorrer productos lista compra
                ProductosListaCompra.ForEach(productoListaCompra =>
                {

                    ProductoEstablecimientoPrecio productoPrecio;

                    // Si no tenemos el producto buscaremos el producto mas economico por tipo
                    if (productoListaCompra.Producto == null)
                        productoPrecio = getProductoEconomicoByEstablecimientoTipoProducto(establecimiento.Codigo, productoListaCompra.TipoProducto.Codigo);
                    else
                        productoPrecio = getProductoByEstablecimientoIdProducto(establecimiento.Codigo, productoListaCompra.Producto.IdProducto);

                    if (productoPrecio == null)
                        precioEstablecimientoInsertado.ProductosNoDisponibles.Add(productoPrecio.Producto);
                    else
                        precioEstablecimientoInsertado.ProductosDisponibles.Add(new PrecioProductoListaCompra
                        {
                            Producto = productoPrecio.Producto,
                            PrecioUnidad = productoPrecio.Precio,
                            PrecioTotal = productoPrecio.Precio * productoListaCompra.Cantidad
                        });

                    // Add del calculo para el establecimiento
                    preciosEstablecimientoListaCompra.Add(precioEstablecimientoInsertado);

                });
            });

            return preciosEstablecimientoListaCompra;
        }

        private ProductoEstablecimientoPrecio getProductoByEstablecimientoIdProducto(string codigoEstablecimiento, int idProducto)
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
