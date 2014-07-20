using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mercasmartTest.Business
{
    [TestClass]
    public class ProductosTest
    {
        [TestMethod]
        public void ListadoProductos()
        {
            var productosService =new mercasmartBusiness.Services.ProductoService();

            var listaProductos = productosService.getProductosAll();

            Assert.IsTrue(listaProductos.Count > 0);
        }
    }
}
