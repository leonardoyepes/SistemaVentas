using SistemaVentas.Modelo;
using System.Linq.Expressions;

namespace SistemaVentas.Datos.Repository.Contratos
{
    public  interface IUsuarioRepository
    {
        Task<List<Usuario>> Lista();
        Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
        Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null);
    }
}
