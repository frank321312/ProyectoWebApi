using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseAplicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    IdProject = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.IdProject);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProyectoIdProject = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Proyecto_ProyectoIdProject",
                        column: x => x.ProyectoIdProject,
                        principalTable: "Proyecto",
                        principalColumn: "IdProject");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProyectoIdProject = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Proyecto_ProyectoIdProject",
                        column: x => x.ProyectoIdProject,
                        principalTable: "Proyecto",
                        principalColumn: "IdProject");
                    table.ForeignKey(
                        name: "FK_Ticket_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Proyecto",
                columns: new[] { "IdProject", "Nombre" },
                values: new object[,]
                {
                    { new Guid("15c33d17-0fd2-42cb-a38e-9016a802fbdd"), "Proyecto_1" },
                    { new Guid("e2618a6c-ff07-46b6-99a7-d1dfeb05428a"), "Proyecto_3" },
                    { new Guid("e263ca67-7790-40bb-b5a1-e75cb125f85f"), "Proyecto_2" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "Descripcion", "Estado", "IdUsuario", "Nombre", "ProyectoIdProject" },
                values: new object[,]
                {
                    { new Guid("4b91ce3e-d1b7-4537-82c9-fdabef627ca5"), "", "Abierto", null, "Logica", null },
                    { new Guid("c5e3bc1a-5cec-4710-a238-12e6ac029d98"), "", "Abierto", null, "Programacion", null },
                    { new Guid("deaac420-03df-4dec-a1c1-9c68640a8319"), "", "Abierto", null, "Analisis", null }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Nombre", "ProyectoIdProject" },
                values: new object[,]
                {
                    { new Guid("1d98bb2f-d25b-4b4b-a5ab-8f87eaf6cc3b"), "User_2", null },
                    { new Guid("52175b47-342e-4047-8c72-463386cf1908"), "User_3", null },
                    { new Guid("e9cb398d-3924-42a0-baf0-787cd58f69b0"), "User_1", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdUsuario",
                table: "Ticket",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProyectoIdProject",
                table: "Ticket",
                column: "ProyectoIdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ProyectoIdProject",
                table: "Usuario",
                column: "ProyectoIdProject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Proyecto");
        }
    }
}
