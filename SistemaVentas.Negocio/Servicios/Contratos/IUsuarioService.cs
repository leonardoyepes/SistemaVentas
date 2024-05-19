using SistemaVentas.DTO;

namespace SistemaVentas.Negocio.Servicios.Contratos
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Listar();
        Task<UsuarioDTO> Crear(UsuarioDTO modelo);
        Task<bool> Editar(UsuarioDTO modelo);
        Task<bool> Eliminar(int Id);
        Task<SesionDTO> ValidarCredenciales(string correo, string contraseña);
    }
}
