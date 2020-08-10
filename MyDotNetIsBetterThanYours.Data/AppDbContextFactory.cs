using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyDotNetIsBetterThanYours.Data;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=MyDotNetIsBetterThanYours;Trusted_Connection=True;");

            return new AppDbContext(optionBuilder.Options);
        }
    }

}