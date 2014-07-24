using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class RelacionProductoEstablecimientoPrecioVigenciaMap
    {

        internal static void mapEntityFrameworkToModel(RelacionProductoEstablecimientoPrecioVigencia efModel, out Models.RelacionProductoEstablecimientoPrecioVigencia model)
        {
            model = new Models.RelacionProductoEstablecimientoPrecioVigencia();
            model.idRelacionProductoEstablecimiento = efModel.idRelacionProductoEstablecimiento;
            model.Precio = (double)efModel.precio;
            model.Desde = efModel.desde;
            model.Hasta = efModel.hasta;
        }
        internal static void mapEntityFrameworkToModel(List<RelacionProductoEstablecimientoPrecioVigencia> efModels, out List<Models.RelacionProductoEstablecimientoPrecioVigencia> models)
        {
            var modelsCopy = new List<Models.RelacionProductoEstablecimientoPrecioVigencia>();
            efModels.ForEach(efModel =>
            {
                Models.RelacionProductoEstablecimientoPrecioVigencia model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

        internal static void mapModelToEntityFramework(Models.RelacionProductoEstablecimientoPrecioVigencia model, ref RelacionProductoEstablecimientoPrecioVigencia efModel)
        {
            efModel.idRelacionProductoEstablecimiento = model.idRelacionProductoEstablecimiento;
            efModel.precio = (decimal)model.Precio;
            efModel.desde = model.Desde;
            efModel.hasta = model.Hasta;
        }

    }
}
