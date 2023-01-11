using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeworkApi.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "peso" },
                values: new object[,]
                {
                    { new Guid("199bd2f7-4732-4493-a8eb-40bd19c30302"), null, "Actividades Personales", 50 },
                    { new Guid("199bd2f7-4732-4493-a8eb-40bd19c303d3"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "Estado", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("199bd2f7-4732-4493-a8eb-40bd19c30304"), new Guid("199bd2f7-4732-4493-a8eb-40bd19c303d3"), null, "Pendiente", new DateTime(2023, 1, 10, 22, 19, 35, 692, DateTimeKind.Local).AddTicks(4137), 2, "Pago de servicios publicos" },
                    { new Guid("199bd2f7-4732-4493-a8eb-40bd19c30305"), new Guid("199bd2f7-4732-4493-a8eb-40bd19c30302"), null, "Pendiente", new DateTime(2023, 1, 10, 22, 19, 35, 692, DateTimeKind.Local).AddTicks(4150), 1, "Terminar de ver pelicula en netflic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30304"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30305"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30302"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c303d3"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
