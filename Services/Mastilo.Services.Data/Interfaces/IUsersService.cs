namespace Mastilo.Services.Data.Interfaces
{
    using System.Linq;
    using Mastilo.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> All();

        User GetById(string id);
    }
}