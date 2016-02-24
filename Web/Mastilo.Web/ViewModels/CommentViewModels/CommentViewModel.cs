namespace Mastilo.Web.ViewModels.CommentViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using LikeViewModels;

    public class CommentViewModel : IMapFrom<Comment>, IMapTo<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int? MasterpieceId { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<LikeViewModel> Likes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.AuthorName, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}