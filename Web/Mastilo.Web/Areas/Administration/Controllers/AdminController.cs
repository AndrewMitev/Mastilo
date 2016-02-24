namespace Mastilo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Mastilo.Data;
    using Mastilo.Data.Models;
    using Mastilo.Services.Data.Interfaces;
    using Mastilo.Web.Areas.Administration.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Authorize(Roles = "Administration")]
    public class AdminController : Controller
    {
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;

        public AdminController(IUsersService usersService)
        {
            this.usersService = usersService;
            this.userManager = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ShowChangeUser(string id)
        {
            var user = this.usersService.GetById(id);

            var model = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                Role = this.userManager.GetRoles(user.Id).FirstOrDefault()
            };

            return this.View("Index", model);
        }

        [HttpGet]
        public ActionResult LoadGrid()
        {
            var allUsers = this.usersService
                .All()
                .ToList();

            var projected = allUsers.Select(u => new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Age = u.Age,
                Role = this.userManager.GetRoles(u.Id).FirstOrDefault()
            }).ToList();

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = projected.Count,
                rows = (
                        from user in projected
                        select new
                        {
                            id = user.Id,
                            cell = new string[]
                            {
                                user.FirstName,
                                user.LastName,
                                user.UserName,
                                user.Age.ToString(),
                                user.Role
                            }
                        }).ToArray()
            };

            return this.Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeRole(string userId, string role)
        {
            var rolesForUser = this.userManager.GetRoles(userId).ToList();

            rolesForUser.ForEach(r => this.userManager.RemoveFromRole(userId, r));

            this.userManager.AddToRole(userId, role);

            return this.RedirectToAction("Index");
        }
    }
}