namespace Mastilo.Services.Data
{
    using Mastilo.Data.Common;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;
    using System.Linq;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable AllById(int id)
        {
            return this.comments.All()
                .Where(c => c.MasterpieceId == id)
                .OrderByDescending(c => c.CreatedOn);
        }

        public Comment AddComment(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.Save();

            return comment;
        }

        public int VoteComment(int commentId, string userId)
        {
            var comment = this.comments.GetById(commentId);

            int count = comment.Likes.Count;

            if (comment.Likes.Any(l => l.UserId == userId))
            {
                var likeToRemove = comment.Likes.FirstOrDefault(l => l.UserId == userId);
                comment.Likes.Remove(likeToRemove);
                this.comments.Save();

                return count - 1;
            }

            var like = new Like
            {
                UserId = userId
            };

            comment.Likes.Add(like);
            this.comments.Save();

            return count + 1;
        }
    }
}
