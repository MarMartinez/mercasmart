using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping.Entities
{
    class MarcasMap
    {

        internal static void mapModelToEntity(Marca model, out mercasmartBusiness.Entities.Marca entity)
        {
            entity = new mercasmartBusiness.Entities.Marca();
            entity.Nombre = model.Nombre;
            entity.Codigo = model.Codigo;
            entity.MarcaBlanca = model.MarcaBlanca;
        }
        internal static void mapModelToEntity(List<Marca> models, out List<mercasmartBusiness.Entities.Marca> entities)
        {
            var entitiesCopy = new List<mercasmartBusiness.Entities.Marca>();
            models.ForEach(model =>
            {
                var entity = new mercasmartBusiness.Entities.Marca();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }

        internal static void mapEntityToModel(mercasmartBusiness.Entities.Marca entity, out Marca model)
        {
            model = new Marca();
            model.Nombre = entity.Nombre;
            model.Codigo = entity.Codigo;
            model.MarcaBlanca = entity.MarcaBlanca;
        }
    }
}
