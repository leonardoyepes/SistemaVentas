using SistemaVentas.DTO;

namespace SistemaVentas.Negocio.Servicios.Contratos
{
    public interface IProductoService
    {
        Task<ProductoDTO> Crear(ProductoDTO modelo);
        Task<bool> Editar(ProductoDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<ProductoDTO>> Listar();
    }
}
