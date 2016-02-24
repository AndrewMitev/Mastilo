namespace Mastilo.Services.Data.Interfaces
{
    using Mastilo.Data.Models;
    using System.Linq;

    public interface IGenresService
    {
        IQueryable<Genre> All();

        Genre GetById(int id);
    }
}
