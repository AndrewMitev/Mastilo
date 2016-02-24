namespace Mastilo.Web.Areas.Administration.Models
{
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(u => u.Role, opt => opt.MapFrom(x => x.Roles.Any() ? "Editor" : "User"));
        }
    }
}