﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkApi.Migrations
{
    /// <inheritdoc />
    public partial class columnEstadoTareas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Tarea");
        }
    }
}
