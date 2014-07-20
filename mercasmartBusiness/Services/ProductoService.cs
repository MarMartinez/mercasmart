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
        private mercasmartPersistence.Services.ProductosService m_persistenceService;
        public ProductoService()
        {
            m_persistenceService = new mercasmartPersistence.Services.ProductosService();

        }

        public List<Entities.Producto> getProductosAll()
        {
            var productosModels = new List<Producto>();

            productosModels = m_persistenceService.getProductosAll();

            List<Entities.Producto> productosBusiness;

            Mapping.ProductosMapping.mapModelToEntity(productosModels, out productosBusiness);

            return productosBusiness;
        }
    }
}
