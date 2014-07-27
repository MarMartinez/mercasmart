using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mercasmartPersistence.Models;
using mercasmartPersistence.Services;

namespace mercasmartBusiness.Services
{
    public class EstablecimientosService
    {

        private mercasmartPersistence.Services.EstablecimientosService m_persistenceService;
        public EstablecimientosService()
        {
            m_persistenceService = new mercasmartPersistence.Services.EstablecimientosService();
        }

        public List<Entities.Establecimiento> getEstablecimientosAll()
        {
            var establimientosModels = new List<Establecimiento>();

            establimientosModels = m_persistenceService.getEstablecimientosAll();

            List<Entities.Establecimiento> establecimientosBusiness;

            Mapping.Entities.EstablecimientosMap.mapModelToEntity(establimientosModels, out establecimientosBusiness);

            return establecimientosBusiness;
        }

        public List<Entities.Establecimiento> getEstablecimientosByNombre(string nombre)
        {
            var establimientosModels = new List<Establecimiento>();

            establimientosModels = m_persistenceService.getEstablecimientosByNombre(nombre);

            List<Entities.Establecimiento> establecimientosBusiness;

            Mapping.Entities.EstablecimientosMap.mapModelToEntity(establimientosModels, out establecimientosBusiness);

            return establecimientosBusiness;
        }

        public List<Entities.Establecimiento> getEstablecimientosByCodigo(string codigo)
        {
            var establimientosModels = new List<Establecimiento>();

            establimientosModels = m_persistenceService.getEstablecimientosByCodigo(codigo);

            List<Entities.Establecimiento> establecimientosBusiness;

            Mapping.Entities.EstablecimientosMap.mapModelToEntity(establimientosModels, out establecimientosBusiness);

            return establecimientosBusiness;
        }

        public void modifyEstablecimientos(Entities.Establecimiento establecimiento)
        {
            Establecimiento establimientoModel;

            Mapping.Entities.EstablecimientosMap.mapEntityToModel(establecimiento, out establimientoModel);

            m_persistenceService.modifyEstablecimiento(establimientoModel);
        }

        public List<ViewModels.ProductoEstablecimientoPrecio> getProductosPorCodigoEstablecimiento(string codigoEstablecimiento)
        {
            var entities = new List<ViewModels.ProductoEstablecimientoPrecio>();
            var models = new List<RelacionProductoEstablecimientoPrecioVigencia>();

            models = m_persistenceService.getProductosByCodigoEstablecimiento(codigoEstablecimiento);

            Mapping.ViewModels.ProductosEstablecimientoPrecioMap.mapModelToEntity(models, out entities);

            return entities;
        }

    }
}
