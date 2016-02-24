namespace Mastilo.Services.Data
{
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;
    using System.Linq;
    public class GenresService : IGenresService
    {
        private readonly IDbRepository<Genre> genres;

        public GenresService(IDbRepository<Genre> genres)
        {
            this.genres = genres;
        }

        public Genre GetById(int id)
        {
            return this.genres.GetById(id);
        }

        public IQueryable<Genre> All()
        {
            return this.genres.All();
        }
    }
}
