using Microsoft.AspNetCore.Mvc;
using SistemaVentas.API.Utilidad;
using SistemaVentas.DTO;
using SistemaVentas.Negocio.Servicios.Contratos;

namespace SistemaVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }
        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var response = new Response<VentaDTO>();

            try
            {
                response.State = true;
                response.Vaule = await _ventaService.Registar(venta);
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
