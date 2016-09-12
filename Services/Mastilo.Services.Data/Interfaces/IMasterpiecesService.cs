namespace Mastilo.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Mastilo.Data.Models;

    public interface IMasterpiecesService
    {
        IQueryable AllSortedByDate();

        Masterpiece Create(string title, string content, string authorId, int genreId, ICollection<Category> categories);

        int Count();

        IQueryable GetMasterpiecesByPage(string userId, int page, int itemsPerPage);

        Masterpiece GetMasterpieceById(int id);

        IQueryable<Masterpiece> AllPendingAssessed();

        IQueryable<Masterpiece> AllPendingNotAssessed();

        Masterpiece UpdatePendingStatus(int id, bool pendingStatus);

        Masterpiece AddDisapprovedMessage(int id, string message);

        void IncreaseViewCount(int id);
    }
}
