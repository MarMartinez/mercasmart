using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class TiposProducto
    {

        internal static void mapModelToEntity(mercasmartPersistence.Models.TiposProducto model, out Entities.TiposProducto entity)
        {
            entity = new Entities.TiposProducto();
            entity.Codigo = model.Codigo;
            entity.Descripcion = model.Descripcion;
        }
        internal static void mapModelToEntity(List<mercasmartPersistence.Models.TiposProducto> models, out List<Entities.TiposProducto> entities)
        {
            var entitiesCopy = new List<Entities.TiposProducto>();
            models.ForEach(model =>
            {
                var entity = new Entities.TiposProducto();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }

        internal static void mapEntityToModel(Entities.TiposProducto entity, out mercasmartPersistence.Models.TiposProducto model)
        {
            model = new mercasmartPersistence.Models.TiposProducto();
            model.Descripcion = entity.Descripcion;
            model.Codigo = entity.Codigo;
        }
    }
}
