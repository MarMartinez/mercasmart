using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class ProductosEstablecimientoMap
    {

        internal static void mapModelToEntity(RelacionProductoEstablecimiento model, out Entities.Marca entity)
        {
            entity = new Entities.Marca();
            entity.Nombre = model.Nombre;
            entity.Codigo = model.Codigo;
            entity.MarcaBlanca = model.MarcaBlanca;
        }
        internal static void mapModelToEntity(List<Marca> models, out List<Entities.Marca> entities)
        {
            var entitiesCopy = new List<Entities.Marca>();
            models.ForEach(model =>
            {
                var entity = new Entities.Marca();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }


        internal static void mapEntityToModel(Entities.Marca entity, out Marca model)
        {
            model = new Marca();
            model.Nombre = entity.Nombre;
            model.Codigo = entity.Codigo;
            model.MarcaBlanca = entity.MarcaBlanca;
        }
    }
}
