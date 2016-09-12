namespace Mastilo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;

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

        public IQueryable<Masterpiece> GetMasterpiecesByPageAndSort(string sortType, string sortDirection, string search, int page, int take)
        {
            IQueryable<Masterpiece> masterpieces = null;
            switch (sortType)
            {
                case "Date":
                    masterpieces = sortDirection == "ascending" ? this.masterpieces.All().OrderBy(x => x.CreatedOn) : this.masterpieces.All().OrderByDescending(x => x.CreatedOn);
                    break;
                case "Title":
                    masterpieces = sortDirection == "ascending" ? this.masterpieces.All().OrderBy(x => x.Title) : this.masterpieces.All().OrderByDescending(x => x.Title);
                    break;
                case "User":
                    masterpieces = sortDirection == "ascending" ? this.masterpieces.All().OrderBy(x => x.Author.UserName) : this.masterpieces.All().OrderByDescending(x => x.Author.UserName);
                    break;
                default:
                    masterpieces = this.masterpieces.All().OrderBy(x => x.CreatedOn);
                    break;
            }

            if (search == string.Empty || search == null)
            {
                masterpieces = masterpieces
                      .Skip((page - 1) * take)
                      .Take(take);
            }
            else
            {
                masterpieces = masterpieces
                    .Where(x => x.Title.Contains(search))
                    .Skip((page - 1) * take)
                    .Take(take);
            }

            return masterpieces;
        }

        public Masterpiece Create(string title, string content, string authorId, int genreId, ICollection<Category> categoriesNames)
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
                IsAssessed = false,
                IsApproved = false
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

        public IQueryable<Masterpiece> AllNotAssessed()
        {
            return this.masterpieces
                .All()
                .Where(m => m.IsApproved == false && m.IsAssessed == false);
        }

        public IQueryable<Masterpiece> AllPendingAssessed()
        {
            return this.masterpieces
                .All()
                .Where(m => m.IsAssessed == true && m.IsApproved == false);
        }

        public Masterpiece UpdatePendingStatus(int id, bool isApproved)
        {
            var masterpiece = this.masterpieces.GetById(id);
            masterpiece.IsApproved = isApproved;
            masterpiece.IsAssessed = true;

            this.masterpieces.Save();

            return masterpiece;
        }

        public Masterpiece AddDisapprovedMessage(int id, string message)
        {
            var masterpiece = this.masterpieces.GetById(id);
            masterpiece.IsAssessed = true;
            masterpiece.IsAssessed = true;
            masterpiece.DisapprovedMessage = message;

            this.masterpieces.Save();

            return masterpiece;
        }

        public void IncreaseViewCount(int id)
        {
            var masterpiece = this.masterpieces.GetById(id);
            masterpiece.ViewCount += 1;
            this.masterpieces.Save();
        }
    }
}
