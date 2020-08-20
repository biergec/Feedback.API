using Feedback.API.Data;
using Feedback.API.Model.Interface;
using Feedback.API.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Feedback.API.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly FeedbackContext feedbackContext;
        private readonly IMyEmailSender myEmailSender;
        private readonly IConfiguration config;

        public FeedbackService(FeedbackContext feedbackContext, IMyEmailSender myEmailSender, IConfiguration config)
        {
            this.myEmailSender = myEmailSender;
            this.config = config;
            this.feedbackContext = feedbackContext;
        }

        public async Task<bool> SaveFeedback(VmSaveFeedback param)
        {
            var applicationDetail = await feedbackContext.Applications.FirstOrDefaultAsync(x => x.Enabled && x.ApplicationPublicKey == param.ApplicationKey);

            Model.Database.Feedback feedbackModel = new Model.Database.Feedback();
            feedbackModel.DeviceKey = param.DeviceKey;
            feedbackModel.Message = param.Message.Trim();
            feedbackModel.ApplicationId = applicationDetail.Id;
            feedbackModel.DeviceKey = param.DeviceKey;

            await feedbackContext.Feedback.AddAsync(feedbackModel);
            var resultCount = await feedbackContext.SaveChangesAsync();

            //Send Mail?
            if (resultCount > 0 && Convert.ToBoolean(config["NewFeedbackAfterSendMail"]))
            {
                await myEmailSender.SendEmailAsync(config["NewFeedbackAfterSendMailAdress"], "Feedback", $"Feedback Application : {applicationDetail.ApplicationName} | \n Message : {param.Message}");
            }

            return resultCount > 0;
        }
    }
}
