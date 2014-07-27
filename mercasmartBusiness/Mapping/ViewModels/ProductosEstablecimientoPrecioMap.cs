using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping.ViewModels
{
    class ProductosEstablecimientoPrecioMap
    {

        internal static void mapModelToEntity(RelacionProductoEstablecimientoPrecioVigencia model, out mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio entity)
        {
            entity = new mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio();

            mercasmartBusiness.Entities.Producto producto;
            mercasmartBusiness.Entities.Establecimiento establecimiento;

            Mapping.Entities.ProductosMap.mapModelToEntity(model.Producto, out producto);
            Mapping.Entities.EstablecimientosMap.mapModelToEntity(model.Establecimiento, out establecimiento);

            entity.Producto = producto;
            entity.Establecimiento = establecimiento;
            entity.Precio = model.Precio;
            entity.Desde = model.Desde;
            entity.Hasta = model.Hasta;
        }
        internal static void mapModelToEntity(List<RelacionProductoEstablecimientoPrecioVigencia> models, out List<mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio> entities)
        {
            var entitiesCopy = new List<mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio>();
            models.ForEach(model =>
            {
                var entity = new mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }

        internal static void mapEntityToModel(mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio entity, out RelacionProductoEstablecimientoPrecioVigencia model)
        {
            model = new RelacionProductoEstablecimientoPrecioVigencia();
            model.Precio = entity.Precio;
            model.Desde = entity.Hasta;

            Establecimiento establecmiento;
            Mapping.Entities.EstablecimientosMap.mapEntityToModel(entity.Establecimiento, out establecmiento);
            model.Establecimiento = establecmiento;

            Producto producto;
            Mapping.Entities.ProductosMap.mapEntityToModel(entity.Producto, out producto);
            model.Producto = producto;
        }
        internal static void mapEntityToModel(List<mercasmartBusiness.ViewModels.ProductoEstablecimientoPrecio> entities, out List<RelacionProductoEstablecimientoPrecioVigencia> models)
        {
            models = new List<RelacionProductoEstablecimientoPrecioVigencia>();

            foreach (var item in entities)
            {
                RelacionProductoEstablecimientoPrecioVigencia model;
                mapEntityToModel(item, out model);
                models.Add(model);
            }

        }

    }
}
