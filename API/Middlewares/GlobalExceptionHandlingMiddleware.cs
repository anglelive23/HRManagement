using Infrastructure.Exceptions;
using Serilog;
using System.Net;

namespace API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        #region Fields and Properties
        private readonly RequestDelegate _next;
        #endregion

        #region Constructors
        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        #endregion

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleGlobalExceptionAsync(context, ex);
            }
        }
        private Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = Guid.NewGuid();
            switch (exception)
            {


                case DataFailureException dataFailureException:
                    {
                        var message = dataFailureException.InnerException != null ? dataFailureException.InnerException.Message : dataFailureException.Message;
                        Log.ForContext("DataFailureError", message)
                            .Error($"Data Failure Error with code: {errorCode} occurred in Infrastructure Layer, Contact system admin with ErrorCode.");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return context.Response.WriteAsJsonAsync(new
                        {
                            ErrorCode = errorCode,
                            Message = "Data Failure Error occurred in Infrastructure Layer.",
                            ErrorMessage = message
                        });
                    }

                default:
                    {
                        Log.ForContext("ErrorCode", errorCode)
                           .Error(exception, $"An Error with code: {errorCode} occured in API");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return context.Response.WriteAsJsonAsync(new
                        {
                            ErrorCode = errorCode,
                            Message = "An exception was thrown in the system.",
                            ErrorMessage = exception.Message
                        });
                    }
            }
        }
    }
}
