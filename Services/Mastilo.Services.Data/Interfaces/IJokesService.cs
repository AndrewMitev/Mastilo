using Mastilo.Data.Models;
using System.Linq;

namespace Mastilo.Services.Data.Interaces
{
    public interface IJokesService
    {
        IQueryable<Joke> All();
    }
}