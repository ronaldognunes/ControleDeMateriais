using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMateriaisApi.Migrations
{
    public partial class teste01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "materiais",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    unidade_medida = table.Column<string>(type: "TEXT", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiais", x => x.id_material);
                });

            migrationBuilder.CreateTable(
                name: "polos",
                columns: table => new
                {
                    id_polo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome_polo = table.Column<string>(type: "TEXT", nullable: true),
                    logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    numero = table.Column<int>(type: "INTEGER", nullable: false),
                    cep = table.Column<string>(type: "TEXT", nullable: true),
                    bairro = table.Column<string>(type: "TEXT", nullable: true),
                    cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Uf = table.Column<string>(type: "TEXT", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polos", x => x.id_polo);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    senha = table.Column<string>(type: "TEXT", nullable: true),
                    perfil = table.Column<int>(type: "INTEGER", nullable: true),
                    codigo_senha = table.Column<int>(type: "INTEGER", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "ordens_servico",
                columns: table => new
                {
                    id_os = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: true),
                    numero = table.Column<int>(type: "INTEGER", nullable: false),
                    bairro = table.Column<string>(type: "TEXT", nullable: true),
                    cidade = table.Column<string>(type: "TEXT", nullable: true),
                    cep = table.Column<string>(type: "TEXT", nullable: true),
                    complemento = table.Column<string>(type: "TEXT", nullable: true),
                    id_polo = table.Column<int>(type: "INTEGER", nullable: false),
                    tipo_ordem_servico = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "item_ordem_servico",
                columns: table => new
                {
                    id_item_ordem_servico = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    id_ordem_servico = table.Column<int>(type: "INTEGER", nullable: true),
                    id_material = table.Column<int>(type: "INTEGER", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                });

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
