using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class MarcasMap
    {

        internal static void mapEntityFrameworkToModel(Marcas efModel, out Models.Marca model)
        {
            model = new Models.Marca();
            model.Nombre = efModel.nombreMarca;
            model.Codigo = efModel.codigoMarca;
            model.MarcaBlanca = efModel.marcaBlanca;
        }
        internal static void mapEntityFrameworkToModel(List<Marcas> efModels, out List<Models.Marca> models)
        {
            var modelsCopy = new List<Models.Marca>();
            efModels.ForEach(efModel =>
            {
                Models.Marca model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

        internal static void mapModelToEntityFramework(Models.Marca model, ref Marcas efModel)
        {
            efModel.nombreMarca = model.Nombre;
            efModel.codigoMarca = model.Codigo;
            efModel.marcaBlanca = model.MarcaBlanca;
        }

    }
}
