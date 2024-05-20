using SistemaVentas.DTO;

namespace SistemaVentas.Negocio.Servicios.Contratos
{
    public interface IVentaService
    {
        Task<VentaDTO> Registar(VentaDTO modelo);
        Task<List<VentaDTO>> Historial(string buscar, string fechaVenta, string numeroVenta);
        Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin);
    }
}
