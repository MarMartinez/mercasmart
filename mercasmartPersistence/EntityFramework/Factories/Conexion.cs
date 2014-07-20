using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace mercasmartPersistence.EntityFramework.Factories
{
    public class Conexion
    {
        public mercasmartEntities mercasmartEntities()
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");
            var bd = new mercasmartEntities(connectionString);
            return bd;
        }

    }
}
