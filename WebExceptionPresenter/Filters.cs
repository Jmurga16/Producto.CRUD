
using FluentValidation;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebExceptionPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(GeneralException),new GeneralExceptionHandler() },
                    { typeof(ValidationException), new ValidationExceptionHandler() }
                }
                ));
        }
    }
}
