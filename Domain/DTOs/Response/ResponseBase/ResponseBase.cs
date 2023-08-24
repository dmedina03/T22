using System.Net;

namespace Dominio.DTOs.Response.ResponseBase
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            ResponseTime = DateTime.UtcNow.AddHours(-5);
        }

        public ResponseBase(HttpStatusCode code = HttpStatusCode.OK, string message = null, T data = default, int count = 0)
        {
            ResponseTime = DateTime.UtcNow.AddHours(-5);
            Code = (int)code;
            Message = message;
            Data = data;
            Count = count;
        }
        public ResponseBase(HttpStatusCode code= HttpStatusCode.BadRequest, string message = "Ocurrio un error, verifique nuevamente", IDictionary<string, string[]>? errors = null)
        {
            ResponseTime = DateTime.UtcNow.AddHours(-5);
            Code = (int)code;
            Message = message;
            Count = 0;
            Errors = errors;
        }

        public ResponseBase(T data, string message = "Solicitud OK.", int count = 0)
        {
            Data = data;
            Code = (int)HttpStatusCode.OK;
            Message = message;
            ResponseTime = DateTime.UtcNow.AddHours(-5);
            if (data is List<T> && count == 0)
            {
                Count = (data as List<T>).Count;
            }
        }

        public ResponseBase(HttpStatusCode code = HttpStatusCode.InternalServerError, string message = "Error en el servidor!")
        {
            Code = (int)code;
            Message = message;
            ResponseTime = DateTime.UtcNow.AddHours(-5);
        }


        public string Message { get; set; }


        public int Count { get; set; }


        public DateTime ResponseTime { get; set; }


        public T Data { get; set; }

        public int Code { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
