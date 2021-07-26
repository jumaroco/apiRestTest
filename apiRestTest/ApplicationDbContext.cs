using Entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestTest
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventario>().HasKey(x => new { x.Productoid, x.Sucursalid });
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CompraDetalle> CompraDetalles { get; set; }
        public DbSet<CompraEncabezado> CompraEncabezados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        public DbSet<VentaEncabezado> VentaEncabezados { get; set; }

    }
}
