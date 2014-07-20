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

        [TestMethod]
        public void ListadoProductoFiltradosPorMarca()
        {
            var productosService = new mercasmartBusiness.Services.ProductoService();

            var listaProductos = productosService.getProductosByNombreMarca("Hacendado");

            Assert.IsTrue(listaProductos.Count > 0);
        }

        [TestMethod]
        public void ListadoProductoFiltradosPorTipoMarcaBlanca()
        {
            var productosService = new mercasmartBusiness.Services.ProductoService();

            var listaProductos = productosService.getProductosByTipoMarcaBlanca();

            Assert.IsTrue(listaProductos.Count > 0);
            Assert.IsTrue(listaProductos[0].Marca.MarcaBlanca);
        }

        [TestMethod]
        public void ListadoProductoFiltradosPorEstablecimiento()
        {
            var productosService = new mercasmartBusiness.Services.ProductoService();

            var listaProductos = productosService.getProductosByNombreEstablecimiento("Mercadona");

            Assert.IsTrue(listaProductos.Count > 0);
            
            listaProductos.ForEach(producto =>
            {
                Assert.IsTrue(producto.Establecimiento.Nombre == "Mercadona");
            });

        }

    }
}
