namespace Mastilo.Services.Data.Interfaces
{
    using Mastilo.Data.Models;
    using System.Linq;

    public interface ICommentsService
    {
        IQueryable AllById(int id);

        Comment AddComment(Comment comment);

        int VoteComment(int commentId, string userId);
    }
}
