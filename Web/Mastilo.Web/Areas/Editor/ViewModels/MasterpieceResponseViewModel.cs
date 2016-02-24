namespace Mastilo.Web.Areas.Editor.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class MasterpieceResponseViewModel : IMapFrom<Masterpiece>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Заглавието е прекалено кратко!")]
        public string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Текстът е твърде кратък!")]
        public string Content { get; set; }

        public string Genre { get; set; }

        public string AuthorUserName { get; set; }

        public string AuthorFirstName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Masterpiece, MasterpieceResponseViewModel>()
                .ForMember(m => m.Genre, opt => opt.MapFrom(x => x.Genre.Name))
                .ForMember(m => m.AuthorUserName, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m => m.AuthorFirstName, opt => opt.MapFrom(x => x.Author.FirstName));
        }
    }
}