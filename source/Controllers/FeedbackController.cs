using System;
using System.Threading.Tasks;
using Feedback.API.Model.Interface;
using Feedback.API.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Feedback.API.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService feedbackService;


        public FeedbackController(IFeedbackService feedbackService, IMyEmailSender myEmailSender, IConfiguration config)
        {
            this.feedbackService = feedbackService;

        }

        /// <summary>
        /// Hi!
        /// </summary>
        /// <returns></returns>
        [HttpGet("Hi")]
        public IActionResult Hi([FromBody] VmSaveFeedback param)
        {
            return Ok("Hi");
        }


        /// <summary>
        /// Save Message
        /// </summary>
        /// <returns></returns>
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] VmSaveFeedback param)
        {
            param.DeviceKey = DeviceKey;
            param.ApplicationKey = ApplicationKey;

            var result = await feedbackService.SaveFeedback(param);
            if (result != true)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
