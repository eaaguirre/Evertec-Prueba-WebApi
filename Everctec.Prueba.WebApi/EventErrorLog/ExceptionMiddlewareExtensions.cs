using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Evertec.Prueba.WebApi.EventErrorLog
{
    public static class ExceptionMiddlewareExtensions
    {
        public static  void  ConfigureExceptiionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }

                });

            });
           
     
        }
    }
}
