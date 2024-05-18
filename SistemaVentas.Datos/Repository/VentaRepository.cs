using SistemaVentas.Datos.Respository.Contratos;
using SistemaVentas.Modelo;

namespace SistemaVentas.Datos.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly DbventaContext _dbventaContext;
        public VentaRepository(DbventaContext dbventaContext) : base(dbventaContext)
        {
            _dbventaContext = dbventaContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaRealizada = new();

            using var transaction = _dbventaContext.Database.BeginTransaction();
            try
            {
                foreach (DetalleVenta detalleVenta in modelo.DetalleVenta)
                {
                    Producto producto = _dbventaContext.Productos.
                        Where(p => p.IdProducto == detalleVenta.IdProducto).First();

                    if (producto != null)
                    {
                        producto.Stock = DescontarProducto(producto.Stock, detalleVenta.Cantidad);
                        _dbventaContext.Productos.Update(producto);
                    }
                }

                await _dbventaContext.SaveChangesAsync();

                NumeroDocumento numeroDocumento = _dbventaContext.NumeroDocumentos.First();
                numeroDocumento.FechaRegistro = DateTime.Now;
                numeroDocumento.UltimoNumero += 1;

                _dbventaContext.NumeroDocumentos.Update(numeroDocumento);
                await _dbventaContext.SaveChangesAsync();

                modelo.NumeroDocumento = new Random(numeroDocumento.UltimoNumero).ToString();

                await _dbventaContext.Venta.AddAsync(modelo);
                await _dbventaContext.SaveChangesAsync();

                ventaRealizada = modelo;
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw new Exception();
            }

            return ventaRealizada;
        }

        private int DescontarProducto(int stock, int cantidadVenta)
        {
            stock -= cantidadVenta;
            return stock >= 0 ? stock : throw new Exception("La cantidad vendida supera el stock");
        }
    }
}
