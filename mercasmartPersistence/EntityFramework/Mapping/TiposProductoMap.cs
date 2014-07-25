using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class TiposProductoMap
    {

        internal static void mapEntityFrameworkToModel(TiposProducto efModel, out Models.TiposProducto model)
        {
            model = new Models.TiposProducto();
            model.Descripcion = efModel.descripcionProducto;
            model.Codigo = efModel.codigoTipoProducto;
        }
        internal static void mapEntityFrameworkToModel(List<TiposProducto> efModels, out List<Models.TiposProducto> models)
        {
            var modelsCopy = new List<Models.TiposProducto>();
            efModels.ForEach(efModel =>
            {
                Models.TiposProducto model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

        internal static void mapModelToEntityFramework(Models.TiposProducto model, ref TiposProducto efModel)
        {
            efModel.codigoTipoProducto = model.Codigo;
            efModel.descripcionProducto = model.Descripcion;
        }

    }
}
