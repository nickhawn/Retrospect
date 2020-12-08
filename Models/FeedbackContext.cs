using Microsoft.EntityFrameworkCore;

namespace retrospect.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> FeedbackItem { get; set; }
    }
}