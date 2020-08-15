using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class AdminCollapseCardComponentBase : OwningComponentBase
    {
        protected bool ModalIsOpen = false;


        [Parameter] public bool IsCollapsed { get; set; } = false;
        [Parameter] public Question Item { get; set; }
        [Parameter] public EventCallback OnClick { get; set; }

        // protected QuestionsService Service;
        // protected List<Question> Items = new List<Question>();

        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            // Service = (QuestionsService) ScopedServices.GetService(typeof(QuestionsService));

            // ModalIsOpen = false;
        }

        // protected void ChangeCollapse()
        // {
        //     IsCollapsed = !IsCollapsed;
        //
        //     // ModalIsOpen = false;
        // }
        //
        // protected void Add()
        // {
        //     Item.User = new User();
        //     ModalIsOpen = true;
        //     ChangeCollapse();
        // }
        //
        //
        // protected async Task SaveAsync(Question question)
        // {
        //     Item = question;
        //     ModalIsOpen = false;
        //
        //     var result = await Service.AddAnswerToQuestion(question);
        //
        //     if (result != null)
        //     {
        //         Items = await Service.GetAllWithObjectsAsync();
        //     }
        // }
    }

}