using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITRockTaskManagementAPI.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException) context.Result = new BadRequestObjectResult(context.Exception.Message);

            else
            {
                context.Result = new ObjectResult($"Internal server error: {context.Exception.Message}")
                {
                    StatusCode = 500
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
