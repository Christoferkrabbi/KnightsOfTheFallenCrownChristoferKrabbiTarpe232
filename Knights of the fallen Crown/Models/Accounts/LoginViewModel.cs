using System.ComponentModel.DataAnnotations;

namespace KnightsOfTheFallenCrown.Models.Accounts
{
    public class LoginViewMode
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [Display(Name)]
        public bool RememberMe {  get; set; }
        public string? ReturnUrl {  get; set; }
    }
}
