using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Repository.Contratos
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> Lista();
    }
}
