using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace PWIII.Filters
{
    public class LogActionFilter : IActionFilter
    {
        Stopwatch stopwatch = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"Filtro de Ação LogActionFilter > OnActionExecuted por {context.HttpContext.Request.Headers["Code"]}\nAção finalizada em: {stopwatch.Elapsed.Seconds} segundos");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
            Console.WriteLine($"Filtro de Ação LogActionFilter > OnActionExecuting por {context.HttpContext.Request.Headers["Code"]}");
        }
    }
}
