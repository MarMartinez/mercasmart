using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class EstablecimientosMap
    {

        public static void mapModelToEntity(Establecimiento model, out Entities.Establecimiento entity)
        {
            entity = new Entities.Establecimiento();
            entity.Nombre = model.Nombre;
        }
        public static void mapModelToEntity(List<Establecimiento> models, out List<Entities.Establecimiento> entities)
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

    }
}
