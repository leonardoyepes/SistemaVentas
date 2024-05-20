using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Repository.Contratos
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
