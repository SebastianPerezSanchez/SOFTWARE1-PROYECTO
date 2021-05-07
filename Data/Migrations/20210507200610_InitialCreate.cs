using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SOFTWARE1_PROYECTO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    apellido = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    sexo = table.Column<string>(nullable: false),
                    distrito = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: false),
                    celular = table.Column<string>(nullable: false),
                    compras = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_producto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product = table.Column<string>(nullable: false),
                    color = table.Column<string>(nullable: false),
                    tallas = table.Column<string>(nullable: false),
                    sexo = table.Column<string>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    modelo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    cargo = table.Column<string>(nullable: true),
                    contraseña = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_EntradaProducto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cantidadEntrada = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_EntradaProducto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_t_EntradaProducto_t_producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "t_producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_EntradaProducto_ProductoId",
                table: "t_EntradaProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_cliente");

            migrationBuilder.DropTable(
                name: "t_EntradaProducto");

            migrationBuilder.DropTable(
                name: "t_usuario");

            migrationBuilder.DropTable(
                name: "t_producto");
        }
    }
}
