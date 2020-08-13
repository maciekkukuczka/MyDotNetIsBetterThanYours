using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<List<Question>> GetAllWithObjectsAsync()
        {
            return await Db.Questions.Include(x => x.Answers)
                .ThenInclude(x => x.User).ToListAsync();
        }

        public async Task<string> AddAnswerToQuestion(Question question)
        {
            var exist = await Db.Questions.Include(x => x.Answers)
                .FirstOrDefaultAsync(x => x.IsActive && x.Id == question.Id);

            if (exist != null)
            {
                exist.Answers.Add(question.Answers.Last());

                // DbSet.Update(exist);
                // exist.Answers = question.Answers;
                await SaveAsync();
            }

            return exist.Id;
        }
    }

}