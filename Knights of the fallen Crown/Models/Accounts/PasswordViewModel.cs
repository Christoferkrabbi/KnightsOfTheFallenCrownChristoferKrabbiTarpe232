using System.ComponentModel.DataAnnotations;

namespace KnightsOfTheFallenCrown.Models.Accounts
{
    public class PasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type new password here")]
        public string NewPassword {  get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Type it again to confirm: ")]
        [Compare("NewPassword", ErrorMessage = "The new password and its confirmation do not match. please try agin")]
        public string ConfirmPassword {  get; set; }

    }
}
