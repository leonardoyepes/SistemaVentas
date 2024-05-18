using System.Linq.Expressions;

namespace SistemaVentas.Datos.Respository.Contratos
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel model);
        Task<TModel> Editar(TModel model);
        Task<TModel> Eliminar(TModel model);
        Task<TModel> Consultar(Expression<Func<TModel, bool>> filtro);
    }
}
