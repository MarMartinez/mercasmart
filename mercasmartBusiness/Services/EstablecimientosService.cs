using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;
using mercasmartPersistence.Services;

namespace mercasmartBusiness.Services
{
    public class EstablecimientosService
    {

        public List<Entities.Establecimiento> getEstablecimientosAll()
        {
            var establimientosModels = new List<Establecimiento>();

            var persistenceService = new mercasmartPersistence.Services.EstablecimientosService();

            establimientosModels = persistenceService.getProductosAll();

            List<Entities.Establecimiento> establecimientosBusiness;

            Mapping.EstablecimientosMap.mapModelToEntity(establimientosModels, out establecimientosBusiness);

            return establecimientosBusiness;
        }

    }
}
