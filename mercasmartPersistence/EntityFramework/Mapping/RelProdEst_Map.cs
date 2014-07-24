using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class RelProdEst_Map
    {

        internal static void mapEntityFrameworkToModel(RelacionProductoEstablecimiento efModel, out Models.RelProdEst model)
        {
            model = new Models.RelProdEst();
            model.CodigoEstablecimiento = efModel.codigoEstablecimiento;
            model.IdProducto = efModel.idRelacion;
        }
        internal static void mapEntityFrameworkToModel(List<RelacionProductoEstablecimiento> efModels, out List<Models.RelProdEst> models)
        {
            var modelsCopy = new List<Models.RelProdEst>();
            efModels.ForEach(efModel =>
            {
                Models.RelProdEst model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

        internal static void mapModelToEntityFramework(Models.RelProdEst model, ref RelacionProductoEstablecimiento efModel)
        {
            efModel.idRelacion = model.IdProducto;
            efModel.codigoEstablecimiento = model.CodigoEstablecimiento;
        }

    }
}
