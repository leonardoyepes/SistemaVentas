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
        public async Task<IActionResult> Registrar([FromBody] VentaDTO modelo)
        {
            Response<VentaDTO> _response = new();
            try
            {
                VentaDTO venta = await _ventaService.Registar(modelo);

                _response = venta.IdVenta != 0
                    ? new Response<VentaDTO>() { State = true, Mesagge = "ok", Vaule = venta }
                    : new Response<VentaDTO>() { State = false, Mesagge = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<VentaDTO>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaVenta)
        {
            Response<List<VentaDTO>> _response = new Response<List<VentaDTO>>();

            numeroVenta ??= string.Empty;
            fechaVenta ??= string.Empty;

            try
            {
                List<VentaDTO> vmHistorialVenta = await _ventaService.Historial(buscarPor, numeroVenta, fechaVenta);

                _response = vmHistorialVenta.Count > 0
                    ? new Response<List<VentaDTO>>() { State = true, Mesagge = "ok", Vaule = vmHistorialVenta }
                    : new Response<List<VentaDTO>>() { State = false, Mesagge = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<VentaDTO>>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            Response<List<ReporteDTO>> _response = new();

            try
            {
                List<ReporteDTO> listaReporte = await _ventaService.Reporte(fechaInicio, fechaFin));

                if (listaReporte.Count > 0)
                    _response = new Response<List<ReporteDTO>>() { State = true, Mesagge = "ok", Vaule = listaReporte };
                else
                    _response = new Response<List<ReporteDTO>>() { State = false, Mesagge = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<ReporteDTO>>() { State = false, Mesagge = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
