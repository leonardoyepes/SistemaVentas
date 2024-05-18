namespace SistemaVentas.DTO
{
    public class SesionDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }        
        public int? RolDescription { get; set; }
    }
}
