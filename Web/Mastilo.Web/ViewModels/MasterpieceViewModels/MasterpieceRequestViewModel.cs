namespace Mastilo.Web.ViewModels.MasterpieceViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Mastilo.Web.ViewModels.CategoryViewModels;

    public class MasterpieceRequestViewModel
    {
        public MasterpieceRequestViewModel()
        {
            this.Categories = new HashSet<CategoriesViewModel>();
        }

        [Required(ErrorMessage = "Заглавието е задължително!")]
        [DisplayName("Заглавие")]
        [MinLength(3, ErrorMessage = "Заглавието е твърде кратко!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително!")]
        [DisplayName("Съдържание")]
        [MinLength(10, ErrorMessage = "Съдържанието е твърде кратко!")]
        [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        [DisplayName("Жанр")]
        public int GenreId { get; set; }

        public string AuthorId { get; set; }

        [DisplayName("Тагове")]
        [Required(ErrorMessage = "Задайте таг!")]
        public ICollection<CategoriesViewModel> Categories { get; set; }
    }
}