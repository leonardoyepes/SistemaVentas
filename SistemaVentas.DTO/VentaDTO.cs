﻿namespace SistemaVentas.DTO
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoPago { get; set; }
        public string? Total { get; set; }
        public string? FechaRegistro { get; set; }
        public virtual ICollection<DetalleVentaDTO>? DetalleVentaDto { get; set; }
    }
}
