using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Domain.Models;


namespace MyDotNetIsBetterThanYours.Data
{

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        // public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }
    }

}