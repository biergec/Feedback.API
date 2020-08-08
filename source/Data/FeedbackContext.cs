using Microsoft.EntityFrameworkCore;

namespace Feedback.API.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {

        }

        public DbSet<Model.Database.Feedback> Feedback { get; set; }
        public DbSet<Model.Database.Applications> Applications { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Database.Feedback>().HasOne(x => x.Application).WithMany(x => x.Feedbacks).HasForeignKey(x => x.ApplicationId);
        }
    }
}