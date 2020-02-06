using Locadora.APIException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Locadora.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is UnauthorizedAccessException)
                SetExceptionResult(context, exception, HttpStatusCode.Unauthorized);
            else if (exception is Exception)
                SetExceptionResult(context, exception, HttpStatusCode.BadRequest);
            else
                SetExceptionResult(context, exception, HttpStatusCode.InternalServerError);
        }

        private static void SetExceptionResult(ExceptionContext context, Exception exception, HttpStatusCode code)
        {
            context.Result = new JsonResult(new ApiException(exception))
            {
                StatusCode = (int)code
            };
        }
    }
}
