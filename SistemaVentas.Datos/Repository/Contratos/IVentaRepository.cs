using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Respository.Contratos
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
