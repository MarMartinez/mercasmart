using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class EstablecimientosMap
    {

        internal static void mapEntityFrameworkToModel(Establecimientos efModel, out Models.Establecimiento model)
        {
            model = new Models.Establecimiento();
            model.Nombre = efModel.nombreEstablecimiento;
            model.Codigo = efModel.codigoEstablecimiento;
        }
        internal static void mapEntityFrameworkToModel(List<Establecimientos> efModels, out List<Models.Establecimiento> models)
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

        internal static void mapModelToEntityFramework(Models.Establecimiento model, ref Establecimientos efModel)
        {
            efModel.nombreEstablecimiento = model.Nombre;
            efModel.codigoEstablecimiento = model.Codigo;
        }

    }
}
