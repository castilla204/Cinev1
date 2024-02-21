using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class contextconrelacciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas");

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Butacas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Peliculas",
                newName: "PeliculaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Butacas",
                newName: "SalaID");

            migrationBuilder.AlterColumn<int>(
                name: "SalaID",
                table: "Butacas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ButacaID",
                table: "Butacas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas",
                column: "ButacaID");

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSala = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeliculaID = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionID);
                    table.ForeignKey(
                        name: "FK_Sesiones_Peliculas_PeliculaID",
                        column: x => x.PeliculaID,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sesiones_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SesionID = table.Column<int>(type: "int", nullable: false),
                    ButacaID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Butacas_ButacaID",
                        column: x => x.ButacaID,
                        principalTable: "Butacas",
                        principalColumn: "ButacaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Sesiones_SesionID",
                        column: x => x.SesionID,
                        principalTable: "Sesiones",
                        principalColumn: "SesionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "NombreSala" },
                values: new object[] { 1, "Sala 1" });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "NombreSala" },
                values: new object[] { 2, "Sala 2" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Contrasena", "CorreoElectronico", "Nombre", "Rol" },
                values: new object[] { 1, "1234", "Alonsoalvira@gmail.com", "Juan", 1 });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "ButacaID", "Estado", "SalaID" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 1, 1 },
                    { 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "SesionID", "FechaHora", "PeliculaID", "SalaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 29, 21, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 2, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "ButacaID", "SesionID", "UsuarioID" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "ButacaID", "SesionID", "UsuarioID" },
                values: new object[] { 2, 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Butacas_SalaID",
                table: "Butacas",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ButacaID",
                table: "Reservas",
                column: "ButacaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_SesionID",
                table: "Reservas",
                column: "SesionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioID",
                table: "Reservas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_PeliculaID",
                table: "Sesiones",
                column: "PeliculaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_SalaID",
                table: "Sesiones",
                column: "SalaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Butacas_Salas_SalaID",
                table: "Butacas",
                column: "SalaID",
                principalTable: "Salas",
                principalColumn: "SalaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Butacas_Salas_SalaID",
                table: "Butacas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas");

            migrationBuilder.DropIndex(
                name: "IX_Butacas_SalaID",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "ButacaID",
                table: "Butacas");

            migrationBuilder.RenameColumn(
                name: "PeliculaID",
                table: "Peliculas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SalaID",
                table: "Butacas",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Butacas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Butacas",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 3, 2 });
        }
    }
}
