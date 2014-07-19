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


        public List<Models.Establecimiento> getProductosByNombre(string nombre)
        {
            var a = new mercasmartEntities().Establecimientos.Where(est => est.nombreEstablecimiento.Equals(nombre)).ToList();
            List<Models.Establecimiento> modelEstablecimiento;
            EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(a, out modelEstablecimiento);
            return modelEstablecimiento;
        }


        public List<Models.Establecimiento> getProductosByCodigo(string codigo)
        {
            var a = new mercasmartEntities().Establecimientos.Where(est => est.codigoEstablecimiento.Equals(codigo)).ToList();
            List<Models.Establecimiento> modelEstablecimiento;
            EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(a, out modelEstablecimiento);
            return modelEstablecimiento;
        }

        public void modifyEstablecimiento(Models.Establecimiento establimientoModel)
        {
            using (mercasmartEntities db = new mercasmartEntities())
            {
                var establecimientoAModificar = getProductosByCodigoII(db, establimientoModel.Codigo).FirstOrDefault();
                EntityFramework.Mapping.EstablecimientosMap.mapModelToEntityFramework(establimientoModel, ref establecimientoAModificar);
                db.SaveChanges();
            }
        }

        private IQueryable<Establecimientos> getProductosByCodigoII(mercasmartEntities db, string codigo)
        {
            var establecimientos = db.Establecimientos.Where(est => est.codigoEstablecimiento == codigo);
            return establecimientos;
        }       

    }
}  
