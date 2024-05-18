using Microsoft.EntityFrameworkCore;
using SistemaVentas.Datos.Respository.Contratos;
using System.Linq.Expressions;

namespace SistemaVentas.Datos.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbventaContext _dbventaContext;

        public GenericRepository(DbventaContext dbventaContext)
        {
            _dbventaContext = dbventaContext;
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            TModel model = await _dbventaContext.Set<TModel>().FirstOrDefaultAsync(filtro);
            return model;
        }

        public async Task<TModel> Crear(TModel model)
        {
            _dbventaContext.Set<TModel>().Add(model);
            await _dbventaContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Editar(TModel model)
        {
            _dbventaContext.Set<TModel>().Add(model);
            await _dbventaContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(TModel model)
        {
            _dbventaContext.Set<TModel>().Remove(model);
            await _dbventaContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro)
        {
            IQueryable<TModel> queryModel = filtro == null ? _dbventaContext.Set<TModel>() :
                _dbventaContext.Set<TModel>().Where(filtro);
            return queryModel;
        }
    }
}
