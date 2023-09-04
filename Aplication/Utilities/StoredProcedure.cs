using Domain.DTOs.Response.T22;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Repository.IRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Utilities
{
    public class StoredProcedure
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoredProcedure(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public SqlDataReader Execute(string nombre)
        //{

        //    var connString = (_unitOfWork.GetContext()).Database.GetDbConnection().ConnectionString;
        //    SqlDataReader dr;

        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        SqlCommand cmd = new SqlCommand(nombre, conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.Add(new SqlParameter("@param1", param1));
        //        //cmd.Parameters.Add(new SqlParameter("@param2", param2));

        //        conn.Open();
        //        dr = cmd.ExecuteReader();
        //        //conn.Close();

        //        List<BandejaResgistrarCapacitacionesDTOResponse> list = new List<BandejaResgistrarCapacitacionesDTOResponse>();
        //        while (dr.Read())
        //        {
        //            BandejaResgistrarCapacitacionesDTOResponse dto = new BandejaResgistrarCapacitacionesDTOResponse();

        //            var idSolicitud = dr["IdSolicitud"];
        //            var idResolucion = dr["IdResolucionSolicitud"];
        //            var numeroResolucion = dr["IntNumeroResolucion"];
        //            //var idSolicitud = dr["IdSolicitud"];

        //            //dto.IdSolicitud = dr["IdSolicitud"];
        //            dto.IdResolucionSolicitud = Convert.ToInt32(dr["IdResolucionSolicitud"]);
        //            dto.IntNumeroResolucion = Convert.ToInt32(dr["IntNumeroResolucion"]);
        //            dto.FechaResolucion = Convert.ToString(dr["FechaResolucion"]);
        //            dto.TipoSolicitudId = dr.GetInt32(4);
        //            dto.VcNombre = dr.GetString(5);
        //            dto.BEstado = dr.GetBoolean(6);
        //            dto.IdDocumento = dr.GetInt32(7);
        //            dto.VcPath = dr.GetString(8);
        //            list.Add(dto);
        //        }
        //    }
        //    //dr.Read();
        //    return dr;
        //}
    }
}
