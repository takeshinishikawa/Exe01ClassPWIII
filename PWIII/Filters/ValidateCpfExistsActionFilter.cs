using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PWIII.Core;
using PWIII.Core.Inteface;

namespace PWIII.Filters
{
    public class ValidateCpfExistsActionFilter : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;

        public ValidateCpfExistsActionFilter(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("novoCadastro", out var temp);

            Cadastro cadastro = (Cadastro)temp;

            if (cadastro != null && _cadastroService.GetByCpf(cadastro.Cpf) != null)
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
        }
    }
}
