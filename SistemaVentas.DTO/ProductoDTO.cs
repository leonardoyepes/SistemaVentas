﻿namespace SistemaVentas.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string? DescriptionCategoria { get; set; }
        public int Stock { get; set; }
        public string? Precio { get; set; }
        public int EsActivo { get; set; }
    }
}
