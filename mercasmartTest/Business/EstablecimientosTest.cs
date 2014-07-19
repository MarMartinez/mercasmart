using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mercasmartTest.Business
{
    [TestClass]
    public class EstablecimientosTest
    {
        [TestMethod]
        public void ListarTodosEstablecimientos()
        {
            var estabServ = new mercasmartBusiness.Services.EstablecimientosService();

            var list = estabServ.getEstablecimientosAll();

            Assert.IsTrue(list.Count > 0);
        }
    }
}
