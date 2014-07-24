using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class RelProdEst_Service
    {

        public List<Models.RelProdEst> getRelacionesProductoEstablecimientoAll()
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var relaciones = getRelacionesAll(db).ToList();
                List<Models.RelProdEst> modelRelProdEst;
                EntityFramework.Mapping.RelProdEst_Map.mapEntityFrameworkToModel(relaciones, out modelRelProdEst);
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
