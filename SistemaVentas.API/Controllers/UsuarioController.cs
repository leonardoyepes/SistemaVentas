using Microsoft.AspNetCore.Mvc;
using SistemaVentas.API.Utilidad;
using SistemaVentas.DTO;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<UsuarioDTO>> _response = new();

            try
            {
                List<UsuarioDTO> listaUsuarios = new();
                listaUsuarios = await _usuarioService.Listar();
                if (listaUsuarios.Count > 0)
                    _response = new Response<List<UsuarioDTO>>() { State = true, Mesagge = "ok", Vaule = listaUsuarios };
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
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO modelo)
        {
            Response<UsuarioDTO> _response = new();
            try
            {


                UsuarioDTO usuarioCreado = await _usuarioService.Crear(modelo);

                if (usuarioCreado.IdUsuario != 0)
                    _response = new Response<UsuarioDTO>() { State = true, Mesagge = "ok", Vaule = usuarioCreado };
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
        [HttpGet]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            Response<SesionDTO> _response = new();
            try
            {
                SesionDTO sesionUsuario = await _usuarioService.ValidarCredenciales(login.Email, login.Password);

                if (sesionUsuario != null)
                    _response = new Response<SesionDTO>() { State = true, Mesagge = "ok", Vaule = sesionUsuario };
                else
                    _response = new Response<SesionDTO>() { State = false, Mesagge = "no encontrado", Vaule = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<SesionDTO>() { State = false, Mesagge = ex.Message, Vaule = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
        {
            Response<bool> _response = new();
            try
            {
                bool respuesta = await _usuarioService.Editar(modelo);
                if (respuesta)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo editar el usuario", Vaule = false };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<bool>() { State = false, Mesagge = ex.Message, Vaule = false };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Response<bool> _response = new();
            try
            {
                bool respuesta = await _usuarioService.Eliminar(id);

                if (respuesta)
                    _response = new Response<bool>() { State = true, Mesagge = "ok", Vaule = true };
                else
                    _response = new Response<bool>() { State = false, Mesagge = "No se pudo eliminar el usuario", Vaule = false };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<bool>() { State = false, Mesagge = ex.Message, Vaule = false };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}

