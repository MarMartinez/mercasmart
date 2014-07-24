using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;
using mercasmartPersistence.Services;

namespace mercasmartBusiness.Services
{
    public class RelProdEst_Service
    {

        private mercasmartPersistence.Services.RelProdEst_Service m_persistenceService;
        public RelProdEst_Service()
        {
            m_persistenceService = new mercasmartPersistence.Services.RelProdEst_Service();
        }

        public List<Entities.RelProdEst> getRelacionesProdEstaAll()
        {
            var establimientosModels = new List<RelProdEst>();

            establimientosModels = m_persistenceService.getRelacionesProductoEstablecimientoAll();

            List<Entities.RelProdEst> establecimientosBusiness;

            Mapping.RelProdEst_Map.mapModelToEntity(establimientosModels, out establecimientosBusiness);

            return establecimientosBusiness;
        }      

    }
}
