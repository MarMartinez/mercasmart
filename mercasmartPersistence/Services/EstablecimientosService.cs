using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class EstablecimientosService
    {

        public List<Models.Establecimiento> getProductosAll()
        {
            var a = new mercasmartEntities().Establecimientos.ToList();
            List<Models.Establecimiento> modelEstablecimiento;
            EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(a, out modelEstablecimiento);
            return modelEstablecimiento;
        }

    }
}
