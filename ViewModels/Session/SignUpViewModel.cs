using System.ComponentModel.DataAnnotations;

namespace recipesv2.ViewModels.Session
{
    public class SignUpViewModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Username")]
        public String Username { get; set; } = String.Empty;

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Password")]
        public String Password { get; set; } = String.Empty;

        [Display(Name = "Confirm password")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public String ConfirmPassword { get; set; } = String.Empty;

        [Display(Name = "E-mail")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public String Email { get; set; } = String.Empty;

        [Display(Name = "Full name")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public String Name { get; set; } = String.Empty;

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public DateTime DateSignedUp { get; set; } = DateTime.Now;
    }
}
