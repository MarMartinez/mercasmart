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
            
            entity = new mercasmartBusiness.Entities.Producto();

            mercasmartBusiness.Entities.Marca marca;
            Mapping.Entities.MarcasMap.mapModelToEntity(model.Marca, out marca);
            entity.Marca = marca;

            mercasmartBusiness.Entities.TiposProducto tipoProducto;
            Mapping.Entities.TiposProductoMap.mapModelToEntity(model.TipoProducto, out tipoProducto);
            entity.TipoProducto = tipoProducto;

            entity.IdProducto = model.IdProducto;
            entity.Nombre = model.Nombre;
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
