using Azure.Identity;
using FluentValidation;
using recipesv2.Models;
using recipesv2.ViewModels.Session;

namespace recipesv2.Validation.Session
{
    public class SignInValidation : AbstractValidator<SignInViewModel>
    {
        public SignInValidation()
        {
            // Username
            RuleFor(x => x.Username).NotEmpty().WithMessage("* required.");

            // Password
            RuleFor(x => x.Password).NotEmpty().WithMessage("* required.");
        }
    }
}