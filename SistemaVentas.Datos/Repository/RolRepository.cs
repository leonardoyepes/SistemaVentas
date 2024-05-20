using Microsoft.EntityFrameworkCore;
using SistemaVentas.Datos.Repository.Contratos;
using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly DbventaContext _dbventaContext;

        public RolRepository(DbventaContext dbventaContext) : base(dbventaContext)
        {
            _dbventaContext = dbventaContext;
        }

        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _dbventaContext.Rols.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
