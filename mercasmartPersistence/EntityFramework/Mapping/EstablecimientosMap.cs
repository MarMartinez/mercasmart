using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class EstablecimientosMap
    {

        static public void mapEntityFrameworkToModel(Establecimientos efModel, out Models.Establecimiento model)
        {
            model = new Models.Establecimiento();
            model.Nombre = efModel.nombreEstablecimiento;
        }
        static public void mapEntityFrameworkToModel(List<Establecimientos> efModels, out List<Models.Establecimiento> models)
        {
            var modelsCopy = new List<Models.Establecimiento>();
            efModels.ForEach(efModel =>
            {
                Models.Establecimiento model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

    }
}
