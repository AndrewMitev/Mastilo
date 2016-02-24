namespace Mastilo.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Mastilo.Services.Data.Interfaces;
    using ViewModels.MasterpieceViewModels;
    using ViewModels.UserViewModels;

    public class UserController : BaseController
    {
        private readonly int itemsPerPage = 10;

        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index(string id, int pageTemp)
        {
            var user = this.usersService.GetById(id);
            var userModel = this.Mapper.Map<UserResponseViewModel>(user);

            var page = pageTemp;
            var postsNumber = userModel.Masterpieces.Count();
            var totalPages = (int)Math.Ceiling(postsNumber / (decimal)this.itemsPerPage);

            var pieces = new PagableMasterpieces
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Masterpieces = userModel.Masterpieces
            };

            var data = new UserAndMasterpiecesViewModel
            {
                UserResponse = userModel,
                Masterpieces = pieces
            };

            return this.View(data);
        }
    }
}