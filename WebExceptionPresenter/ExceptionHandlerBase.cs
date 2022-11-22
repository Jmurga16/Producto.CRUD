using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebExceptionPresenter
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231Types =
            new Dictionary<int, string>
            {
                {
                    StatusCodes.Status500InternalServerError,
                    "https://developer.mozilla.org/es/docs/Web/HTTP/Status/500"
                },
                {
                    StatusCodes.Status400BadRequest,
                    "https://developer.mozilla.org/es/docs/Web/HTTP/Status/400"
                },
                {
                    StatusCodes.Status404NotFound,
                    "https://developer.mozilla.org/es/docs/Web/HTTP/Status/404"
                }
            };
        public Task SetResult(ExceptionContext context, int? status, string title, string detail)
        {
            if (status != null)
            {
                ProblemDetails Details = new ProblemDetails

                {
                    Status = status,
                    Title = title,
                    Type = RFC7231Types.ContainsKey(status.Value) ? RFC7231Types[status.Value] : "",
                    Detail = detail
                };

                context.Result = new ObjectResult(Details)
                {
                    StatusCode = status
                };
            }


            context.ExceptionHandled = true;
            return Task.CompletedTask;

        }
    }
}
