using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping.Entities
{
    class TiposProductoMap
    {

        internal static void mapModelToEntity(mercasmartPersistence.Models.TiposProducto model, out mercasmartBusiness.Entities.TiposProducto entity)
        {
            entity = new mercasmartBusiness.Entities.TiposProducto(model.Codigo);
            entity.Descripcion = model.Descripcion;
        }
        internal static void mapModelToEntity(List<mercasmartPersistence.Models.TiposProducto> models, out List<mercasmartBusiness.Entities.TiposProducto> entities)
        {
            var entitiesCopy = new List<mercasmartBusiness.Entities.TiposProducto>();
            models.ForEach(model =>
            {
                mercasmartBusiness.Entities.TiposProducto entity;
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }

        internal static void mapEntityToModel(mercasmartBusiness.Entities.TiposProducto entity, out mercasmartPersistence.Models.TiposProducto model)
        {
            model = new mercasmartPersistence.Models.TiposProducto();
            model.Descripcion = entity.Descripcion;
            model.Codigo = entity.Codigo;
        }
    }
}
