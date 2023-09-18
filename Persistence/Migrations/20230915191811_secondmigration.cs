using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9145), new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9134) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9151), new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9151) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 3L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9153), new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9152) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 4L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9155), new DateTime(2023, 9, 15, 14, 18, 11, 55, DateTimeKind.Local).AddTicks(9154) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7507), new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7511), new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7510) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 3L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7513), new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 4L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7514), new DateTime(2023, 9, 15, 12, 53, 38, 499, DateTimeKind.Local).AddTicks(7513) });
        }
    }
}
