using SistemaVentas.DTO;

namespace SistemaVentas.Negocio.Servicios.Contratos
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> Lista();
    }
}
