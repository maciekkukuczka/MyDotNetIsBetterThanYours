using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services.Base;


namespace MyDotNetIsBetterThanYours.Logic.Services
{

    public class QuestionsService : BaseRepository<Question>
    {
        public QuestionsService(AppDbContext db) : base(db)
        {
        }

        public override DbSet<Question> DbSet => Db.Questions;
    }

}