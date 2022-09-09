using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace PWIII.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 500,
                Title = "Erro inesperado. Tente novamente.",
                Detail = "Erro inesperado. Tente novamente.",
                Type = context.Exception.GetType().Name
            };
            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}.");
            switch (context.Exception)
            {
                case ArgumentNullException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    problem.Detail = "Erro inesperado no sistema";
                    problem.Title = "Erro inesperado no sistema";
                    context.Result = new ObjectResult(problem);
                    break;
                case SqlException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    problem.Detail = "Erro inesperado ao se comunicar com o banco de dados";
                    problem.Title = "Erro inesperado ao se comunicar com o banco de dados";
                    context.Result = new ObjectResult(problem);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problem);
                    break;
            }
        }


    }
}
