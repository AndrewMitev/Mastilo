using Mastilo.Data.Common;
using Mastilo.Data.Models;
using Mastilo.Services.Data.Interaces;
using Mastilo.Services.Web;
using System.Linq;

namespace Mastilo.Services.Data
{
    public class JokesService : IJokesService
    {
        private IDbRepository<Joke> jokes;
        private ICacheService Cache;

        public JokesService(IDbRepository<Joke> jokes, ICacheService Cache)
        {
            this.jokes = jokes;
            this.Cache = Cache;
        }

        public IQueryable<Joke> All()
        {
            return this.jokes.All();
        }
    }
}
