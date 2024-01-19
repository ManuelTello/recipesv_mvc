using Microsoft.AspNetCore.Mvc.ModelBinding;
using recipesv2.ViewModels.Session;
using recipesv2.Helpers;
using recipesv2.Models;

namespace recipesv2.Interfaces.Services
{
    public interface ISessionService
    {
        public Task<ValidationCompleted> SaveNewUserToDatabase(SignUpViewModel model);

        public Task<ValidationCompleted> SignInUser(SignInViewModel model);
    }
}
