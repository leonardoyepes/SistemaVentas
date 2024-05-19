using AutoMapper;
using SistemaVentas.DTO;
using SistemaVentas.Modelo;
using System.Globalization;


namespace SistemaVentas.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.RolDescription,
                    map => map.MapFrom(ori => ori.IdRolNavigation.Nombre))
                .ForMember(dest => dest.EsActivo,
                    map => map.MapFrom(orig => orig.EsActivo == true ? 1 : 0));

            CreateMap<Usuario, SesionDTO>()
                .ForMember(dest => dest.RolDescription,
                    map => map.MapFrom(ori => ori.IdRolNavigation.Nombre));

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(dest => dest.IdRolNavigation,
                    map => map.Ignore())
                .ForMember(dest => dest.EsActivo,
                    map => map.MapFrom(orig => orig.EsActivo == 1 ? true : false));
            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria

            #region Producto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino =>
                    destino.DescriptionCategoria,
                    opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                );

            CreateMap<ProductoDTO, Producto>()
            .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
            )
            .ForMember(destiono =>
                destiono.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
            );
            #endregion Producto

            #region Venta
            CreateMap<Venta, VentaDTO>()
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                ).ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<VentaDTO, Venta>()
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Total, new CultureInfo("es-PE")))
                );

            #endregion Venta

            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                    destino.DescriptionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );

            CreateMap<DetalleVentaDTO, DetalleVenta>()
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Total, new CultureInfo("es-PE")))
                );
            #endregion

            #region Reporte
            CreateMap<DetalleVenta, ReporteDTO>()
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                    destino.NumeroDocumento,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento)
                )
                .ForMember(destino =>
                    destino.TipoPago,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.TipoPago)
                )
                .ForMember(destino =>
                    destino.TotalVenta,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );
            #endregion Reporte
        }
    }
}
