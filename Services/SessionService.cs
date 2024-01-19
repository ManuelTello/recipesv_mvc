using FluentValidation.Results;
using recipesv2.Data;
using recipesv2.Helpers;
using recipesv2.Interfaces.Services;
using recipesv2.Models;
using recipesv2.Repositories;
using recipesv2.Validation.Session;
using recipesv2.ViewModels.Session;

namespace recipesv2.Services
{
    public class SessionService : ISessionService
    {
        private readonly SessionRespository Repository;

        public SessionService(DataContext context)
        {
            this.Repository = new SessionRespository(context);
        }

        public async Task<ValidationCompleted> SaveNewUserToDatabase(SignUpViewModel model)
        {
            // Validation process, creates the validator, validates it and if any error is present it
            // will be added.
            SignUpValidation validator = new SignUpValidation(model);
            ValidationResult result = validator.Validate(model);
            ValidationCompleted validation = new ValidationCompleted();

            if (result.Errors.Count > 0)
            {
                foreach (var error in result.Errors)
                {
                    validation.Errors.Add(new KeyValuePair<string, string>(error.PropertyName, error.ErrorMessage));
                }
            }
            else
            {
                string password_hash = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password, 11);

                User newuser = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Name = model.Name,
                    Password = password_hash,
                    DateOfBirth = model.DateOfBirth,
                    DateSignedUp = model.DateSignedUp
                };

                await this.Repository.SaveUserToDatabase(newuser);
            }

            return validation;
        }

        public async Task<ValidationCompleted> SignInUser(SignInViewModel model)
        {
            User? user = await this.Repository.SearchUserByUsername(model.Username);

            // Validation process, creates the validator, validates it and if any error is present it
            // will be added.
            SignInValidation validator = new SignInValidation();
            ValidationResult result = validator.Validate(model);
            ValidationCompleted validation = new ValidationCompleted();

            foreach (var error in result.Errors)
            {
                validation.Errors.Add(new KeyValuePair<string, string>(error.PropertyName, error.ErrorMessage));
            }

            if (user == null || BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.Password) == false)
            {
                validation.Errors.Add(new KeyValuePair<string, string>("Username", "Username or password are wrong."));
            }

            return validation;
        }
    }
}
