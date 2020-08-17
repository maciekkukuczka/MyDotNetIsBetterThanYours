using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;
using Xunit;


namespace MyDotNetIsBetterThenYours.Tests
{

    public class QuestionsServiceTest
    {
        private readonly AppDbContext db;

        private Answer answer1;
        private Answer answer2;
        private List<Answer> answersList;

        private Question question1;
        private Question question2;
        private List<Question> questions;


        public QuestionsServiceTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=MyDotNetIsBetterThanYours;Trusted_Connection=True;");
            db = new AppDbContext(optionBuilder.Options);


            #region InitData


            answer1 = new Answer()
            {
                Content = "odp1",
                Id = "1",
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
                Id = "2",
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
                Id = "1",
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
                Id = "2",
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
        public async Task GetAllWithObjectsAsyncTest()
        {
            //Arrange

            var mock = new Mock<QuestionsService>();
            mock.Setup(x => x.GetAllWithObjectsAsync().Result).Returns(questions);

            var service = new QuestionsService(db);


            //Act

            // var expected = mock;
            var expected = questions;

            var result = await service.GetAllWithObjectsAsync();


            //Assert
            // Assert.Equal(expected, result);
            result.Should().NotBeEmpty();
            result.Should().BeOfType(typeof(List<Question>));
            result.Should().BeSameAs(expected);
        }
    }

}