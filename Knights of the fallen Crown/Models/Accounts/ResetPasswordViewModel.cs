using System.ComponentModel.DataAnnotations;

namespace KnightsOfTheFallenCrown.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
    }
}
