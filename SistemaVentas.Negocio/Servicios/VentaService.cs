using AutoMapper;
using SistemaVentas.Datos.Repository.Contratos;
using SistemaVentas.DTO;
using SistemaVentas.Modelo;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.Negocio.Servicios
{
    public class VentaService : IVentaService
    {
        private readonly IGenericRepository<DetalleVenta> _repository;
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public VentaService(IGenericRepository<DetalleVenta> repository, IVentaRepository ventaRepository, IMapper mapper)
        {
            _repository = repository;
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        public Task<List<VentaDTO>> Historial(string buscar, string fechaVenta, string numeroVenta)
        {
            throw new NotImplementedException();
        }

        public async Task<VentaDTO> Registar(VentaDTO modelo)
        {
            try
            {
                var registroVenta = await _ventaRepository.Registrar(_mapper.Map<Venta>(modelo));
                _ = registroVenta.IdVenta != 0 ? registroVenta : throw new TaskCanceledException("No fue posible registrar la venta");

                return _mapper.Map<VentaDTO>(registroVenta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}
