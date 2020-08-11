using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class QuestionAnswerListComponentBase : OwningComponentBase
    {
        private QuestionsService _questionsService;
        private AnswersService _answersService;
        private UsersService _usersService;

        protected List<Question> Questions;
        protected List<Answer> Answers;
        protected List<User> Users;


        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _questionsService = (QuestionsService) ScopedServices.GetService(typeof(QuestionsService));
            _answersService = (AnswersService) ScopedServices.GetService(typeof(AnswersService));
            _usersService = (UsersService) ScopedServices.GetService(typeof(UsersService));

            Questions = await _questionsService.GetAllAsync();
            Answers = await _answersService.GetAllAsync();
            Users = await _usersService.GetAllAsync();
        }
    }

}