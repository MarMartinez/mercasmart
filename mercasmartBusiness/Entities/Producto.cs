using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence;
using mercasmartPersistence.EntityFramework;

namespace mercasmartBusiness
{
    class Producto
    {
        private string nombre;
        private string marca;
        private string tipoProducto;
        private double precio;
        private string establecimiento;

        public List<Producto> getListaTodosProductos()
        {
            mercasmartEntities DB = new mercasmartEntities();
            List<Producto> listaTodosProductos = new List<Producto>();

            


            return listaTodosProductos;
        }
    }
}
