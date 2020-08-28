using Application.Common.Exceptions;
using ECommerceAPI.Infrastructure.ActionResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace ECommerceAPI.Infrastructure.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            _logger = logger;
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(NotFoundException), HandleNotFoundException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);

            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Invoke(context);
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new InternalServerErrorObjectResult(
                    new JsonErrorResponse(new[] { "An error has occured. Please try again." }));
            }

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails()
            {
                Title = "The resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);
        }

        private class JsonErrorResponse
        {
            public string[] ErrorMessages { get; set; }

            public DateTime TimeGenerated { get; set; }

            private JsonErrorResponse()
            {
                TimeGenerated = DateTime.UtcNow;
            }

            public JsonErrorResponse(string[] errorMessages)
                : this()
            {
                ErrorMessages = errorMessages;
            }
        }
    }
}
