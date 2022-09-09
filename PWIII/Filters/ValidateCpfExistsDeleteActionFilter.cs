using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PWIII.Core;
using PWIII.Core.Inteface;

namespace PWIII.Filters
{
    public class ValidateCpfExistsDeleteActionFilter : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;

        public ValidateCpfExistsDeleteActionFilter(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("cpf", out var temp);

            if (_cadastroService.GetByCpf((string)temp) == null)
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
    }
}
