namespace Mastilo.Services.Data.Interfaces
{
    using System.Linq;
    using Mastilo.Data.Models;

    public interface ICommentsService
    {
        IQueryable AllById(int id);

        Comment AddComment(Comment comment);

        int VoteComment(int commentId, string userId);
    }
}
