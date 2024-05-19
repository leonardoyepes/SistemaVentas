using AutoMapper;
using SistemaVentas.Datos.Respository.Contratos;
using SistemaVentas.DTO;
using SistemaVentas.Modelo;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.Negocio.Servicios
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> genericRepository;
        private readonly IMapper mapper;

        public RolService(IGenericRepository<Rol> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<List<RolDTO>> Lista()
        {
            try
            {
                var listaRoles = await genericRepository.Consultar();
                return mapper.Map<List<RolDTO>>(listaRoles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
