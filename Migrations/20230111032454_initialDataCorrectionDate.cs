using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkApi.Migrations
{
    /// <inheritdoc />
    public partial class initialDataCorrectionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30304"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 11, 3, 24, 53, 994, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30305"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 11, 3, 24, 53, 994, DateTimeKind.Utc).AddTicks(3696));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30304"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 11, 3, 23, 42, 592, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("199bd2f7-4732-4493-a8eb-40bd19c30305"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 11, 3, 23, 42, 592, DateTimeKind.Utc).AddTicks(2785));
        }
    }
}
