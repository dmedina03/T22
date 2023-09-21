using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class configuracionRecurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "Estados",
                columns: new[] { "IdEstado", "BlIsEnable", "VcDescripcion", "VcTipoEstado" },
                values: new object[] { 12, true, "", "Recurso respondido" });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 1L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1931), new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1905) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 2L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1943), new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1942) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 3L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1945), new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1944) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "Parametro",
                keyColumn: "IdParametro",
                keyValue: 4L,
                columns: new[] { "DtFechaActualizacion", "DtFechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1946), new DateTime(2023, 9, 20, 10, 40, 33, 825, DateTimeKind.Local).AddTicks(1946) });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 11L,
                columns: new[] { "ParametroId", "TxDescripcion", "VcNombre" },
                values: new object[] { 2L, "Recurso", "Recurso" });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 12L,
                column: "VcNombre",
                value: "Primera vez");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 13L,
                column: "VcNombre",
                value: "Renovación");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 14L,
                column: "VcNombre",
                value: "Modificación");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 15L,
                column: "VcNombre",
                value: "Recurso de reposición");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 16L,
                columns: new[] { "ParametroId", "VcNombre" },
                values: new object[] { 3L, "Cancelación" });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 17L,
                column: "VcNombre",
                value: "Actos administrativos generados");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 18L,
                column: "VcNombre",
                value: "Autorizaciones canceladas");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 19L,
                column: "VcNombre",
                value: "Seguimiento capacitaciones");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 20L,
                column: "VcNombre",
                value: "Listado de capacitadores autorizados INVIMA");

            migrationBuilder.InsertData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "BEstado", "DCodigoIterno", "IdPadre", "ParametroId", "RangoDesde", "RangoHasta", "TxDescripcion", "VcCodigoInterno", "VcNombre" },
                values: new object[] { 21L, true, 0m, null, 4L, 0, 0, "", "", "Listado de capacitadores suspendidos INVIMA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 21L);

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

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 11L,
                columns: new[] { "ParametroId", "TxDescripcion", "VcNombre" },
                values: new object[] { 3L, "", "Primera vez" });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 12L,
                column: "VcNombre",
                value: "Renovación");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 13L,
                column: "VcNombre",
                value: "Modificación");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 14L,
                column: "VcNombre",
                value: "Recurso de reposición");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 15L,
                column: "VcNombre",
                value: "Cancelación");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 16L,
                columns: new[] { "ParametroId", "VcNombre" },
                values: new object[] { 4L, "Actos administrativos generados" });

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 17L,
                column: "VcNombre",
                value: "Autorizaciones canceladas");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 18L,
                column: "VcNombre",
                value: "Seguimiento capacitaciones");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 19L,
                column: "VcNombre",
                value: "Listado de capacitadores autorizados INVIMA");

            migrationBuilder.UpdateData(
                schema: "manipalimentos",
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 20L,
                column: "VcNombre",
                value: "Listado de capacitadores suspendidos INVIMA");
        }
    }
}
