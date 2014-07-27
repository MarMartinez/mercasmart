using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartBusiness.Entities
{
    public class ListaCompra
    {

        public List<ProductoListaCompra> ProductosListaCompra { get; set; }

        public List<PrecioEstablecimientoListaCompra> getCalculoPreciosEstablecimientoListaCompra()
        {
            List<PrecioEstablecimientoListaCompra> preciosEstablecimientoListaCompra;

            // Recorrer establecimientos
            listaEstablecimientos = getListaEstablecimientos();
            listaEstablecimientos.foreach(establecimiento =>
            {
                // Recorrer productos lista compra
                ProductosListaCompra.ForEach(productoListaCompra =>
                    {

                        // Si tenemos el id buscamos el producto directamente
                        if (productoListaCompra.idProducto)
		 producto = getProductoEstablecimientoByIdProducto(establecimiento.codigo, productoListaCompra.IdProducto);
                        else
                        // Buscar producto con mejor precio en establecimiento por id producto
                        producto =

                    });
            });

            

        }
    
    }
}
