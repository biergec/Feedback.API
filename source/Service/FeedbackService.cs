using Feedback.API.Data;
using Feedback.API.Model.Interface;
using Feedback.API.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Feedback.API.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly FeedbackContext feedbackContext;

        public FeedbackService(FeedbackContext feedbackContext)
        {
            this.feedbackContext = feedbackContext;
        }

        public async Task<bool> SaveFeedback(VmSaveFeedback param)
        {
            var applicationDetail = await feedbackContext.Applications.SingleOrDefaultAsync(x => x.Enabled && x.ApplicationPublicKey == param.ApplicationKey);

            Model.Database.Feedback feedbackModel = new Model.Database.Feedback();
            feedbackModel.DeviceKey = param.DeviceKey;
            feedbackModel.Message = param.Message.Trim();
            feedbackModel.ApplicationId = applicationDetail.Id;
            feedbackModel.DeviceKey = param.DeviceKey;

            await feedbackContext.Feedback.AddAsync(feedbackModel);
            var resultCount = await feedbackContext.SaveChangesAsync();

            return resultCount > 0;
        }
    }
}
