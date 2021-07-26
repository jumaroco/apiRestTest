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
    public class VentasController
    {
        private readonly ApplicationDbContext context;
        public VentasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(TransaccionDTO venta)
        {
            context.Database.BeginTransaction();

            try
            {
                VentaEncabezado encabezado = new VentaEncabezado();
                encabezado.Sucursalid = venta.Sucursalid;
                encabezado.Clienteid = venta.Clienteid;
                encabezado.fecha = DateTime.Now;
                encabezado.observaciones = venta.observaciones;
                encabezado.activo = 1;
                context.VentaEncabezados.Add(encabezado);
                context.SaveChanges();

                foreach (var d in venta.Detalles)
                {
                    var stockDeProductoPorSucursal = await (from i in context.Inventarios
                                                            join p in context.Productos
                                                            on i.Productoid equals p.id
                                                            join s in context.Sucursales
                                                            on i.Sucursalid equals s.id
                                                            where (i.Sucursalid == venta.Sucursalid)
                                                            where (i.Productoid == d.Productoid)
                                                            select new DetalleInventarioDTO
                                                            {
                                                                Sucursal = s.nombre,
                                                                Producto = p.descripcion,
                                                                Existencia = i.stock
                                                            }).FirstOrDefaultAsync();

                    if (stockDeProductoPorSucursal != null)
                    {
                        if ( stockDeProductoPorSucursal.Existencia >= d.cantidad )
                        {
                            VentaDetalle detalle = new VentaDetalle()
                            {
                                VentaEncabezadoid = encabezado.id,
                                Productoid = d.Productoid,
                                cantidad = d.cantidad,
                                precio = d.precio
                            };

                            context.VentaDetalles.Add(detalle);

                            Inventario inv = new Inventario();
                            inv = context.Inventarios.Where(x => x.Productoid == d.Productoid).Where(x => x.Sucursalid == encabezado.Sucursalid).FirstOrDefault();
                            if (inv != null)
                            {
                                inv.stock = inv.stock - detalle.cantidad;
                            }
                        }
                        else
                        {
                            context.Database.RollbackTransaction();
                            return "No se pudó realizar la venta el producto: ["+stockDeProductoPorSucursal.Producto+"] no tiene suficiente existencia.";
                        }
                    }
                    else
                    {
                        context.Database.RollbackTransaction();
                        return "No se pudó realizar la venta no se encontro el producto.";
                    }
                }
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                return "Error: " + ex.Message;
            }

            await context.SaveChangesAsync();
            context.Database.CommitTransaction();


            return "Venta realizada con éxito.";
        }
    }
}
