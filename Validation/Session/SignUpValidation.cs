using FluentValidation;
using recipesv2.ViewModels.Session;
using System.Data;
using System.Text.RegularExpressions;

namespace recipesv2.Validation.Session
{
    public class SignUpValidation : AbstractValidator<SignUpViewModel>
    {
        public SignUpValidation(SignUpViewModel model)
        {
            // Username 
            RuleFor(u => u.Username).NotEmpty().WithMessage("* required.");
            RuleFor(u => u.Username).MinimumLength(4).WithMessage("Username must be at least 4 characters long.");
            RuleFor(u => u.Username).Must(u => u != model.Username).WithMessage("Username is already taken.");

            // Password 
            RuleFor(u => u.Password).NotEmpty().WithMessage("* required.");
            RuleFor(u => u.Password).MinimumLength(4).WithMessage("Password must be at least 4 characters long.");
            RuleFor(u => u.Password).Must(x => !x.Contains(" ")).WithMessage("Password must not contain whitespaces.");
            RuleFor(u => u).Must(x => IsConfirmationPasswordCorrect(x.Password, x.ConfirmPassword)).WithMessage("Password and confirmation must be the same.").WithName("Password");

            // Password confirmation
            RuleFor(u => u.ConfirmPassword).NotEmpty().WithMessage("* required.");

            // E-mail
            RuleFor(u => u.Email).NotEmpty().WithMessage("* required");
            RuleFor(u => u.Email).Must(x => new Regex(@"\w*@\w*.").Count(x) > 0).WithMessage("Must be a valida e-mail adress.");
            RuleFor(u => u.Email).Must(x => x != model.Email).WithMessage("E-mail already in use.");

            // Name 
            RuleFor(u => u.Name).NotEmpty().WithMessage("* required");

            // Date of birth
            RuleFor(u => u.DateOfBirth).NotNull().WithMessage("* required.");
        }

        public bool IsConfirmationPasswordCorrect(string password, string confirmation)
        {
            return password == confirmation ? true : false;
        }
    }
}