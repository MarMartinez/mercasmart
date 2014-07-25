using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class TiposProductoService
    {

        public List<Models.TiposProducto> getTiposProductosAll()
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var listTiposProducto = getTiposProductoAll(db).ToList();
                List<Models.TiposProducto> modelTiposProductos;
                EntityFramework.Mapping.TiposProductoMap.mapEntityFrameworkToModel(listTiposProducto, out modelTiposProductos);
                return modelTiposProductos;                
            }
        }        

        private IQueryable<TiposProducto> getTiposProductoAll(mercasmartEntities db)
        {
            var tiposProducto = db.TiposProducto;
            return tiposProducto;
        }       

    }
}  
