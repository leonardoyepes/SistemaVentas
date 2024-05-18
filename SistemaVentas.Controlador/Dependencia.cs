using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVentas.Datos;

namespace SistemaVentas.Controlador
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration)
        {
            service?.AddDbContext<DbventaContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("StringSql"));
                });
        }
    }
}
