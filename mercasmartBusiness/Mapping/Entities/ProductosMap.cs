using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping.Entities
{
    class ProductosMap
    {
        internal static void mapModelToEntity(Producto model, out mercasmartBusiness.Entities.Producto entity)
        {
            mercasmartBusiness.Entities.Marca marca;
            
            entity = new mercasmartBusiness.Entities.Producto();
            Mapping.Entities.MarcasMap.mapModelToEntity(model.Marca, out marca);

            entity.IdProducto = model.IdProducto;
            entity.Nombre = model.Nombre;
            entity.Marca = marca;
        }
        internal static void mapModelToEntity(List<Producto> models, out List<mercasmartBusiness.Entities.Producto> entities)
        {
            var entitiesCopy = new List<mercasmartBusiness.Entities.Producto>();
            models.ForEach(model =>
            {
                var entity = new mercasmartBusiness.Entities.Producto();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }


        internal static void mapEntityToModel(mercasmartBusiness.Entities.Producto entity, out Producto model)
        {
            model = new Producto();
            mercasmartPersistence.Models.Marca marca;
            Mapping.Entities.MarcasMap.mapEntityToModel(entity.Marca, out marca);

            model.IdProducto = entity.IdProducto;
            model.Nombre= entity.Nombre;
            model.Marca = marca;
        }
    }
}
