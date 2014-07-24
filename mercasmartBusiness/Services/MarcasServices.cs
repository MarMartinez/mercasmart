using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;
using mercasmartPersistence.Services;

namespace mercasmartBusiness.Services
{
    public class MarcasServices
    {

        private mercasmartPersistence.Services.MarcasServices m_persistenceService;
        public MarcasServices()
        {
            m_persistenceService = new mercasmartPersistence.Services.MarcasServices();
        }

        public List<Entities.Marca> getMarcasAll()
        {
            var marcasModels = new List<Marca>();

            marcasModels = m_persistenceService.getMarcasAll();

            List<Entities.Marca> marcasBusiness;

            Mapping.MarcasMap.mapModelToEntity(marcasModels, out marcasBusiness);

            return marcasBusiness;
        }

        public List<Entities.Marca> getMarcasNoBlancasAll()
        {
            throw new NotImplementedException();
        }
    }
}
