using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMateriaisApi.Migrations
{
    public partial class novamigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "materiais",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    unidade_medida = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiais", x => x.id_material);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "polos",
                columns: table => new
                {
                    id_polo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome_polo = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logradouro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polos", x => x.id_polo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    perfil = table.Column<int>(type: "int", nullable: true),
                    codigo_senha = table.Column<int>(type: "int", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordens_servico",
                columns: table => new
                {
                    id_os = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_polo = table.Column<int>(type: "int", nullable: false),
                    tipo_ordem_servico = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordens_servico", x => x.id_os);
                    table.ForeignKey(
                        name: "FK_ordens_servico_polos_id_polo",
                        column: x => x.id_polo,
                        principalTable: "polos",
                        principalColumn: "id_polo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordens_servico_usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "item_ordem_servico",
                columns: table => new
                {
                    id_item_ordem_servico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    id_ordem_servico = table.Column<int>(type: "int", nullable: true),
                    id_material = table.Column<int>(type: "int", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_ordem_servico", x => x.id_item_ordem_servico);
                    table.ForeignKey(
                        name: "FK_item_ordem_servico_materiais_id_material",
                        column: x => x.id_material,
                        principalTable: "materiais",
                        principalColumn: "id_material");
                    table.ForeignKey(
                        name: "FK_item_ordem_servico_ordens_servico_id_ordem_servico",
                        column: x => x.id_ordem_servico,
                        principalTable: "ordens_servico",
                        principalColumn: "id_os");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_item_ordem_servico_id_material",
                table: "item_ordem_servico",
                column: "id_material");

            migrationBuilder.CreateIndex(
                name: "IX_item_ordem_servico_id_ordem_servico",
                table: "item_ordem_servico",
                column: "id_ordem_servico");

            migrationBuilder.CreateIndex(
                name: "IX_materiais_nome",
                table: "materiais",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "IX_materiais_unidade_medida",
                table: "materiais",
                column: "unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_ordens_servico_id_polo",
                table: "ordens_servico",
                column: "id_polo");

            migrationBuilder.CreateIndex(
                name: "IX_ordens_servico_IdUsuario",
                table: "ordens_servico",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_polos_nome_polo",
                table: "polos",
                column: "nome_polo");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_codigo_senha",
                table: "usuarios",
                column: "codigo_senha");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_nome",
                table: "usuarios",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_senha",
                table: "usuarios",
                column: "senha");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_senha_email",
                table: "usuarios",
                columns: new[] { "senha", "email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_ordem_servico");

            migrationBuilder.DropTable(
                name: "materiais");

            migrationBuilder.DropTable(
                name: "ordens_servico");

            migrationBuilder.DropTable(
                name: "polos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
