﻿using Mastilo.Data.Models;
using Mastilo.Services.Data.Interfaces;
using Mastilo.Web.Infrastructure.Mapping;
using Mastilo.Web.ViewModels.CommentViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Mastilo.Web.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public ActionResult AllById(int id = 1)
        {
            var comments = this.commentsService.AllById(id).To<CommentViewModel>().ToList();
            return this.PartialView("_CommentsSectionPartial", comments);
        }

        public ActionResult PostComment(CommentViewModel comment)
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: Handle error
            }

            var commentDatabase = this.Mapper.Map<Comment>(comment);
            this.commentsService.AddComment(commentDatabase);

            return this.RedirectToAction("AllById", new { id = comment.MasterpieceId });
        }

        public int VoteComment(int commentId)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var count = this.commentsService.VoteComment(commentId, currentUserId);

            return count;
        }
    }
}