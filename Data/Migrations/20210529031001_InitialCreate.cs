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
                name: "t_hombre",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    talla39 = table.Column<int>(nullable: false),
                    talla40 = table.Column<int>(nullable: false),
                    talla41 = table.Column<int>(nullable: false),
                    talla42 = table.Column<int>(nullable: false),
                    talla43 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_hombre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_mujer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    talla36 = table.Column<int>(nullable: false),
                    talla37 = table.Column<int>(nullable: false),
                    talla38 = table.Column<int>(nullable: false),
                    talla39 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_mujer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_nino",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    sexo = table.Column<string>(nullable: true),
                    talla25 = table.Column<int>(nullable: false),
                    talla26 = table.Column<int>(nullable: false),
                    talla27 = table.Column<int>(nullable: false),
                    talla28 = table.Column<int>(nullable: false),
                    talla29 = table.Column<int>(nullable: false),
                    talla30 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nino", x => x.id);
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
                name: "t_hombre");

            migrationBuilder.DropTable(
                name: "t_mujer");

            migrationBuilder.DropTable(
                name: "t_nino");

            migrationBuilder.DropTable(
                name: "t_usuario");

            migrationBuilder.DropTable(
                name: "t_producto");
        }
    }
}
