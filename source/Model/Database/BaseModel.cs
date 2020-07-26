using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedback.API.Model.Database
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// Created date
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Device uniq number/code
        /// </summary>
        [Required]
        public string DeviceKey { get; set; }
        /// <summary>
        /// Record active/inactive status
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool Enabled { get; set; }
    }
}
