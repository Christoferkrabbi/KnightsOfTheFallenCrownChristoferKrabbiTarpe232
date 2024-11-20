using System.ComponentModel.DataAnnotations;

namespace KnightsOfTheFallenCrown.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pasword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "confirm your password by typing again: ")]
        [Compare("Password", ErrorMessage = "Password and its confirmation doesnt match type it again")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
