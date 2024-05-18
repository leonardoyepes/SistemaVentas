namespace SistemaVentas.DTO
{
    public class BoardDTO
    {
        public int TotalVentas { get; set; }
        public string? TotalIngreso { get; set; }
        public List<VentasSemanaDTO>? VentasUltimaSemana { get; set; }
    }
}
