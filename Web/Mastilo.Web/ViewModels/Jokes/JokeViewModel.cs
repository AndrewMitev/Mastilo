namespace Mastilo.Web.ViewModels.Jokes
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class JokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public string Text { get; set; }

        public string All { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.All, opt => opt.MapFrom(x => x.Info + " " + x.Text));
        }
    }
}