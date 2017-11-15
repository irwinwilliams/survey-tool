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

            List<ReportViewModel> reports = new List<ReportViewModel>();

            ReportViewModel report = new ReportViewModel();
            report.QuestionOptionId = 74;
            report.Score = 2;
            report.Responses = 3;
            report.ScorePercentage = 30;

            reports.Add(report);

            ReportViewModel report2 = new ReportViewModel();
            report2.QuestionOptionId = 75;
            report2.Score = 2;
            report2.Responses = 3;
            report2.ScorePercentage = 30;

            reports.Add(report2);

            ViewBag.Reports = reports;

            return View(survey);
        }
    }
}