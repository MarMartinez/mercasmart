using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class RelacionProdcutoEstablecimientoMap
    {

        internal static void mapEntityFrameworkToModel(RelacionProductoEstablecimiento efModel, out Models.RelacionProductoEstablecimiento model)
        {
            model = new Models.RelacionProductoEstablecimiento();
            model.IdProducto = efModel.idRelacion;
            model.CodigoEstablecimiento = efModel.codigoEstablecimiento;
        }
        internal static void mapEntityFrameworkToModel(List<RelacionProductoEstablecimiento> efModels, out List<Models.RelacionProductoEstablecimiento> models)
        {
            var modelsCopy = new List<Models.RelacionProductoEstablecimiento>();
            efModels.ForEach(efModel =>
            {
                Models.RelacionProductoEstablecimiento model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

        internal static void mapModelToEntityFramework(Models.RelacionProductoEstablecimiento model, ref RelacionProductoEstablecimiento efModel)
        {
            efModel.idRelacion = model.IdProducto;
            efModel.codigoEstablecimiento = model.CodigoEstablecimiento;
        }

    }
}
