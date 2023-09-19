using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CampoDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioAsignadoId",
                schema: "manipalimentos",
                table: "Solicitudes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VcDireccionUsuario",
                schema: "manipalimentos",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6644), new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6625) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6649), new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6649) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 3L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6651), new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6650) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 4L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6652), new DateTime(2023, 9, 19, 11, 12, 2, 810, DateTimeKind.Local).AddTicks(6652) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VcDireccionUsuario",
                schema: "manipalimentos",
                table: "Solicitudes");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioAsignadoId",
                schema: "manipalimentos",
                table: "Solicitudes",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7301), new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7292) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7305), new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7304) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 3L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7307), new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7306) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 4L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7308), new DateTime(2023, 9, 18, 8, 53, 52, 433, DateTimeKind.Local).AddTicks(7308) });
        }
    }
}
