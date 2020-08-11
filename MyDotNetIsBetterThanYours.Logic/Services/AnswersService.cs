using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services.Base;


namespace MyDotNetIsBetterThanYours.Logic.Services
{

    public class AnswersService : BaseRepository<Answer>
    {
        public AnswersService(AppDbContext db) : base(db)
        {
        }

        public override DbSet<Answer> DbSet => Db.Answers;
    }

}