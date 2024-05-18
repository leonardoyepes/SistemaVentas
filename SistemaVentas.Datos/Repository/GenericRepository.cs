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
            try
            {

                TModel model = await _dbventaContext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return model;
            }
            catch
            {
                throw new Exception("fallo la consulta de datos");
            }
        }

        public async Task<TModel> Crear(TModel model)
        {
           _dbventaContext.Set<TModel>().Add(model);
            await _dbventaContext.SaveChangesAsync();
            return model;
        }

        public Task<TModel> Editar(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Eliminar(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Consultar(Expression<Func<TModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }
    }
}
