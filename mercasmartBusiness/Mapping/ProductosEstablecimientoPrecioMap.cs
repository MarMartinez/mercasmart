using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Mapping
{
    class ProductosEstablecimientoPrecioMap
    {

        internal static void mapModelToEntity(RelacionProductoEstablecimientoPrecioVigencia model, out ViewModels.ProductoEstablecimientoPrecio entity)
        {
            entity = new ViewModels.ProductoEstablecimientoPrecio();

            Entities.Producto producto;
            Entities.Establecimiento establecimiento;

            Mapping.ProductosMap.mapModelToEntity(model.Producto, out producto);
            Mapping.EstablecimientosMap.mapModelToEntity(model.Establecimiento, out establecimiento);

            entity.Producto = producto;
            entity.Establecimiento = establecimiento;
            entity.Precio = model.Precio;
            entity.Desde = model.Desde;
            entity.Hasta = model.Hasta;
        }
        internal static void mapModelToEntity(List<RelacionProductoEstablecimientoPrecioVigencia> models, out List<ViewModels.ProductoEstablecimientoPrecio> entities)
        {
            var entitiesCopy = new List<ViewModels.ProductoEstablecimientoPrecio>();
            models.ForEach(model =>
            {
                var entity = new ViewModels.ProductoEstablecimientoPrecio();
                mapModelToEntity(model, out entity);
                entitiesCopy.Add(entity);
            });
            entities = entitiesCopy;
        }


        internal static void mapEntityToModel(ViewModels.ProductoEstablecimientoPrecio entity, out RelacionProductoEstablecimientoPrecioVigencia model)
        {
            model = new RelacionProductoEstablecimientoPrecioVigencia();
            model.Precio = entity.Precio;
            model.Desde = entity.Hasta;

            Establecimiento establecmiento;
            Mapping.EstablecimientosMap.mapEntityToModel(entity.Establecimiento, out establecmiento);
            model.Establecimiento = establecmiento;

            Producto producto;
            Mapping.ProductosMap.mapEntityToModel(entity.Producto, out producto);
            model.Producto = producto;
        }
    }
}
