using Aplication.Utilities.Middleware.CustomException;
using Dominio.DTOs.Response.ResponseBase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplication.Utilities.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ResponseBase<string>()
                {
                    Code = response.StatusCode 
                };

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Code = response.StatusCode;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Code = response.StatusCode;
                        break;
                    default :
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Code = response.StatusCode;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }


}
