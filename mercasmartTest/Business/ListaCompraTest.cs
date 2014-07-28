using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mercasmartBusiness.Entities;

namespace mercasmartTest.Business
{
    [TestClass]
    public class ListaCompraTest
    {

        [TestMethod]
        public void CalcularListaCompraEconomica()
        {
            // Nueva entidad lista de la compra
            var listaCompra = new mercasmartBusiness.Entities.ListaCompra();

            // Insertamos diferentes productos en la lista
            listaCompra.ProductosListaCompra.Add(new mercasmartBusiness.ViewModels.ProductoListaCompra(new TiposProducto("aceite"), 1));
            listaCompra.ProductosListaCompra.Add(new mercasmartBusiness.ViewModels.ProductoListaCompra(new TiposProducto("arroz"), 1));
            listaCompra.ProductosListaCompra.Add(new mercasmartBusiness.ViewModels.ProductoListaCompra(new TiposProducto("cafe"), 1));
            listaCompra.ProductosListaCompra.Add(new mercasmartBusiness.ViewModels.ProductoListaCompra(new TiposProducto("champu"), 1));
            listaCompra.ProductosListaCompra.Add(new mercasmartBusiness.ViewModels.ProductoListaCompra(new TiposProducto("leche"), 1));
            listaCompra.ProductosListaCompra.Add(new mercasmartBusiness.ViewModels.ProductoListaCompra(new TiposProducto("pasta"), 1));

            var resultado = listaCompra.getCalculoPreciosEstablecimientoListaCompra();

            Assert.IsTrue(resultado.Count > 0);

        }

    }
}
