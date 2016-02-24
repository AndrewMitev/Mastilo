namespace Mastilo.Services.Data
{
    using System.Linq;

    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;

    public class UsersService : IUsersService
    {
        private readonly IUserDbRepository<User> users;

        public UsersService(IUserDbRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> All()
        {
            return this.users
                .All()
                .Where(u => !u.Roles.Select(y => y.UserId).Contains(string.Empty));
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
