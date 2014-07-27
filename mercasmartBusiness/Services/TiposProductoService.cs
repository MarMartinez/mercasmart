using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;
using mercasmartPersistence.Services;

namespace mercasmartBusiness.Services
{
    public class TiposProductoService
    {
        private mercasmartPersistence.Services.TiposProductoService m_persistenceTiposProductoService;
        public TiposProductoService()
        {
            m_persistenceTiposProductoService = new mercasmartPersistence.Services.TiposProductoService();
        }

        public List<Entities.TiposProducto> getTiposProductoAll()
        {
            var tiposProductoModels = new List<TiposProducto>();

            tiposProductoModels = m_persistenceTiposProductoService.getTiposProductosAll();

            List<Entities.TiposProducto> tiposProductoBusiness;

            Mapping.Entities.TiposProductoMap.mapModelToEntity(tiposProductoModels, out tiposProductoBusiness);

            return tiposProductoBusiness;
        }       

    }
}
