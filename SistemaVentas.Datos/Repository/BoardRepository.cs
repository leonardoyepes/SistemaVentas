﻿using SistemaVentas.Datos.Repository.Contratos;
using SistemaVentas.Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Datos.Repository
{
    public class BoardRepository: IBoardRepository
    {
        private readonly DbventaContext _dbcontext;
        public BoardRepository(DbventaContext context)
        {
            _dbcontext = context;
        }

        public async Task<int> TotalVentasUltimaSemana()
        {
            int total = 0;
            try
            {
                IQueryable<Venta> _ventaQuery = _dbcontext.Venta.AsQueryable();

                if (_ventaQuery.Count() > 0)
                {
                    DateTime? ultimaFecha = _dbcontext.Venta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();

                    ultimaFecha = ultimaFecha.Value.AddDays(-7);

                    IQueryable<Venta> query = _dbcontext.Venta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
                    total = query.Count();
                }

                return total;
            }
            catch
            {
                throw;
            }
        }
        public async Task<string> TotalIngresosUltimaSemana()
        {
            decimal resultado = 0;
            try
            {
                IQueryable<Venta> _ventaQuery = _dbcontext.Venta.AsQueryable();

                if (_ventaQuery.Count() > 0)
                {
                    DateTime? ultimaFecha = _dbcontext.Venta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
                    ultimaFecha = ultimaFecha.Value.AddDays(-7);
                    IQueryable<Venta> query = _dbcontext.Venta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);

                    resultado = query
                         .Select(v => v.Total)
                         .Sum(v => v.Value);
                }


                return Convert.ToString(resultado, new CultureInfo("es-PE"));
            }
            catch
            {
                throw;
            }


        }
        public async Task<int> TotalProductos()
        {
            try
            {
                IQueryable<Producto> query = _dbcontext.Productos;
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, int>> VentasUltimaSemana()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            try
            {
                IQueryable<Venta> _ventaQuery = _dbcontext.Venta.AsQueryable();
                if (_ventaQuery.Count() > 0)
                {
                    DateTime? ultimaFecha = _dbcontext.Venta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();
                    ultimaFecha = ultimaFecha.Value.AddDays(-7);

                    IQueryable<Venta> query = _dbcontext.Venta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);

                    resultado = query
                        .GroupBy(v => v.FechaRegistro.Value.Date).OrderBy(g => g.Key)
                        .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                        .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
                }


                return resultado;

            }
            catch
            {
                throw;
            }

        }
    }
}
