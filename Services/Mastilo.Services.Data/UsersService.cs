namespace Mastilo.Services.Data
{
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;
    using System.Linq;

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
                .Where(u => !u.Roles.Select(y => y.UserId).Contains(""));
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
