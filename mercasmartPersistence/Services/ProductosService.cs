using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class ProductosService
    {
        public List<Models.Producto> getProductosAll()
        {
            using (var db = new mercasmartEntities())
            {
                var listadoProductos = getProductosAll(db).ToList();
                List<Models.Producto> modelProductos;
                EntityFramework.Mapping.ProductosMap.mapEntityFrameworkToModel(listadoProductos, out modelProductos);
                return modelProductos;
            }
        }

        private IQueryable<Productos> getProductosAll(mercasmartEntities db)
        {
            var productos = db.Productos;
            return productos;

            //var productos = from prod in db.Productos
            //                join tipoProd in db.TiposProducto on prod.codigoTipoProducto equals tipoProd.codigoTipoProducto
            //                join marca in db.Marcas on prod.codigoMarca equals marca.codigoMarca
            //                join relEst in db.RelacionProductoEstablecimiento on prod.idProducto equals relEst.idProducto
            //                join relEstPrecio in db.RelacionProductoEstablecimientoPrecioVigencia on relEst.idRelacion equals relEstPrecio.idRelacionProductoEstablecimiento
            //                select new {
            //                    nombre = prod.nombre,
            //                    marca = marca.nombreMarca,
            //                    tipoProducto = tipoProd.descripcionProducto,
            //                    establecimiento = relEst.codigoEstablecimiento,
            //                    precio = relEstPrecio.precio
            //                };
            //return (List<Models.Producto>)productos;
        }

    }
}
