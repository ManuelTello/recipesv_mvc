using System.ComponentModel.DataAnnotations;

namespace recipesv2.ViewModels.Session
{
    public class SignInViewModel
    {
        [Display(Name = "Username")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Password")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Password { get; set; } = string.Empty;
    }
}
