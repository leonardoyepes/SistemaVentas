using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Repository.Contratos
{
    public interface IRolRepository
    {
        Task<List<Rol>> Lista();
    }
}
