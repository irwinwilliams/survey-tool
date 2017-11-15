using SurveyTool.DAC;
using SurveyTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyTool.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index() {
            
            return View(db.Surveys.ToList());
        }

        // GET: Reports
        public ActionResult Surveys(int id)
        {
            Survey survey =db.Surveys.Find(id);

            List<ReportViewModel> reports = new ReportDataHelper().Show(survey.SurveyId);

            ViewBag.Reports = reports;

            return View(survey);
        }
    }
}