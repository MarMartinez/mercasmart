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
            //using (var db = new mercasmartEntities())
            //{
            //    var listadoProductos = getProductosAll(db).ToList();

                
            //    var establecimientos = getEstablecimientosAll(db).ToList();
            //    List<Models.Establecimiento> modelEstablecimiento;
            //    EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
            //    return modelEstablecimiento;
            //}
            return null;
        }

        private IQueryable<Productos> getProductosAll(mercasmartEntities db)
        {
            //var productos = from prod in db.Productos
            //                join tipoProd in db.TiposProducto on prod.codigoTipoProducto equals tipoProd.codigoTipoProducto
            //                join relEst in db.





            //"select PR.nombre, MA.nombreMarca, TP.codigoTipoProducto, RELPRE.codigoEstablecimiento, RELPREV.precio"
            //"from [Productos] as PR"
            //left join [Marcas] as MA
            //on PR.codigoMarca = MA.codigoMarca
            //left join [TiposProducto] as TP
            //on PR.codigoTipoProducto = TP.codigoTipoProducto
            //left join [RelacionProductoEstablecimiento] as RELPRE
            //on PR.idProducto = RELPRE.idProducto
            //left join [RelacionProductoEstablecimientoPrecioVigencia] as RELPREV
            //on RELPRE.idRelacion = RELPREV.idRelacionProductoEstablecimiento"
            //return establecimientos;
            return null;
        }

    }
}
