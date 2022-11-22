using Microsoft.AspNetCore.Mvc.Filters;


namespace WebExceptionPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
