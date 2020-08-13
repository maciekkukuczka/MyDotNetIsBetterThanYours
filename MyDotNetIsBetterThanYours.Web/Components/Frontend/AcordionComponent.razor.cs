using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class AcordionComponentBase : OwningComponentBase
    {
        protected bool ModalIsOpen = false;


        [Parameter] public bool Collapse { get; set; } = false;
        [Parameter] public Question Question { get; set; }

        protected QuestionsService _questionsService;
        protected List<Question> Questions = new List<Question>();

        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _questionsService = (QuestionsService) ScopedServices.GetService(typeof(QuestionsService));
        }

        protected void ChangeCollapse()
        {
            Collapse = !Collapse;
        }

        protected void Add()
        {
            Question.User = new User();
            ModalIsOpen = true;
        }


        protected async Task SaveAsync(Question question)
        {
            Question = question;
            ModalIsOpen = false;

            var result = await _questionsService.AddAnswerToQuestion(question);

            if (result != null)
            {
                Questions = await _questionsService.GetAllWithObjectsAsync();
            }
        }
    }

}