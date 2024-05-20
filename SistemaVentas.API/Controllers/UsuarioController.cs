using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.API.Utilidad;
using SistemaVentas.Datos.Repository.Contratos;
using SistemaVentas.DTO;
using SistemaVentas.Modelo;

namespace SistemaVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepositorio;
        public UsuarioController(IUsuarioRepository usuarioRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<UsuarioDTO>> _response = new();

            try
            {
                List<UsuarioDTO> ListaUsuarios = new();
                IQueryable<Usuario> query = await _usuarioRepositorio.Consultar();
                query = query.Include(r => r.IdRolNavigation);

                ListaUsuarios = _mapper.Map<List<UsuarioDTO>>(query.ToList());

                if (ListaUsuarios.Count > 0)
                    _response = new Response<List<UsuarioDTO>>() { State = true, Mesagge = "ok", Vaule = ListaUsuarios };
                else
                    _response = new Response<List<UsuarioDTO>>() { State = false, Mesagge = string.Empty, Vaule = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<UsuarioDTO>>() { State = false, Mesagge = ex.Message, Vaule = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO request)
        {
            Response<UsuarioDTO> _response = new();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);

                Usuario _usuarioCreado = await _usuarioRepositorio.Crear(_usuario);

                if (_usuarioCreado.IdUsuario != 0)
                    _response = new Response<UsuarioDTO>() { State = true, Mesagge = "ok", Vaule = _mapper.Map<UsuarioDTO>(_usuarioCreado) };
                else
                    _response = new Response<UsuarioDTO>() { State = false, Mesagge = "No se pudo crear el usuario" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<UsuarioDTO>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
