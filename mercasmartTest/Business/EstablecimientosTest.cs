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

        [TestMethod]
        public void ListarEstablecimientoPorNombre()
        {
            var estabServ = new mercasmartBusiness.Services.EstablecimientosService();

            var alcampo = estabServ.getEstablecimientosByNombre("alcampo");

            Assert.IsTrue(alcampo.Count == 1);
            Assert.AreEqual(alcampo[0].Nombre, "Alcampo");
        }

        [TestMethod]
        public void ModificarNombreEstablecimiento()
        {
            var estabServ = new mercasmartBusiness.Services.EstablecimientosService();

            var alcampo = estabServ.getEstablecimientosByCodigo("alcampo");

            Assert.IsTrue(alcampo.Count == 1);

            alcampo[0].Nombre = "Alcampete";
            estabServ.modifyEstablecimientos(alcampo[0]);

            alcampo = estabServ.getEstablecimientosByCodigo("alcampo");

            Assert.AreEqual(alcampo[0].Nombre, "Alcampete");

            alcampo[0].Nombre = "Alcampo";
            estabServ.modifyEstablecimientos(alcampo[0]);

            alcampo = estabServ.getEstablecimientosByCodigo("alcampo");

            Assert.AreEqual(alcampo[0].Nombre, "Alcampo");
        }

        //[TestMethod]
        //public void ListarProductosDeUnEstablecimiento()
        //{
        //    var estabServ = new mercasmartBusiness.Services.EstablecimientosService();
        //    string establecimientoElegido = "mercadona";
        //    var super = estabServ.getEstablecimientosByNombre(establecimientoElegido);

        //    var listaProductosSuper = estabServ.getProductosPorEstablecimiento(super[0]);

        //    Assert.IsTrue(listaProductosSuper.Count > 1);
        //}

    }
}
