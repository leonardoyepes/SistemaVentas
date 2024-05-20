using Microsoft.AspNetCore.Mvc;
using SistemaVentas.API.Utilidad;
using SistemaVentas.DTO;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<RolDTO>>();

            try
            {
                response.State = true;
                response.Vaule = await _rolService.Lista();
            }
            catch (Exception ex)
            {
                response.State = false;
                response.Mesagge = ex.Message;
            }

            return Ok(response);
        }
    }
}
