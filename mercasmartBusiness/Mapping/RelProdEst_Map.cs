using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class RelProdEst_Map
    {

        internal static void mapModelToEntity(RelProdEst model, out Entities.RelProdEst entity)
        {
            entity = new Entities.RelProdEst();
            entity.CodigoEstablecimiento = model.CodigoEstablecimiento;
            entity.IdProducto = model.IdProducto;
        }

        internal static void mapModelToEntity(List<RelProdEst> models, out List<Entities.RelProdEst> entities)
        {
            var entitiesCopy = new List<Entities.RelProdEst>();
            models.ForEach(model =>
            {
                var entity = new Entities.RelProdEst();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }
        
        internal static void mapEntityToModel(Entities.RelProdEst entity, out RelProdEst model)
        {
            model = new RelProdEst();
            model.IdProducto = entity.IdProducto;
            model.CodigoEstablecimiento = entity.CodigoEstablecimiento;
        }
    }
}
