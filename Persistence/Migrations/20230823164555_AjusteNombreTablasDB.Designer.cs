﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230823164555_AjusteNombreTablasDB")]
    partial class AjusteNombreTablasDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Parametro.Parametro", b =>
                {
                    b.Property<long>("IdParametro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdParametro"));

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtFechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("VcCodigoInterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VcNombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdParametro");

                    b.ToTable("Parametro", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Parametro.ParametroDetalle", b =>
                {
                    b.Property<long>("IdParametroDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdParametroDetalle"));

                    b.Property<bool>("BEstado")
                        .HasColumnType("bit");

                    b.Property<decimal?>("DCodigoIterno")
                        .HasPrecision(17, 3)
                        .HasColumnType("decimal(17,3)");

                    b.Property<long?>("IdPadre")
                        .HasColumnType("bigint");

                    b.Property<long>("ParametroId")
                        .HasColumnType("bigint");

                    b.Property<int?>("RangoDesde")
                        .HasColumnType("int");

                    b.Property<int?>("RangoHasta")
                        .HasColumnType("int");

                    b.Property<string>("TxDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcCodigoInterno")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VcNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdParametroDetalle");

                    b.HasIndex("IdPadre");

                    b.HasIndex("ParametroId");

                    b.ToTable("ParametroDetalle", (string)null);
                });

            modelBuilder.Entity("Domain.Models.T22.CapacitadorSolicitud", b =>
                {
                    b.Property<int>("IdCapacitadorSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCapacitadorSolicitud"));

                    b.Property<bool>("BlIsValid")
                        .HasColumnType("bit");

                    b.Property<int>("IntNumeroIdentificacion")
                        .HasColumnType("int");

                    b.Property<long>("IntTelefono")
                        .HasColumnType("bigint");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<int>("TipoIdentificacionId")
                        .HasColumnType("int");

                    b.Property<string>("VcEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcPrimerApellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VcPrimerNombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VcSegundoApellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VcSegundoNombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VcTituloProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vcNumeroTarjetaProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCapacitadorSolicitud");

                    b.HasIndex("SolicitudId");

                    b.ToTable("CapacitadorSolicitudes", (string)null);
                });

            modelBuilder.Entity("Domain.Models.T22.CapacitadorTipoCapacitacion", b =>
                {
                    b.Property<int>("IdTipoCapacitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdCapacitadorSolicitud")
                        .HasColumnType("int");

                    b.HasKey("IdTipoCapacitacion", "IdCapacitadorSolicitud");

                    b.HasIndex("IdCapacitadorSolicitud");

                    b.ToTable("CapacitadorTipoCapacitaciones", (string)null);
                });

            modelBuilder.Entity("Domain.Models.T22.DocumentoSolicitud", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDocumento"));

                    b.Property<bool?>("BlIsValid")
                        .HasColumnType("bit");

                    b.Property<bool?>("BlUsuarioVentanilla")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DtFechaCargue")
                        .HasColumnType("datetime2");

                    b.Property<int>("IntVersion")
                        .HasColumnType("int");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("VcNombreDocumento")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("VcPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocumento");

                    b.ToTable("DocumentoSolicitudes", (string)null);
                });

            modelBuilder.Entity("Domain.Models.T22.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<bool>("BlIsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("VcDescripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("VcTipoEstado")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados", (string)null);

                    b.HasData(
                        new
                        {
                            IdEstado = 1,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "En Revisión"
                        },
                        new
                        {
                            IdEstado = 2,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "En Verificación"
                        },
                        new
                        {
                            IdEstado = 3,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Para firma"
                        },
                        new
                        {
                            IdEstado = 4,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Devuelta por coordinador"
                        },
                        new
                        {
                            IdEstado = 5,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Devuelta por Subdirector"
                        },
                        new
                        {
                            IdEstado = 6,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Vencimiento de terminos"
                        },
                        new
                        {
                            IdEstado = 7,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Aprobado"
                        },
                        new
                        {
                            IdEstado = 8,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "En Subsanación"
                        },
                        new
                        {
                            IdEstado = 9,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Anulado"
                        },
                        new
                        {
                            IdEstado = 10,
                            BlIsEnable = true,
                            VcDescripcion = "",
                            VcTipoEstado = "Negado"
                        });
                });

            modelBuilder.Entity("Domain.Models.T22.SeguimientoAuditoriaSolicitud", b =>
                {
                    b.Property<int>("IdObservacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdObservacion"));

                    b.Property<DateTime>("DtFechaObservacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("VcObservacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdObservacion");

                    b.HasIndex("SolicitudId");

                    b.ToTable("SeguimientoAuditoriaSolicitudes", (string)null);
                });

            modelBuilder.Entity("Domain.Models.T22.Solicitud", b =>
                {
                    b.Property<int>("IdSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSolicitud"));

                    b.Property<DateTime>("DtFechaSolicitud")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("IntNumeroIdentificacionUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoValidacionId")
                        .HasColumnType("int");

                    b.Property<int>("TipoSolicitanteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoSolicitudId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioAsignadoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("VcNombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VcRadicado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSolicitud");

                    b.HasIndex("EstadoId")
                        .IsUnique();

                    b.ToTable("Solicitudes", (string)null);
                });

            modelBuilder.Entity("Domain.Models.T22.TipoCapacitacion", b =>
                {
                    b.Property<int>("IdTipoCapacitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoCapacitacion"));

                    b.Property<bool>("BlIsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("VcDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoCapacitacion");

                    b.ToTable("TipoCapacitaciones", (string)null);

                    b.HasData(
                        new
                        {
                            IdTipoCapacitacion = 1,
                            BlIsEnable = true,
                            VcDescripcion = "Carnes y productos cárnicos comestibles"
                        },
                        new
                        {
                            IdTipoCapacitacion = 2,
                            BlIsEnable = true,
                            VcDescripcion = "Leche cruda"
                        },
                        new
                        {
                            IdTipoCapacitacion = 3,
                            BlIsEnable = true,
                            VcDescripcion = "Alimentos en vía publica"
                        });
                });

            modelBuilder.Entity("Domain.Models.Parametro.ParametroDetalle", b =>
                {
                    b.HasOne("Domain.Models.Parametro.ParametroDetalle", "Padre")
                        .WithMany("Hijos")
                        .HasForeignKey("IdPadre");

                    b.HasOne("Domain.Models.Parametro.Parametro", "Parametro")
                        .WithMany("ParametroDetalles")
                        .HasForeignKey("ParametroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Parametro");

                    b.Navigation("Padre");

                    b.Navigation("Parametro");
                });

            modelBuilder.Entity("Domain.Models.T22.CapacitadorSolicitud", b =>
                {
                    b.HasOne("Domain.Models.T22.Solicitud", "Solicitud")
                        .WithMany("CapacitadorSolicitud")
                        .HasForeignKey("SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitud");
                });

            modelBuilder.Entity("Domain.Models.T22.CapacitadorTipoCapacitacion", b =>
                {
                    b.HasOne("Domain.Models.T22.CapacitadorSolicitud", "CapacitadorSolicitud")
                        .WithMany("CapacitadorTipoCapacitacion")
                        .HasForeignKey("IdCapacitadorSolicitud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.T22.TipoCapacitacion", "TipoCapacitacion")
                        .WithMany("CapacitadorTipoCapacitacion")
                        .HasForeignKey("IdTipoCapacitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CapacitadorSolicitud");

                    b.Navigation("TipoCapacitacion");
                });

            modelBuilder.Entity("Domain.Models.T22.SeguimientoAuditoriaSolicitud", b =>
                {
                    b.HasOne("Domain.Models.T22.Solicitud", "Solicitud")
                        .WithMany("SeguimientoAuditoriaSolicitud")
                        .HasForeignKey("SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitud");
                });

            modelBuilder.Entity("Domain.Models.T22.Solicitud", b =>
                {
                    b.HasOne("Domain.Models.T22.Estado", "Estado")
                        .WithOne("Solicitud")
                        .HasForeignKey("Domain.Models.T22.Solicitud", "EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Domain.Models.Parametro.Parametro", b =>
                {
                    b.Navigation("ParametroDetalles");
                });

            modelBuilder.Entity("Domain.Models.Parametro.ParametroDetalle", b =>
                {
                    b.Navigation("Hijos");
                });

            modelBuilder.Entity("Domain.Models.T22.CapacitadorSolicitud", b =>
                {
                    b.Navigation("CapacitadorTipoCapacitacion");
                });

            modelBuilder.Entity("Domain.Models.T22.Estado", b =>
                {
                    b.Navigation("Solicitud")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.T22.Solicitud", b =>
                {
                    b.Navigation("CapacitadorSolicitud");

                    b.Navigation("SeguimientoAuditoriaSolicitud");
                });

            modelBuilder.Entity("Domain.Models.T22.TipoCapacitacion", b =>
                {
                    b.Navigation("CapacitadorTipoCapacitacion");
                });
#pragma warning restore 612, 618
        }
    }
}
