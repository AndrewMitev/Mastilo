namespace Mastilo.Web.ViewModels.MasterpieceViewModels
{
    using Infrastructure.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using CommentViewModels;
    using CategoryViewModels;
    using Services.Web;

    public class MasterpieceResponseViewModel : IMapFrom<Masterpiece>, IHaveCustomMappings
    {
        private ISanitizer sanitizer;

        public MasterpieceResponseViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
            this.Categories = new HashSet<CategoriesViewModel>();
            this.Comments = new HashSet<CommentViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Заглавието е прекалено кратко!")]
        public string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Текстът е твърде кратък!")]
        public string Content { get; set; }

        public string SanitizedContent {
            get
            {
                return this.sanitizer.Sanitize(this.Content);
            }
        }

        public string Genre { get; set; }

        public string AuthorUserName { get; set; }

        public string AuthorFirstName { get; set; }

        public string SanitizedDisapprovedMessage
        {
            get
            {
                return this.sanitizer.Sanitize(this.DisapprovedMessage);
            }
        }

        public string DisapprovedMessage { get; set; }

        public bool Pending { get; set; }

        public bool IsAssessed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public ICollection<CategoriesViewModel> Categories { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        //TODO: Add rest data!

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Masterpiece, MasterpieceResponseViewModel>()
                .ForMember(m => m.Genre, opt => opt.MapFrom(x => x.Genre.Name))
                .ForMember(m => m.AuthorUserName, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m => m.AuthorFirstName, opt => opt.MapFrom(x => x.Author.FirstName));
        }
    }
}