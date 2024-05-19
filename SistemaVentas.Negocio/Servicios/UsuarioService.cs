using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Datos.Respository.Contratos;
using SistemaVentas.DTO;
using SistemaVentas.Modelo;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.Negocio.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _genericRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var nuevoUsuario = await _genericRepository.Crear(_mapper.Map<Usuario>(modelo));
                _ = nuevoUsuario.IdUsuario == 0 ? nuevoUsuario : throw new TaskCanceledException("No fue posible crear el usuario");

                var queryUsuario = await _genericRepository.Consultar(usu => usu.IdUsuario == nuevoUsuario.IdUsuario);
                nuevoUsuario = queryUsuario.Include(usu => usu.IdRolNavigation).First();

                return _mapper.Map<UsuarioDTO>(nuevoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var Usuario = await _genericRepository.Obtener(m => m.IdUsuario == modelo.IdUsuario);
                _ = Usuario ?? throw new Exception("No se encontro el usuario a editar");

                Usuario.NombreCompleto = modelo.NombreCompleto;
                Usuario.Correo = modelo.Correo;
                Usuario.Clave = modelo.Clave;
                Usuario.IdRol = modelo.IdRol;

                bool respuesta = await _genericRepository.Editar(Usuario);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<bool> Eliminar(int Id)
        {
            try
            {
                var Usuario = await _genericRepository.Obtener(m => m.IdUsuario == Id);
                _ = Usuario ?? throw new Exception("No se encontro el usuario a eliminar");

                bool respuesta = await _genericRepository.Eliminar(Usuario);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<List<UsuarioDTO>> Listar()
        {
            try
            {
                var listaUsuario = await _genericRepository.Consultar();
                return _mapper.Map<List<UsuarioDTO>>(listaUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, string contraseña)
        {
            try
            {
                var usuarioValido = await _genericRepository.Consultar(
                usu => usu.Correo == correo
                && usu.Clave == contraseña
                );

                _ = usuarioValido.FirstOrDefault() ?? throw new TaskCanceledException("No se econtro un usuario con estas credenciales");

                return _mapper.Map<SesionDTO>(usuarioValido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado", ex);
            }
        }
    }
}
