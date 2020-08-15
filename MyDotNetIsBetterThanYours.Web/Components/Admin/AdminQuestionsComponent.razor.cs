using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Admin
{

    public class AdminQuestionsComponentBase : OwningComponentBase

        // public class QuestionsComponentBase<T> : OwningComponentBase
    {
        private QuestionsService _service { get; set; }

        protected List<Question> Items;

        protected Question Item { get; set; }

        public bool IsModalOpen { get; set; }

        private string DbOperationResult;
        private bool IsEdit = false;

        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _service = (QuestionsService) ScopedServices.GetService(typeof(QuestionsService));
            Items = await _service.GetAllWithObjectsAsync();
        }


        protected async Task AddEditAsync(Question item)
        {
            IsModalOpen = true;


            if (item == null)
            {
                Item = new Question();
                IsEdit = false;
            }
            else
            {
                Item = item;
                IsEdit = true;
            }
        }


        protected async Task Delete(Question item)
        {
            await _service.DeleteAsync(item);
            Items.Clear();
            Items = await _service.GetAllWithObjectsAsync();
        }


        protected async Task SaveAsync(Question item)
        {
            Item = item;
            CloseModal();

            if (IsEdit)
            {
                DbOperationResult = await _service.UpdateAsync(Item);
            }
            else
            {
                DbOperationResult = await _service.AddItemAsync(Item);
            }

            Items = await _service.GetAllWithObjectsAsync();
        }


        protected void CloseModal()
        {
            IsModalOpen = false;

            // StateHasChanged();
        }
    }

}