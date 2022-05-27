using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ProjetoCiele.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERMISSAO_USUARIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Usuarioid = table.Column<int>(type: "int", nullable: false),
                    Permissaoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSAO_USUARIO", x => x.id);
                    table.ForeignKey(
                        name: "FK_PERMISSAO_USUARIO_PERMISAO_Permissaoid",
                        column: x => x.Permissaoid,
                        principalTable: "PERMISAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERMISSAO_USUARIO_USUARIOS_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_USUARIO_Permissaoid",
                table: "PERMISSAO_USUARIO",
                column: "Permissaoid");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_USUARIO_Usuarioid",
                table: "PERMISSAO_USUARIO",
                column: "Usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERMISSAO_USUARIO");
        }
    }
}
