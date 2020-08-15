using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Admin
{

    public class QuestionsComponentBase : OwningComponentBase

        // public class QuestionsComponentBase<T> : OwningComponentBase
    {
        private QuestionsService _service { get; set; }

        protected List<Question> Items;

        protected Question Item { get; set; }

        public bool IsModalOpen { get; set; }

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
                Item.Id = "0";
            }
            else
            {
                Item = item;
                await _service.EditAsync(Item);
            }

            await SaveAsync(Item);
        }


        protected async Task Delete(Question item)
        {
            await _service.DeleteAsync(item);
            Items = await _service.GetAllWithObjectsAsync();
        }


        protected async Task SaveAsync(Question item)
        {
            Item = item;
            IsModalOpen = false;

            if (item.Id == "0")
            {
                await _service.AddItemAsync(Item);
            }
            else
            {
                await _service.UpdateAsync(Item);
            }

            Items = await _service.GetAllWithObjectsAsync();
        }
    }

}