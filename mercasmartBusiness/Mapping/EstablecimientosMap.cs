using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class EstablecimientosMap
    {

        internal static void mapModelToEntity(Establecimiento model, out Entities.Establecimiento entity)
        {
            entity = new Entities.Establecimiento();
            entity.Nombre = model.Nombre;
            entity.Codigo = model.Codigo;
        }
        internal static void mapModelToEntity(List<Establecimiento> models, out List<Entities.Establecimiento> entities)
        {
            var entitiesCopy = new List<Entities.Establecimiento>();
            models.ForEach(model =>
            {
                var entity = new Entities.Establecimiento();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }


        internal static void mapEntityToModel(Entities.Establecimiento entity, out Establecimiento model)
        {
            model = new Establecimiento();
            model.Nombre = entity.Nombre;
            model.Codigo = entity.Codigo;
        }
    }
}
