namespace SistemaVentas.Datos.Repository.Contratos
{
    public interface IBoardRepository
    {
        Task<int> TotalVentasUltimaSemana();
        Task<string> TotalIngresosUltimaSemana();
        Task<int> TotalProductos();
        Task<Dictionary<string, int>> VentasUltimaSemana();
    }
}
