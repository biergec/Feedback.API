using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Feedback.API.Controllers
{
    public class FeedbackController : BaseController
    {
        public FeedbackController(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Save Message
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save()
        {
            return Ok();
        }
    }
}
