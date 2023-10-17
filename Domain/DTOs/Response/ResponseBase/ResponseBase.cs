using System.Net;

namespace Dominio.DTOs.Response.ResponseBase
{
    public class ResponseBase<T>
    {

        public string Message { get; set; } = string.Empty;


        public int Count { get; set; }


        public DateTime ResponseTime { get; set; }


        public T? Data { get; set; } 

        public int Code { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
#pragma warning disable  // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        public ResponseBase()
        {
            ResponseTime = DateTime.UtcNow.AddHours(-5);
        }
#pragma warning disable  // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        public ResponseBase(HttpStatusCode code = HttpStatusCode.OK, string message = "OK", T? data = default, int count = 0)
        {
            ResponseTime = DateTime.UtcNow.AddHours(-5);
            Code = (int)code;
            Message = message;
            Data = data;
            Count = count;
        }
#pragma warning disable  // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        public ResponseBase(HttpStatusCode code= HttpStatusCode.BadRequest, string message = "Ocurrio un error, verifique nuevamente", IDictionary<string, string[]>? errors = null)
        {
            ResponseTime = DateTime.UtcNow.AddHours(-5);
            Code = (int)code;
            Message = message;
            Count = 0;
            Errors = errors;
        }
#pragma warning disable  // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.

        public ResponseBase(HttpStatusCode code = HttpStatusCode.InternalServerError, string message = "Error en el servidor!")
        {
            Code = (int)code;
            Message = message;
            ResponseTime = DateTime.UtcNow.AddHours(-5);
        }

    }
}
