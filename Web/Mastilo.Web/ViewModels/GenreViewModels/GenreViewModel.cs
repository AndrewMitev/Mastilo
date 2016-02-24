namespace Mastilo.Web.ViewModels.GenreViewModels
{
    using CategoryViewModels;
    using MasterpieceViewModels;
    using Mastilo.Data.Models;
    using Mastilo.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GenreViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "A tag should be at least 3 symbols.")]
        public string Name { get; set; }

        public ICollection<CategoriesViewModel> Categories { get; set; }
    }
}