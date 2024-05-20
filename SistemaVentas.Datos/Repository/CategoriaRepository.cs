using Microsoft.EntityFrameworkCore;
using SistemaVentas.Datos.Repository.Contratos;
using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DbventaContext _dbContext;

        public CategoriaRepository(DbventaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Categoria>> Lista()
        {
            try
            {
                return await _dbContext.Categoria.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
