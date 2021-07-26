using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiRestTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primer_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    segundo_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primer_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    segundo_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razon_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razon_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresaid = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sucursales_Empresas_Empresaid",
                        column: x => x.Empresaid,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraEncabezados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sucursalid = table.Column<int>(type: "int", nullable: false),
                    Proveedorid = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraEncabezados", x => x.id);
                    table.ForeignKey(
                        name: "FK_CompraEncabezados_Proveedores_Proveedorid",
                        column: x => x.Proveedorid,
                        principalTable: "Proveedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraEncabezados_Sucursales_Sucursalid",
                        column: x => x.Sucursalid,
                        principalTable: "Sucursales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Sucursalid = table.Column<int>(type: "int", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => new { x.Productoid, x.Sucursalid });
                    table.ForeignKey(
                        name: "FK_Inventarios_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventarios_Sucursales_Sucursalid",
                        column: x => x.Sucursalid,
                        principalTable: "Sucursales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaEncabezados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sucursalid = table.Column<int>(type: "int", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaEncabezados", x => x.id);
                    table.ForeignKey(
                        name: "FK_VentaEncabezados_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaEncabezados_Sucursales_Sucursalid",
                        column: x => x.Sucursalid,
                        principalTable: "Sucursales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraDetalles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraEncabezadoid = table.Column<int>(type: "int", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraDetalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_CompraDetalles_CompraEncabezados_CompraEncabezadoid",
                        column: x => x.CompraEncabezadoid,
                        principalTable: "CompraEncabezados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraDetalles_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaDetalles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productoid = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentaEncabezadoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDetalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_VentaDetalles_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaDetalles_VentaEncabezados_VentaEncabezadoid",
                        column: x => x.VentaEncabezadoid,
                        principalTable: "VentaEncabezados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraDetalles_CompraEncabezadoid",
                table: "CompraDetalles",
                column: "CompraEncabezadoid");

            migrationBuilder.CreateIndex(
                name: "IX_CompraDetalles_Productoid",
                table: "CompraDetalles",
                column: "Productoid");

            migrationBuilder.CreateIndex(
                name: "IX_CompraEncabezados_Proveedorid",
                table: "CompraEncabezados",
                column: "Proveedorid");

            migrationBuilder.CreateIndex(
                name: "IX_CompraEncabezados_Sucursalid",
                table: "CompraEncabezados",
                column: "Sucursalid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_Sucursalid",
                table: "Inventarios",
                column: "Sucursalid");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_Empresaid",
                table: "Sucursales",
                column: "Empresaid");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalles_Productoid",
                table: "VentaDetalles",
                column: "Productoid");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalles_VentaEncabezadoid",
                table: "VentaDetalles",
                column: "VentaEncabezadoid");

            migrationBuilder.CreateIndex(
                name: "IX_VentaEncabezados_Clienteid",
                table: "VentaEncabezados",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_VentaEncabezados_Sucursalid",
                table: "VentaEncabezados",
                column: "Sucursalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraDetalles");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "VentaDetalles");

            migrationBuilder.DropTable(
                name: "CompraEncabezados");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "VentaEncabezados");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
