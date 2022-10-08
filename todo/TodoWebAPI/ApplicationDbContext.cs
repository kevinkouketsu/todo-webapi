using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Entities;

namespace TodoWebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoItem>().Property((x) => x.Title).HasMaxLength(100);
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
