namespace Mastilo.Services.Data
{
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class MasterpiecesService : IMasterpiecesService
    {
        private readonly IDbRepository<Masterpiece> masterpieces;
        private readonly IDbRepository<Category> categories;

        public MasterpiecesService(IDbRepository<Masterpiece> masterpieces, IDbRepository<Category> categories)
        {
            this.masterpieces = masterpieces;
            this.categories = categories;
        }

        public IQueryable AllSortedByDate()
        {
            return this.masterpieces
                .All()
                .OrderByDescending(m => m.CreatedOn);
        }

        public Masterpiece Create(string title, string content, string authorId, int genreId, ICollection<Category>categoriesNames)
        {
            var categoriesToAdd = new HashSet<Category>();

            foreach (var category in categoriesNames)
            {
                var categoryToAdd = this.categories
                                            .All()
                                            .FirstOrDefault(x => x.Name == category.Name);
                if (categoryToAdd.GenreId == genreId)
                {
                    categoriesToAdd.Add(categoryToAdd);
                }
            }

            var masterpiece = new Masterpiece
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
                GenreId = genreId,
                Pending = true
            };

            this.masterpieces.Add(masterpiece);

            this.masterpieces.Save();

            return masterpiece;
        }

        public IQueryable GetMasterpiecesByPage(string userId, int page, int take)
        {
            return this.masterpieces
                .All()
                .Where(m => m.AuthorId == userId)
                .OrderBy(m => m.CreatedOn)
                .Skip((page - 1) * take)
                .Take(take);
        }

        public int Count()
        {
            return this.masterpieces.All().Count();
        }

        public Masterpiece GetMasterpieceById(int id)
        {
            return this.masterpieces.GetById(id);
        }

        public IQueryable<Masterpiece> AllPendingNotAssessed()
        {
            return this.masterpieces
                .All()
                .Where(m => m.Pending == true && m.IsAssessed == false);
        }

        public IQueryable<Masterpiece> AllPendingAssessed()
        {
            return this.masterpieces
                .All()
                .Where(m => m.Pending == true && m.IsAssessed == true);
        }

        public Masterpiece UpdatePendingStatus(int id, bool pendingStatus)
        {
            var masterpiece = this.masterpieces.GetById(id);
            masterpiece.Pending = pendingStatus;

            this.masterpieces.Save();

            return masterpiece;
        }

        public Masterpiece AddDisapprovedMessage(int id, string message)
        {
            var masterpiece = this.masterpieces.GetById(id);
            masterpiece.Pending = true;
            masterpiece.IsAssessed = true;
            masterpiece.DisapprovedMessage = message;

            this.masterpieces.Save();

            return masterpiece;
        }
    }
}
