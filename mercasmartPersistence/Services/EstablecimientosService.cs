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
            using (var db = new mercasmartEntities())
            {
                var establecimientos = getProductosAll(db).ToList();
                List<Models.Establecimiento> modelEstablecimiento;
                EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
                return modelEstablecimiento;
            }
        }

        public List<Models.Establecimiento> getProductosByNombre(string nombre)
        {
            using (var db = new mercasmartEntities())
            {
                var establecimientos = getProductosByNombre(db, nombre).ToList();
                List<Models.Establecimiento> modelEstablecimiento;
                EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
                return modelEstablecimiento;
            }
        }

        public List<Models.Establecimiento> getProductosByCodigo(string codigo)
        {
            using (var db = new mercasmartEntities())
            {
                var establecimientos = getProductosByCodigo(db, codigo).ToList();
                List<Models.Establecimiento> modelEstablecimiento;
                EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
                return modelEstablecimiento;
            }
        }

        public void modifyEstablecimiento(Models.Establecimiento establimientoModel)
        {
            using (mercasmartEntities db = new mercasmartEntities())
            {
                var establecimientoAModificar = getProductosByCodigo(db, establimientoModel.Codigo).FirstOrDefault();
                EntityFramework.Mapping.EstablecimientosMap.mapModelToEntityFramework(establimientoModel, ref establecimientoAModificar);
                db.SaveChanges();
            }
        }

        private IQueryable<Establecimientos> getProductosByCodigo(mercasmartEntities db, string codigo)
        {
            var establecimientos = db.Establecimientos.Where(est => est.codigoEstablecimiento == codigo);
            return establecimientos;
        }

        private IQueryable<Establecimientos> getProductosByNombre(mercasmartEntities db, string nombre)
        {
            var establecimientos = db.Establecimientos.Where(est => est.nombreEstablecimiento == nombre);
            return establecimientos;
        }

        private IQueryable<Establecimientos> getProductosAll(mercasmartEntities db)
        {
            var establecimientos = db.Establecimientos;
            return establecimientos;
        }

    }
}  
