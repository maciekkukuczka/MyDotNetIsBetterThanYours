﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class FrontAcordionComponentBase : OwningComponentBase
    {
        protected bool ModalIsOpen = false;


        [Parameter] public bool Collapse { get; set; } = false;
        [Parameter] public Question Item { get; set; }

        protected QuestionsService _questionsService;
        protected List<Question> Items = new List<Question>();

        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _questionsService = (QuestionsService) ScopedServices.GetService(typeof(QuestionsService));

            // ModalIsOpen = false;
        }

        protected void ChangeCollapse()
        {
            Collapse = !Collapse;

            // ModalIsOpen = false;
        }

        protected void Add()
        {
            Item.User = new User();
            ModalIsOpen = true;
        }


        protected async Task SaveAsync(Question question)
        {
            Item = question;
            ModalIsOpen = false;
            Collapse = true;


            var result = await _questionsService.AddAnswerToQuestion(question);

            if (result != null)
            {
                Items = await _questionsService.GetAllWithObjectsAsync();
            }
        }
    }

}