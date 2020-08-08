using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Feedback.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        public string ApplicationKey { get; set; }

        public string DeviceKey { get; set; }


        public BaseController()
        {

        }

        /// <summary>
        /// Control and save secret key
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ApplicationKey = context.HttpContext.Request.Headers["ApplicationKey"].ToString();
            DeviceKey = context.HttpContext.Request.Headers["DeviceKey"].ToString();

            if (string.IsNullOrWhiteSpace(ApplicationKey) || string.IsNullOrWhiteSpace(DeviceKey))
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