using SistemaVentas.DTO;

namespace SistemaVentas.Negocio.Servicios.Contratos
{
    public interface IRolService
    {
        Task<List<RolDTO>> Lista();
    }
}
