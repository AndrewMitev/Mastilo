namespace Mastilo.Web.ViewModels.LikeViewModels
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LikeViewModel : IMapFrom<Like>, IHaveCustomMappings
    {
        public string LikeByUsername { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.LikeByUsername, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}