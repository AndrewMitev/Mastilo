namespace Mastilo.Web.ViewModels.UserViewModels
{
    using System.Collections.Generic;
    using Mastilo.Data.Models;
    using Mastilo.Web.Infrastructure.Mapping;

    public class UserResponseViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICollection<MasterpieceViewModels.MasterpieceResponseViewModel> Masterpieces { get; set; }

        public ICollection<CommentViewModels.CommentViewModel> Comments { get; set; }
    }
}