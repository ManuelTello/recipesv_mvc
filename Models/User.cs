using System.ComponentModel.DataAnnotations;

namespace recipesv2.Models
{
    public class User
    {
        [Key]
        public int Id { get;set; }

        public string Username { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public DateTime DateSignedUp { get;set; }

        public DateTime DateOfBirth { get;set; }
    }
}
