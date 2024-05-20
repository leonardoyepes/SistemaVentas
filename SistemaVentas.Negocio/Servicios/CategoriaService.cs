using AutoMapper;
using SistemaVentas.Datos.Respository.Contratos;
using SistemaVentas.DTO;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.Negocio.Servicios
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<CategoriaDTO> _repository;
        private readonly IMapper _mapper;

        public CategoriaService(IGenericRepository<CategoriaDTO> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDTO>> Lista()
        {
            try
            {
                var listaCategorias = await _repository.Consultar();
                return _mapper.Map<List<CategoriaDTO>>(listaCategorias);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
