using Feedback.API.Model.ViewModel;
using System.Threading.Tasks;

namespace Feedback.API.Model.Interface
{
    public interface IFeedbackService
    {
        Task<bool> SaveFeedback(VmSaveFeedback param);
    }
}
