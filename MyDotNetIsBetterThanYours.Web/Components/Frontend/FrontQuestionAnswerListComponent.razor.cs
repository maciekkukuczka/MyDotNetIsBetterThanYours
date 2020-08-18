using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services;


namespace MyDotNetIsBetterThanYours.Web.Components.Frontend
{

    public class FrontQuestionAnswerListComponentBase : OwningComponentBase
    {
        private QuestionsService _service;
        private UsersService _userService;

        protected List<Question> Items;
        protected List<User> Users;

        protected Question Item;

        protected string AuthUser;

        protected bool IsModalOpen = false;
        protected bool IsCollapsed;
        private string DbOperationResult;
        private bool IsEdit;

        protected string AuthUserIdentityName;
        protected string AuthUserName;
        protected string AuthUserEmail;
        protected AppUser currentUser;

        // [Inject] private AuthenticationStateProvider _authenticationStateProvider { get; set; }
        [CascadingParameter] private Task<AuthenticationState> _authenticationState { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }


        protected async override Task OnInitializedAsync()
        {
            // return base.OnInitializedAsync();

            _service = (QuestionsService) ScopedServices.GetRequiredService(typeof(QuestionsService));
            _userService = (UsersService) ScopedServices.GetRequiredService(typeof(UsersService));


            if (Items == null)
            {
                // await InitQuestionData();
            }

            Items = await _service.GetAllWithObjectsAsync();
            Items = Items.OrderBy(question => question.CreatedDate).ToList();
            Users = await _userService.GetAllUsersWithAppUsersAsync();

            // Answers = await _answersService.GetAllAsync();
            // Users = await _usersService.GetAllAsync();

            // ModalIsOpen = false;

            // authenticationState=  _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = (await _authenticationState).User;
            AuthUserName = user.Identity.Name;

            if (user.Identity.IsAuthenticated)
            {
                currentUser = await UserManager.GetUserAsync(user);

                // AuthUserName = currentUser.UserName;
                // AuthUserEmail = currentUser.User.AppUserId;
            }
        }

        protected void CollapseAllCards()
        {
            IsCollapsed = false;

            // ModalIsOpen = false;
        }

        protected void AddEdit(Question item)
        {
            IsModalOpen = true;

            if (item == null)
            {
                Item = new Question();
                IsEdit = false;


                // Item.User = Users.FirstOrDefault(x => x.AppUserId == currentUser.Id);

                Item.User = currentUser.User;
                Item.User.AnwswersPoints += 1;
                Item.User.QuestionPoints += 2;
            }
            else
            {
                Item = item;
                IsEdit = true;
            }
        }


        protected async Task SaveAsync(Question question)
        {
            Item = question;
            IsModalOpen = false;

            await _service.AddItemAsync(question);
            Items = await _service.GetAllWithObjectsAsync();
            Items = Items.OrderBy(x => x.CreatedDate).ToList();
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