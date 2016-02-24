namespace Mastilo.Web.Areas.Editor.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class MasterpiecesApproveModel : IMapFrom<Masterpiece>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title is too short!")]
        public string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Your creation is too short!")]
        public string Content { get; set; }

        public string AuthorUserName { get; set; }

        public bool Pending { get; set; }

        [Required]
        [MinLength(10, ErrorMessage ="Рецензията трябва да е поне 10 символа.")]
        [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string DisapprovedMessage { get; set; }

        public string Genre { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Masterpiece, MasterpiecesApproveModel>()
                .ForMember(x => x.Genre, opt => opt.MapFrom(y => y.Genre.Name))
                .ForMember(m => m.AuthorUserName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}