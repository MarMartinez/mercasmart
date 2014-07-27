using System;
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
            mercasmartPersistence.Models.Marca marca;

            Mapping.MarcasMap.mapEntityFrameworkToModel(efModel.Marcas, out marca);

            model.IdProducto = efModel.idProducto;
            model.Nombre = efModel.nombre;
            model.Marca = marca;
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
            mercasmartPersistence.EntityFramework.Marcas marca = new Marcas();
            Mapping.MarcasMap.mapModelToEntityFramework(model.Marca, ref marca);

            efModel.idProducto = model.IdProducto;
            efModel.nombre = model.Nombre;
            efModel.Marcas = marca;
        }
    }
}
