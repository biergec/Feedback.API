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
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Record active/inactive status
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool Enabled { get; set; }
    }
}
