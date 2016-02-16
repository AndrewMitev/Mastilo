using Mastilo.Data;
using Mastilo.Data.Common;
using Mastilo.Data.Models;
using Mastilo.Services.Data;
using Mastilo.Web.Infrastructure.Mapping;
using Mastilo.Web.ViewModels.Jokes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mastilo.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IJokesService jokesService;

        public HomeController(IJokesService jokesService)
        {
            this.jokesService = jokesService;
        }

        public ActionResult Index()
        {
            var jokes = this.Cache.Get("jokes", () => jokesService.All().To<JokeViewModel>().ToList(), 3 * 60);
            return View(jokes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}