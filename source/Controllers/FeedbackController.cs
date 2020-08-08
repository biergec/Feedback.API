using System.Threading.Tasks;
using Feedback.API.Model.Interface;
using Feedback.API.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.API.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }


        /// <summary>
        /// Save Message
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] VmSaveFeedback param)
        {
            param.DeviceKey = DeviceKey;
            param.ApplicationKey = ApplicationKey;

            var result = await feedbackService.SaveFeedback(param);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
