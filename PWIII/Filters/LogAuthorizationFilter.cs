using Microsoft.AspNetCore.Mvc.Filters;

namespace PWIII.Filters
{
    public class LogAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("Filtro de autorização LogAuthorizationFilter > OnAuthorization");

        }
    }
}
