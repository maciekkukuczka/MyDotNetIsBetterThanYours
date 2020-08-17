using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;
using Xunit;


namespace MyDotNetIsBetterThenYours.Tests
{

    public class AnswersServiceTest
    {
        private readonly AppDbContext db;

        private Answer answer1;
        private Answer answer2;
        private List<Answer> answersList;

        private Question question1;
        private Question question2;
        private List<Question> questions;


        public AnswersServiceTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=MyDotNetIsBetterThanYours;Trusted_Connection=True;");
            db = new AppDbContext(optionBuilder.Options);


            #region InitData


            answer1 = new Answer()
            {
                Content = "odp1",
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Today,
                Question = null,
                User = null,
                IsActive = true,
                CreatedById = 1,
                ModifiedById = 1,
                ModifiedDateTime = DateTime.Today
            };

            answer2 = new Answer()
            {
                Content = "odp2",
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Today,
                Question = null,
                User = null,
                IsActive = true,
                CreatedById = 1,
                ModifiedById = 1,
                ModifiedDateTime = DateTime.Today
            };

            answersList = new List<Answer>()
            {
                answer1, answer2
            };

            question1 = new Question()
            {
                Answers = answersList,
                Content = "pyt1",
                Id = Guid.NewGuid().ToString(),
                User = null,
                CreatedDate = DateTime.Today,
                IsActive = true,
                CreatedById = 1,
                ModifiedById = 1,
                ModifiedDateTime = DateTime.Today
            };

            question2 = new Question()
            {
                Answers = answersList,
                Content = "pyt2",
                Id = Guid.NewGuid().ToString(),
                User = null,
                CreatedDate = DateTime.Today,
                IsActive = true,
                CreatedById = 1,
                ModifiedById = 1,
                ModifiedDateTime = DateTime.Today
            };

            questions = new List<Question>();
            questions.Add(question1);
            questions.Add(question2);


            #endregion
        }


        [Fact]
        public async Task AddItemAsync()
        {
            //Arrange

            // var mock = new Mock<AnswersService>();
            // mock.Setup(x => x.AddItemAsync(answer1).Result).Returns(answer1.Id);

            var service = new AnswersService(db);


            //Act

            var expected = answer1.Id;
            var result = await service.AddItemAsync(answer1);

            //mock
            // var result = await service.AddItemAsync(answer1);


            //Assert
            Assert.Equal(expected, result);

            // result.Should().NotBeEmpty();
            // result.Should().BeOfType(typeof(Answer));
            // result.Should().BeSameAs(expected);
        }
    }

}