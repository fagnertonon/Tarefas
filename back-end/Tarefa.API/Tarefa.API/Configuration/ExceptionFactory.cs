using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using NLog;
using System.Net;

namespace Tarefas.API.Configuration
{
    public static class ExceptionFactory
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, int StatusCode = 0, string message = "")
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
                        LogTraceFactory.LogError($"Something went wrong: {contextFeature.Error}");

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
    public class ErrorDetails
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }


		public override string ToString()
		{
			return JsonConvert.SerializeObject(this); 
		}
	}
    public static class LogTraceFactory
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public static void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public static void LogError(string message)
        {
            logger.Error(message);
        }

        public static void LogInfo(string message)
        {
            logger.Info(message);
        }

        public static void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
