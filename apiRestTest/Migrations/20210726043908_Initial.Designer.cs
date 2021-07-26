﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiRestTest;

namespace apiRestTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210726043908_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidades.Modelos.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primer_apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primer_nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segundo_apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segundo_nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Entidades.Modelos.CompraDetalle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompraEncabezadoid")
                        .HasColumnType("int");

                    b.Property<int>("Productoid")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("CompraEncabezadoid");

                    b.HasIndex("Productoid");

                    b.ToTable("CompraDetalles");
                });

            modelBuilder.Entity("Entidades.Modelos.CompraEncabezado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Proveedorid")
                        .HasColumnType("int");

                    b.Property<int>("Sucursalid")
                        .HasColumnType("int");

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Proveedorid");

                    b.HasIndex("Sucursalid");

                    b.ToTable("CompraEncabezados");
                });

            modelBuilder.Entity("Entidades.Modelos.Empresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("razon_social")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Entidades.Modelos.Inventario", b =>
                {
                    b.Property<int>("Productoid")
                        .HasColumnType("int");

                    b.Property<int>("Sucursalid")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("Productoid", "Sucursalid");

                    b.HasIndex("Sucursalid");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("Entidades.Modelos.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entidades.Modelos.Proveedor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("razon_social")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Entidades.Modelos.Sucursal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Empresaid")
                        .HasColumnType("int");

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Empresaid");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("Entidades.Modelos.VentaDetalle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Productoid")
                        .HasColumnType("int");

                    b.Property<int?>("VentaEncabezadoid")
                        .HasColumnType("int");

                    b.Property<int>("Ventaid")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("Productoid");

                    b.HasIndex("VentaEncabezadoid");

                    b.ToTable("VentaDetalles");
                });

            modelBuilder.Entity("Entidades.Modelos.VentaEncabezado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Clienteid")
                        .HasColumnType("int");

                    b.Property<int>("Sucursalid")
                        .HasColumnType("int");

                    b.Property<short>("activo")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Clienteid");

                    b.HasIndex("Sucursalid");

                    b.ToTable("VentaEncabezados");
                });

            modelBuilder.Entity("Entidades.Modelos.CompraDetalle", b =>
                {
                    b.HasOne("Entidades.Modelos.CompraEncabezado", "CompraEncabezado")
                        .WithMany("CompraDetalles")
                        .HasForeignKey("CompraEncabezadoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Modelos.Producto", "Producto")
                        .WithMany("CompraDetalles")
                        .HasForeignKey("Productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompraEncabezado");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Entidades.Modelos.CompraEncabezado", b =>
                {
                    b.HasOne("Entidades.Modelos.Proveedor", "Proveedor")
                        .WithMany("CompraEncabezados")
                        .HasForeignKey("Proveedorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Modelos.Sucursal", "Sucursal")
                        .WithMany("CompraEncabezados")
                        .HasForeignKey("Sucursalid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Entidades.Modelos.Inventario", b =>
                {
                    b.HasOne("Entidades.Modelos.Producto", "Producto")
                        .WithMany("Inventarios")
                        .HasForeignKey("Productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Modelos.Sucursal", "Sucursal")
                        .WithMany("Inventarios")
                        .HasForeignKey("Sucursalid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Entidades.Modelos.Sucursal", b =>
                {
                    b.HasOne("Entidades.Modelos.Empresa", "Empresa")
                        .WithMany("Sucursales")
                        .HasForeignKey("Empresaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Entidades.Modelos.VentaDetalle", b =>
                {
                    b.HasOne("Entidades.Modelos.Producto", "Producto")
                        .WithMany("VentaDetalles")
                        .HasForeignKey("Productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Modelos.VentaEncabezado", "VentaEncabezado")
                        .WithMany("VentaDetalles")
                        .HasForeignKey("VentaEncabezadoid");

                    b.Navigation("Producto");

                    b.Navigation("VentaEncabezado");
                });

            modelBuilder.Entity("Entidades.Modelos.VentaEncabezado", b =>
                {
                    b.HasOne("Entidades.Modelos.Cliente", "Cliente")
                        .WithMany("VentaEncabezados")
                        .HasForeignKey("Clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Modelos.Sucursal", "Sucursal")
                        .WithMany("VentaEncabezados")
                        .HasForeignKey("Sucursalid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Entidades.Modelos.Cliente", b =>
                {
                    b.Navigation("VentaEncabezados");
                });

            modelBuilder.Entity("Entidades.Modelos.CompraEncabezado", b =>
                {
                    b.Navigation("CompraDetalles");
                });

            modelBuilder.Entity("Entidades.Modelos.Empresa", b =>
                {
                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("Entidades.Modelos.Producto", b =>
                {
                    b.Navigation("CompraDetalles");

                    b.Navigation("Inventarios");

                    b.Navigation("VentaDetalles");
                });

            modelBuilder.Entity("Entidades.Modelos.Proveedor", b =>
                {
                    b.Navigation("CompraEncabezados");
                });

            modelBuilder.Entity("Entidades.Modelos.Sucursal", b =>
                {
                    b.Navigation("CompraEncabezados");

                    b.Navigation("Inventarios");

                    b.Navigation("VentaEncabezados");
                });

            modelBuilder.Entity("Entidades.Modelos.VentaEncabezado", b =>
                {
                    b.Navigation("VentaDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
