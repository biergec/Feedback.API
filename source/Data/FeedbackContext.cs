using Microsoft.EntityFrameworkCore;

namespace Feedback.API.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {

        }

        public DbSet<Model.Database.Feedback> Feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}