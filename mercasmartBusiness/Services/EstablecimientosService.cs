using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Services
{
    public class EstablecimientosService
    {

        public List<Entities.Establecimiento> getEstablecimientosAll()
        {
            var establimientos = new List<Entities.Establecimiento>();


            return establimientos;
        }

        #region Mapping

        void mapModelToEntity(Establecimiento model, ref Entities.Establecimiento entity)
        {
            entity.Nombre = model.Nombre;
        }
        void mapModelToEntity(List<Establecimiento> models, out List<Entities.Establecimiento> entities)
        {
            var entitiesCopy = new List<Entities.Establecimiento>();
            models.ForEach(model => {
                var entity = new Entities.Establecimiento();
                mapModelToEntity(model, ref entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }

        #endregion


    }
}
