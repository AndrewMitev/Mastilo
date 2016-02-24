namespace Mastilo.Services.Data.Interfaces
{
    using System.Linq;
    using Mastilo.Data.Models;

    public interface IGenresService
    {
        IQueryable<Genre> All();

        Genre GetById(int id);
    }
}
