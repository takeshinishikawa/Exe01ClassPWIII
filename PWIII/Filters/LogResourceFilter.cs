using Microsoft.AspNetCore.Mvc.Filters;

namespace PWIII.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Filtro de Recurso LogResourceFilter > OnResourceExecuted por {context.HttpContext.Request.Headers["Code"]}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.Keys.Contains("Code"))
                context.HttpContext.Request.Headers.Add("Code", Guid.NewGuid().ToString());
            Console.WriteLine($"Filtro de Recurso LogResourceFilter > OnResourceExecuting por {context.HttpContext.Request.Headers["Code"]}");
        }
    }
}
