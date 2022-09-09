using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PWIII.Core;
using PWIII.Core.Inteface;

namespace PWIII.Filters
{
    public class IsRegisteredActionFilter : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;

        public IsRegisteredActionFilter(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("id", out var id);
            if (id != null)
            {
                long.TryParse((string)id, out long value);
                if (_cadastroService.GetById(value) == null)
                    context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
