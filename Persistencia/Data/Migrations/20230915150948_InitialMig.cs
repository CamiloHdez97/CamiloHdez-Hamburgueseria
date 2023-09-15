using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especialidad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chefs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ingredientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    stock = table.Column<int>(type: "int", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hamburguesas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria_id = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    chef_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hamburguesas", x => x.id);
                    table.ForeignKey(
                        name: "FK_hamburguesas_categorias_Categoria_id",
                        column: x => x.Categoria_id,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hamburguesas_chefs_chef_id",
                        column: x => x.chef_id,
                        principalTable: "chefs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hamburguesa_ingrediente",
                columns: table => new
                {
                    hamburguesa_id = table.Column<int>(type: "int", nullable: false),
                    ingrediente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hamburguesa_ingrediente", x => new { x.hamburguesa_id, x.ingrediente_id });
                    table.ForeignKey(
                        name: "FK_hamburguesa_ingrediente_hamburguesas_hamburguesa_id",
                        column: x => x.hamburguesa_id,
                        principalTable: "hamburguesas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hamburguesa_ingrediente_ingredientes_ingrediente_id",
                        column: x => x.ingrediente_id,
                        principalTable: "ingredientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_hamburguesa_ingrediente_ingrediente_id",
                table: "hamburguesa_ingrediente",
                column: "ingrediente_id");

            migrationBuilder.CreateIndex(
                name: "IX_hamburguesas_Categoria_id",
                table: "hamburguesas",
                column: "Categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_hamburguesas_chef_id",
                table: "hamburguesas",
                column: "chef_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hamburguesa_ingrediente");

            migrationBuilder.DropTable(
                name: "hamburguesas");

            migrationBuilder.DropTable(
                name: "ingredientes");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "chefs");
        }
    }
}
