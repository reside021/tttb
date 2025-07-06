using Microsoft.EntityFrameworkCore;
using tttb.Models;

namespace tttb.DB
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }   
    }
}
