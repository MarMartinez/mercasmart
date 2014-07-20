using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Services;
using mercasmartPersistence.Models;

namespace mercasmartBusiness.Services
{
    class ProductoService
    {
        private mercasmartPersistence.Services.ProductosService m_persistenceService;
        public ProductoService()
        {
            m_persistenceService = new mercasmartPersistence.Services.ProductosService();
        }

        public List<Entities.Producto> getProductosAll()
        {
            var productosModel = new List<Producto>();

            productosModel = m_persistenceService.getProductosAll();

            List<Entities.Establecimiento> establecimientosBusiness;

            Mapping.EstablecimientosMap.mapModelToEntity(establimientosModels, out establecimientosBusiness);

            return establecimientosBusiness;
        }
    }
}
