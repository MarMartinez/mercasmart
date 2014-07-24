using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class RelProdEst_Service
    {

        public List<Models.RelacionProductoEstablecimiento> getRelacionesProductoEstablecimientoAll()
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var relaciones = getRelacionesAll(db).ToList();
                List<Models.RelacionProductoEstablecimiento> modelRelProdEst;
                EntityFramework.Mapping.RelacionProdcutoEstablecimientoMap.mapEntityFrameworkToModel(relaciones, out modelRelProdEst);
                return modelRelProdEst;
            }
        }        
        
        private IQueryable<RelacionProductoEstablecimiento> getRelacionesAll(mercasmartEntities db)
        {
            var relaciones = db.RelacionProductoEstablecimiento;
            return relaciones;
        }

    }
}  
