using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.Services
{
    public class MarcasServices
    {

        public List<Models.Marca> getMarcasAll()
        {
            using (var db = new EntityFramework.Factories.Conexion().mercasmartEntities())
            {
                var marcas = getMarcasAll(db).ToList();
                List<Models.Marca> modelMarca;                
                EntityFramework.Mapping.MarcasMap.mapEntityFrameworkToModel(marcas, out modelMarca);
                return modelMarca;
            }
        }
        
        private IQueryable<Marcas> getMarcasAll(mercasmartEntities db)
        {
            var marcas = db.Marcas;
            return marcas;
        }

    }
}  
