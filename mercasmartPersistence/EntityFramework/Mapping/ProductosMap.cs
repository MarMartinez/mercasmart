﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercasmartPersistence.EntityFramework.Mapping
{
    public class ProductosMap
    {

        internal static void mapEntityFrameworkToModel(Productos efModel, out Models.Producto model)
        {
            model = new Models.Producto();
            model.nombre = efModel.nombre;
            model.marca = efModel.codigoMarca;
        }
        internal static void mapEntityFrameworkToModel(List<Productos> efModels, out List<Models.Producto> models)
        {
            var modelsCopy = new List<Models.Producto>();
            efModels.ForEach(efModel =>
            {
                Models.Producto model;
                mapEntityFrameworkToModel(efModel, out model);
                modelsCopy.Add(model);
            });
            models = modelsCopy;
        }

        internal static void mapModelToEntityFramework(Models.Producto model, ref Productos efModel)
        {
            efModel.nombre = model.nombre;
            efModel.codigoMarca = model.marca;
        }
    }
}
