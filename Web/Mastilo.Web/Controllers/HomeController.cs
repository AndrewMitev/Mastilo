using Mastilo.Data;
using Mastilo.Data.Common;
using Mastilo.Data.Models;
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
    public class HomeController : Controller
    {
        private IDbRepository<Joke> jokes;

        public HomeController(IDbRepository<Joke> jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult Index()
        {
            return View(jokes.All().To<JokeViewModel>().ToList());
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