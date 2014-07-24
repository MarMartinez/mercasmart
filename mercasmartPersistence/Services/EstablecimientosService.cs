using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class EstablecimientosService
    {

        public List<Models.Establecimiento> getEstablecimientosAll()
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var establecimientos = getEstablecimientosAll(db).ToList();
                List<Models.Establecimiento> modelEstablecimiento;
                EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
                return modelEstablecimiento;
            }
        }

        public List<Models.Establecimiento> getEstablecimientosByNombre(string nombre)
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var establecimientos = getEstablecimientosByNombre(db, nombre).ToList();
                List<Models.Establecimiento> modelEstablecimiento;
                EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
                return modelEstablecimiento;
            }
        }

        public List<Models.Establecimiento> getEstablecimientosByCodigo(string codigo)
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var establecimientos = getEstablecimientosByCodigo(db, codigo).ToList();
                List<Models.Establecimiento> modelEstablecimiento;
                EntityFramework.Mapping.EstablecimientosMap.mapEntityFrameworkToModel(establecimientos, out modelEstablecimiento);
                return modelEstablecimiento;
            }
        }

        public void modifyEstablecimiento(Models.Establecimiento establimientoModel)
        {
            using (mercasmartEntities db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var establecimientoAModificar = getEstablecimientosByCodigo(db, establimientoModel.Codigo).FirstOrDefault();
                EntityFramework.Mapping.EstablecimientosMap.mapModelToEntityFramework(establimientoModel, ref establecimientoAModificar);
                db.SaveChanges();
            }
        }

        public List<Models.RelacionProductoEstablecimiento> getProductosByCodigoEstablecimiento(string codigo)
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var lstProductoEstablecimiento = db.RelacionProductoEstablecimiento.Where(rel => rel.codigoEstablecimiento.Equals(codigo)).ToList();

                List<Models.RelacionProductoEstablecimiento> lstModelProductoEstablecimiento;
                EntityFramework.Mapping.RelacionProdcutoEstablecimientoMap.mapEntityFrameworkToModel(lstProductoEstablecimiento, out lstModelProductoEstablecimiento);
                return lstModelProductoEstablecimiento;
            }
        }

        private IQueryable<Establecimientos> getEstablecimientosByCodigo(mercasmartEntities db, string codigo)
        {
            var establecimientos = db.Establecimientos.Where(est => est.codigoEstablecimiento == codigo);
            return establecimientos;
        }

        private IQueryable<Establecimientos> getEstablecimientosByNombre(mercasmartEntities db, string nombre)
        {
            var establecimientos = db.Establecimientos.Where(est => est.nombreEstablecimiento == nombre);
            return establecimientos;
        }

        private IQueryable<Establecimientos> getEstablecimientosAll(mercasmartEntities db)
        {
            var establecimientos = db.Establecimientos;
            return establecimientos;
        }

    }
}  
