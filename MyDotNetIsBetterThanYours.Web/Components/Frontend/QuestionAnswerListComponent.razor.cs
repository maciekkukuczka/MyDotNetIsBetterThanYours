using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class QuestionAnswerListComponentBase : OwningComponentBase
    {
        private QuestionsService _questionsService;

        // private AnswersService _answersService;
        // private UsersService _usersService;

        protected List<Question> Questions;

        // protected List<Answer> Answers;
        // protected List<User> Users;

        protected Question Question;

        protected bool Collapse;
        protected bool ModalIsOpen = false;


        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _questionsService = (QuestionsService) ScopedServices.GetRequiredService(typeof(QuestionsService));

            // _answersService = (AnswersService) ScopedServices.GetService(typeof(AnswersService));
            // _usersService = (UsersService) ScopedServices.GetService(typeof(UsersService));
            if (Questions == null)
            {
                // await InitQuestionData();
            }

            Questions = await _questionsService.GetAllWithObjectsAsync();

            // Answers = await _answersService.GetAllAsync();
            // Users = await _usersService.GetAllAsync();

            // ModalIsOpen = false;
        }

        protected void CollapseAllCards()
        {
            Collapse = false;

            // ModalIsOpen = false;
        }

        protected void Add()
        {
            Question = new Question();
            Question.User = new User();
            ModalIsOpen = true;
        }


        protected async Task SaveAsync(Question question)
        {
            Question = question;
            ModalIsOpen = false;

            await _questionsService.AddItemAsync(question);
            Questions = await _questionsService.GetAllWithObjectsAsync();
        }


        #region Initialize Questions List


        // private async Task InitQuestionData()
        // {
        //     var questions = new List<Question>
        //     {
        //         new Question
        //         {
        //             Content = "Co to jest 'Interface'",
        //             Answers = new List<Answer>
        //             {
        //                 new Answer
        //                 {
        //                     Content = "Interfejs to takie zło w c#...",
        //                     User = new User
        //                     {
        //                         AppUser.Email = "emasni@fdfd",
        //                         Points = 10
        //                     }
        //                 },
        //                 new Answer
        //                 {
        //                     Content = "A wcale nie bo to fajne jest!",
        //                     User = new User
        //                     {
        //                         Email = "emasni@fdfd",
        //                         Points = 10
        //                     }
        //                 }
        //             },
        //             User = new User {Email = "sas", Points = 10}
        //         },
        //         new Question
        //         {
        //             Content = "Jaką rolę pełni 'Klasa'",
        //             Answers = new List<Answer>
        //             {
        //                 new Answer
        //                 {
        //                     Content = "Klasa to takie cosik...",
        //                     User = new User
        //                     {
        //                         Email = "emasni@fdfd",
        //                         Points = 10
        //                     }
        //                 },
        //                 new Answer
        //                 {
        //                     Content = "Ja bym powiedział, że klasa to...",
        //                     User = new User
        //                     {
        //                         Email = "emasni@fdfd",
        //                         Points = 10
        //                     }
        //                 },
        //                 new Answer
        //                 {
        //                     Content = "eeee tam",
        //                     User = new User
        //                     {
        //                         Email = "emasni@fdfd",
        //                         Points = 10
        //                     }
        //                 }
        //             },
        //             User = new User {Email = "sas", Points = 10}
        //         }
        //     };
        //
        //     foreach (var item in questions)
        //     {
        //         var id = await _questionsService.AddItemAsync(item);
        //     }
        // }


        #endregion
    }

}