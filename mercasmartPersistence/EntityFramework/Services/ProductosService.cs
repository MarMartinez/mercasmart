using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.EntityFramework;

namespace mercasmartPersistence.EntityFramework.Services
{
    class ProductosService
    {

        public List<Productos> getProductosAll()
        {
            return new mercasmartEntities().Productos.ToList();
        }

    }
}
