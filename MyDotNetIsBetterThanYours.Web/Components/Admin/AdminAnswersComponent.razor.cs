using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Admin
{

    public class AdminAnswersComponentBase : OwningComponentBase

        // public class QuestionsComponentBase<T> : OwningComponentBase where T:Answer 
    {
        private string DbOperationResult;
        protected bool IsCollapsed;
        private bool IsEdit;


        protected List<Answer> Items;
        private AnswersService _service { get; set; }
        protected Answer Item { get; set; }

        public bool IsModalOpen { get; set; }


        protected override async Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _service = (AnswersService) ScopedServices.GetService(typeof(AnswersService));
            Items = await _service.GetAllAsync();
        }


        public async Task AddEditAsync(Answer item)
        {
            IsModalOpen = true;

            if (item == null)
            {
                Item = new Answer();
                IsEdit = false;
            }
            else
            {
                Item = item;
                IsEdit = true;
            }
        }


        protected async Task Delete(Answer item)
        {
            await _service.DeleteAsync(item);
            Items.Clear();
            Items = await _service.GetAllAsync();
        }


        public async Task SaveAsync(Answer item)
        {
            Item = item;
            CloseModal();

            if (IsEdit)
                DbOperationResult = await _service.UpdateAsync(Item);
            else
                DbOperationResult = await _service.AddItemAsync(Item);

            Items = await _service.GetAllAsync();
        }


        protected void CloseModal()
        {
            IsModalOpen = false;
        }


        // public void ChangeCollapse()
        // {
        //     IsCollapsed = !IsCollapsed;
        // }
    }

}