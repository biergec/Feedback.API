using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.API.Model.Database
{
    [Table(nameof(Applications))]
    public class Applications : BaseModel
    {
        public string ApplicationName { get; set; }

        public string ApplicationPublicKey { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
