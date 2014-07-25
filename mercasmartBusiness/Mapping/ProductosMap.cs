using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class ProductosMap
    {
        internal static void mapModelToEntity(Producto model, out Entities.Producto entity)
        {
            entity = new Entities.Producto();
            entity.nombre = model.nombre;
            entity.marca = model.marca;
        }
        internal static void mapModelToEntity(List<Producto> models, out List<Entities.Producto> entities)
        {
            var entitiesCopy = new List<Entities.Producto>();
            models.ForEach(model =>
            {
                var entity = new Entities.Producto();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }


        internal static void mapEntityToModel(Entities.Producto entity, out Producto model)
        {
            model = new Producto();
            model.nombre= entity.nombre;
            model.marca = entity.marca;
        }
    }
}
