using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;
using mercasmartPersistence.Services;

namespace mercasmartBusiness.Services
{
    public class ProductoService
    {
        private mercasmartPersistence.Services.ProductosService m_persistenceProductoService;
        public ProductoService()
        {
            m_persistenceProductoService = new mercasmartPersistence.Services.ProductosService();

        }

        public List<Entities.Producto> getProductosAll()
        {
            var productosModels = new List<Producto>();

            productosModels = m_persistenceProductoService.getProductosAll();

            List<Entities.Producto> productosBusiness;

            Mapping.Entities.ProductosMap.mapModelToEntity(productosModels, out productosBusiness);

            return productosBusiness;
        }

        public List<Entities.Producto> getProductosPorTipo(string tipoProducto)
        {
            var productosModels = new List<Producto>();

            productosModels = m_persistenceProductoService.getProductosPorTipo(tipoProducto);

            List<Entities.Producto> productosPorTipoBusiness;

            Mapping.Entities.ProductosMap.mapModelToEntity(productosModels, out productosPorTipoBusiness);

            return productosPorTipoBusiness;
        }
    }
}
