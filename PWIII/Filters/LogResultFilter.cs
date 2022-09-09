using Microsoft.AspNetCore.Mvc.Filters;

namespace PWIII.Filters
{
    public class LogResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Filtro de Resultado LogResultFilter > OnActionExecuting por {context.HttpContext.Request.Headers["Code"]}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Filtro de Resultado LogResultFilter > OnResultExecuting por {context.HttpContext.Request.Headers["Code"]}");
        }
    }
}
