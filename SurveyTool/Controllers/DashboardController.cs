using SurveyTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyTool.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard

        [Authorize]
        public ActionResult Index()
        {
            List<Survey> surveys = db.Surveys.ToList();

            return View(surveys);
        }
    }
}