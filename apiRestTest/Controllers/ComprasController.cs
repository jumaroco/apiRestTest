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
    public class ComprasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ComprasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(TransaccionDTO compra)
        {
            context.Database.BeginTransaction();

            try
            {
                CompraEncabezado encabezado = new CompraEncabezado();
                encabezado.Sucursalid = compra.Sucursalid;
                encabezado.Proveedorid = compra.Clienteid;
                encabezado.fecha = DateTime.Now;
                encabezado.observaciones = compra.observaciones;
                encabezado.activo = 1;
                context.CompraEncabezados.Add(encabezado);
                context.SaveChanges();

                foreach (var d in compra.Detalles)
                {
                    var stockDeProductoPorSucursal = await (from i in context.Inventarios
                                                            join p in context.Productos
                                                            on i.Productoid equals p.id
                                                            join s in context.Sucursales
                                                            on i.Sucursalid equals s.id
                                                            where (i.Sucursalid == compra.Sucursalid)
                                                            where (i.Productoid == d.Productoid)
                                                            select new DetalleInventarioDTO
                                                            {
                                                                Sucursal = s.nombre,
                                                                Producto = p.descripcion,
                                                                Existencia = i.stock
                                                            }).FirstOrDefaultAsync();

                    if(stockDeProductoPorSucursal != null)
                    {
                        if(d.cantidad > 0)
                        {
                            CompraDetalle detalle = new CompraDetalle() {
                                CompraEncabezadoid = encabezado.id,
                                Productoid=d.Productoid,
                                cantidad=d.cantidad,
                                precio=d.precio
                            };

                            context.CompraDetalles.Add(detalle);

                            Inventario inv = new Inventario();
                            inv = context.Inventarios.Where(x => x.Productoid == d.Productoid).Where(x=> x.Sucursalid==encabezado.Sucursalid).FirstOrDefault();
                            if (inv != null)
                            {
                                inv.stock = inv.stock + detalle.cantidad;
                            }
                        }
                        else
                        {
                            context.Database.RollbackTransaction();
                            return "No se pudó realizar la compra la cantidad del producto debe ser mayor a 0.";
                        }
                    }
                    else
                    {
                        context.Database.RollbackTransaction();
                        return "No se pudó realizar la compra no se encontro el producto.";
                    }
                }
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                return "Error: "+ex.Message;
            }
            
            await context.SaveChangesAsync();
             context.Database.CommitTransaction();


            return "Compra realizada con éxito.";
        }
    }
}
