namespace Mastilo.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Това поле е задължително!")]
        [EmailAddress]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Възраст")]
        public int Age { get; set; }

        [Display(Name = "Населено място")]
        public string HomeTown { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Това поле е задължително!")]
        [StringLength(100, ErrorMessage = "{0} - трябва да е поне {2} символа.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди Парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}