using Domain.Models.Parametro;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.IRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public static class ApplicationDbContextSeed
    {
        public static void EnsureSeed(this IUnitOfWork context)
        {
            CargarTipoSolicitud(context);
            CargarTipoIdentificacion(context);
            CargarConstantes(context);
            CargarDocumentosSolicitud(context);
            CargarCiudadanoFiltroPor(context);
            CargarFuncionarioFiltroPor(context);
            CargarFuncionarioSeguimientoCapacitacionFiltroPor(context);
            CargarCiudadanoSeguimientoCapacitacionFiltroPor(context);
            CargarDireccionViaPrincipal(context);
            CargarDireccionCardinalidad(context);

            context.Commit();
        }

        private static void CargarTipoSolicitud(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bTipoSolicitud");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Tipo de solicitud",
                    VcCodigoInterno = "bTipoSolicitud",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaTipoIdentificacion = new List<ParametroDetalle>();

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Primera vez",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Renovación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Modificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Recurso de reposición",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Cancelación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaTipoIdentificacion)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarTipoIdentificacion(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bTipoIdentificacion");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Tipo de Identificacion",
                    VcCodigoInterno = "bTipoIdentificacion",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaTipoIdentificacion = new List<ParametroDetalle>();

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "CC",
                TxDescripcion = "Cédula ciudadanía",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "CE",
                TxDescripcion = "Cédula extranjería",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "TI",
                TxDescripcion = "Tarjeta de identidad",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "RC",
                TxDescripcion = "Regsitro civil de nacimiento",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "NUIP",
                TxDescripcion = "Número único de identificación personal",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "PA",
                TxDescripcion = "Pasaporte",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaTipoIdentificacion.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "TE",
                TxDescripcion = "Tarjeta de extranjería",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaTipoIdentificacion)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarConstantes(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bConstantes");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Constantes",
                    VcCodigoInterno = "bConstantes",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            var infoConstantes = new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Inicio de solicitud",
                TxDescripcion = "HU 01",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            };

            if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == infoConstantes.VcNombre.ToUpper() && prop.ParametroId.Equals(infoConstantes.ParametroId)))
            {
                context.GetSet<long, ParametroDetalle>().Add(infoConstantes);
            }

            context.Commit();

            List<ParametroDetalle> listaConstantes = new List<ParametroDetalle>();

            listaConstantes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                IdPadre = infoConstantes.IdParametroDetalle,
                VcNombre = "Autorización para capacitadores de manipulación de alimentos",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaConstantes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                IdPadre = infoConstantes.IdParametroDetalle,
                VcNombre = "Autorización para desarrollar programas de educación sanitaria, que permite capacitar al personal que manipula, " +
                        "procesa y expende alimentos y productos cárnicos comestibles, alimentos comercializados en vía pública, leche cruda para consumo" +
                        " humano directo comercializada de manera ambulante, y objetos, envases, materiales y equipamientos en contacto con alimentos.",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            infoConstantes = new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Registro existoso de solicitud",
                TxDescripcion = "HU 04",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            };

            if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == infoConstantes.VcNombre.ToUpper() && prop.ParametroId.Equals(infoConstantes.ParametroId)))
            {
                context.GetSet<long, ParametroDetalle>().Add(infoConstantes);
            }

            context.Commit();

            listaConstantes.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                IdPadre = infoConstantes.IdParametroDetalle,
                VcNombre = "Por favor verifique su mensaje de confirmación en su correo electrónico, para hacerle seguimiento a " +
                            "este trámite no olvide anotar el ID del ticket descrito a continuación. Muchas gracias por utilizar los " +
                            "servicios en línea de la Secretaría Distrital de Salud.",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });


            foreach (ParametroDetalle item in listaConstantes)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }
            context.Commit();
        }
        private static void CargarDocumentosSolicitud(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bDocumentosSolicitud");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Documentos de la solicitud",
                    VcCodigoInterno = "bDocumentosSolicitud",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaDocumentos = new List<ParametroDetalle>();

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Cédula de ciudadanía",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Carta de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Hoja de vida",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Descripción detallada del curso",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Pensum de pregrado",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Diploma profesional / tecnólogo",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tarjeta profesional",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Resumen didáctico del curso",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Memorias ilustradas",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Revisión capacitación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            foreach (ParametroDetalle item in listaDocumentos)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarCiudadanoFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bCiudadanoFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Ciudanano Filtrar por",
                    VcCodigoInterno = "bCiudadanoFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaDocumentos = new List<ParametroDetalle>();

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "ID de Solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Estado",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaDocumentos.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Fecha de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaDocumentos)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarFuncionarioFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bFuncionarioFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Funcionario Filtrar por",
                    VcCodigoInterno = "bFuncionarioFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaFiltrarPor = new List<ParametroDetalle>();

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "ID Solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Solicitante",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "No. Identificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tipo de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tipo de Solicitante",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Fecha de solicitud",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Acciones permitidas",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tiempo de atención restante",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaFiltrarPor)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarFuncionarioSeguimientoCapacitacionFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bFuncionarioSeguimientoCapacitacionFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Funciorario Seguimiento Capacitacion Filtrar por",
                    VcCodigoInterno = "bFuncionarioSeguimientoCapacitacionFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaFiltrarPor = new List<ParametroDetalle>();

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Número de resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Nombre del ciudadano / entidad",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Identificación",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaFiltrarPor)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarCiudadanoSeguimientoCapacitacionFiltroPor(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bCiudadanoSeguimientoCapacitacionFiltrarPor");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Ciudadano Seguimiento Capacitacion Filtrar por",
                    VcCodigoInterno = "bCiudadanoSeguimientoCapacitacionFiltrarPor",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaFiltrarPor = new List<ParametroDetalle>();

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Número de resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Fecha de resolución",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Tipo de autorización",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaFiltrarPor.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Estado de autorización",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaFiltrarPor)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarDireccionViaPrincipal(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bDireccionViaPpl");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Vía",
                    VcCodigoInterno = "bDireccionViaPpl",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                    
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaViaPpl = new List<ParametroDetalle>();

            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "CL",
                TxDescripcion = "Calle",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "DG",
                TxDescripcion = "Diagonal",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "AC",
                TxDescripcion = "Avenida Calle",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "KR",
                TxDescripcion = "Carrera",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "TV",
                TxDescripcion = "Transversal",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "AK",
                TxDescripcion = "Avenida Carrera",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaViaPpl.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "AV",
                TxDescripcion = "Avenida",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaViaPpl)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        private static void CargarDireccionCardinalidad(IUnitOfWork context)
        {
            IQueryable<Parametro> query = context.GetSet<long, Parametro>().AsNoTracking();

            query = query.Where(prop => prop.VcCodigoInterno == "bDireccionCardinalidad");

            Parametro parametroPuente = null;
            Parametro parametro = query.AsNoTracking().FirstOrDefault();

            if (parametro is null)
            {
                var parametroAguardar = new Parametro
                {
                    VcNombre = "Dirección Cardinalidad",
                    VcCodigoInterno = "bDireccionCardinalidad",
                    BEstado = true,
                    DtFechaCreacion = DateTime.Now,
                    DtFechaActualizacion = DateTime.Now
                    
                };

                context.GetSet<long, Parametro>().Add(parametroAguardar);
                context.Commit();

                parametroPuente = parametroAguardar;
            }
            else
            {
                parametroPuente = parametro;
            }

            List<ParametroDetalle> listaCardinalidad = new List<ParametroDetalle>();

            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Este",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Oeste",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });

            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Sur",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            listaCardinalidad.Add(new ParametroDetalle
            {
                ParametroId = parametroPuente.IdParametro,
                VcNombre = "Norte",
                TxDescripcion = "",
                VcCodigoInterno = "",
                DCodigoIterno = 0,
                BEstado = true,
                RangoDesde = 0,
                RangoHasta = 0
            });
            
            foreach (ParametroDetalle item in listaCardinalidad)
            {
                //Se genera la validacion con el ParametroId, para que se puedan insertar Detalles con el mismo nombre 
                if (!context.GetSet<long, ParametroDetalle>().Any(prop => prop.VcNombre.ToUpper() == item.VcNombre.ToUpper() && prop.ParametroId.Equals(item.ParametroId)))
                {
                    context.GetSet<long, ParametroDetalle>().Add(item);
                }
            }

        }
        

    }
}
