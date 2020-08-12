using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class AcordionComponentBase : ComponentBase
    {
        [Parameter] public bool Collapse { get; set; } = false;
        [Parameter] public Question Question { get; set; }

        // [Parameter] public List<Answer> Answers { get; set; }

        protected async override Task OnInitializedAsync()
        {
        }

        protected void ChangeCollapse()
        {
            Collapse = !Collapse;
        }
    }

}