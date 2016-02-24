namespace Mastilo.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Това поле е задължително!")]
        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}