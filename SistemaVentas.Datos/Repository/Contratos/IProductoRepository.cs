using SistemaVentas.Modelo;
using System.Linq.Expressions;

namespace SistemaVentas.Datos.Repository.Contratos
{
    public  interface IProductoRepository
    {
        Task<Producto> Obtener(Expression<Func<Producto, bool>> filtro = null);
        Task<Producto> Crear(Producto entidad);
        Task<bool> Editar(Producto entidad);
        Task<bool> Eliminar(Producto entidad);
        Task<IQueryable<Producto>> Consultar(Expression<Func<Producto, bool>> filtro = null);
    }
}
