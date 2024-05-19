using SistemaVentas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Negocio.Servicios.Contratos
{
    public interface IRolService
    {
        Task<List<RolDTO>> Lista();
    }
}
