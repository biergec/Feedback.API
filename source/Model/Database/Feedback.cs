using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.API.Model.Database
{
    [Table(nameof(Feedback))]
    public class Feedback : BaseModel
    {
        public string Message { get; set; }

        public long ApplicationId { get; set; }

        /// <summary>
        /// Device uniq number/code
        /// </summary>
        [Required]
        public string DeviceKey { get; set; }

        public Applications Application { get; set; }
    }
}
