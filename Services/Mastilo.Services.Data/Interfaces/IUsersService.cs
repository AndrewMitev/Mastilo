namespace Mastilo.Services.Data.Interfaces
{
    using Mastilo.Data.Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> All();

        User GetById(string id);
    }
}