using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVentas.Datos;
using SistemaVentas.Datos.Repository;
using SistemaVentas.Datos.Respository.Contratos;

namespace SistemaVentas.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration)
        {
            service?.AddDbContext<DbventaContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("StringSql"));
                });
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IVentaRepository, VentaRepository>();
        }
    }
}
