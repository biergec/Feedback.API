using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Feedback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Control secret key
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Token varsa giriş yapmış demektir
            var applicationNameRequest = context.HttpContext.Request.Headers["ApplicationName"].ToString();
            var applicationKeyRequest = context.HttpContext.Request.Headers["ApplicationKey"].ToString();

            var appSecretKeyLocal = _configuration[$"Applications:App{applicationNameRequest}"];
            if (string.IsNullOrWhiteSpace(appSecretKeyLocal) || appSecretKeyLocal != applicationKeyRequest)
            {
                // Not authorize
                context.Result = Unauthorized("...");
                //await next();
            }
            else
            {
                await next();
            }
        }
    }
}