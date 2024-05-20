using AutoMapper;
using SistemaVentas.Datos.Repository.Contratos;
using SistemaVentas.DTO;
using SistemaVentas.Modelo;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.Negocio.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _genericRepository;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var producto = await _genericRepository.Crear(_mapper.Map<Producto>(modelo));
                _ = producto.IdProducto == 0 ? producto : throw new TaskCanceledException("No fue posible crear el producto");

                return _mapper.Map<ProductoDTO>(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var producto = await _genericRepository.Obtener(p => p.IdProducto == modelo.IdProducto);
                _ = producto ?? throw new TaskCanceledException("No fue posible obtener un producto con los datos");

                producto.Nombre = modelo.Nombre;
                producto.Stock = modelo.Stock;
                producto.IdCategoria = modelo.IdCategoria;

                bool respuesta = await _genericRepository.Editar(producto);

                _ = respuesta == true ? respuesta : throw new TaskCanceledException("No fue posible editar el producto");
                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var producto = await _genericRepository.Obtener(m => m.IdProducto == id);
                _ = producto ?? throw new Exception("No se encontro el prodcto a eliminar");

                bool respuesta = await _genericRepository.Eliminar(producto);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<List<ProductoDTO>> Listar()
        {
            try
            {
                var listaProducto = await _genericRepository.Consultar();
                return _mapper.Map<List<ProductoDTO>>(listaProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
