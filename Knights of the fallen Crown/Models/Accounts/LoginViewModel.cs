using Google.Apis.Admin.Directory.directory_v1.Data;
using System.ComponentModel.DataAnnotations;

namespace KnightsOfTheFallenCrown.Models.Accounts
{
    public class LoginViewModel
    {
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Remember this account? ")]
		public bool RememberMe { get; set; }
		public string? ReturnURL { get; set; }
	}
}
