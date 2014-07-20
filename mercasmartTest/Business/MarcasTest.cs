using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mercasmartTest.Business
{
    [TestClass]
    public class MarcasTest
    {
        [TestMethod]
        public void ListarTodasLasMarcas()
        {
            var marcasService = new mercasmartBusiness.Services.MarcasServices();

            var listaMarcas = marcasService.getMarcasAll();

            Assert.IsTrue(listaMarcas.Count > 0);
        }
    }
}
