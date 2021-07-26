using apiRestTest.DTOs;
using Entidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventariosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public InventariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("detalle")]
        public async Task<ActionResult<List<DetalleInventarioDTO>>> Get()
        {
            var stockDeJuguetes = await ( from i in context.Inventarios
                join p in context.Productos
                on i.Productoid equals p.id
                join s in context.Sucursales
                on i.Sucursalid equals s.id
                select new DetalleInventarioDTO
                {
                    Sucursal = s.nombre,
                    Producto = p.descripcion,
                    Existencia = i.stock
                }).ToListAsync();

            if (stockDeJuguetes == null)
            {
                return new List<DetalleInventarioDTO>();
            }

            return stockDeJuguetes; 
        }
        [HttpGet("detalle/{SucursalId}")]
        public async Task<ActionResult<List<DetalleInventarioDTO>>> ObtenerJuguetesPorSucursal(int SucursalId)
        {
            var stockDeJuguetesPorSucursal = await (from i in context.Inventarios
                                         join p in context.Productos
                                         on i.Productoid equals p.id
                                         join s in context.Sucursales
                                         on i.Sucursalid equals s.id
                                         where (i.Sucursalid ==SucursalId)
                                         select new DetalleInventarioDTO
                                         {
                                             Sucursal = s.nombre,
                                             Producto = p.descripcion,
                                             Existencia = i.stock
                                         }).ToListAsync();

            if(stockDeJuguetesPorSucursal == null)
            {
                return new List<DetalleInventarioDTO>();
            }
            return stockDeJuguetesPorSucursal;
        }
    }
}
