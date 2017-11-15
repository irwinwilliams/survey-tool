using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SurveyTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SurveyTool.Controllers
{
    [Authorize]
    public class ResponsesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Responses
        public ActionResult Create(int id)
        {
            Response response = new Response();
            response.Survey= db.Surveys.Find(id);
            response.SurveyId = response.Survey.SurveyId;

            return View(response);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            string questions = collection["question.QuestionId"];
            var QuestionIds= questions.Split(',');
            Guid guid = Guid.NewGuid();

            Response response = new Response();
            response.SurveyId= Int32.Parse(collection["SurveyId"]);
            response.CreatedBy = User.Identity.Name;
            db.Responses.Add(response);
            db.SaveChanges();

            foreach (var questionId in QuestionIds)
            {
                Answer answer = new Answer();
                answer.ResponseId = response.ResponseId;
                answer.QuestionId = Int32.Parse(questionId);
                answer.QuestionOptionId= Int32.Parse(collection[string.Format("questionOption[{0}]", questionId)]);
                answer.Remarks = collection[string.Format("Remarks[{0}]", questionId)];
                
                db.Answers.Add(answer);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult Index() {

            List<Response> responses = new List<Response>();

            if (isAdminUser())
            {
                responses=db.Responses.ToList();
            }
            else
            {
                responses = db.Responses.Where(w=> w.CreatedBy.Equals(User.Identity.Name)).ToList();
            }

            return View(responses);
        }

        public ActionResult Details(int? id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Response response = db.Responses
                                        .Include("Survey")
                                        .Include("Survey.Categories")
                                        .Include("Answers")
                                        .Where(w => w.ResponseId.Equals(id.Value))
                                        .SingleOrDefault();

            if (response == null)
            {
                return HttpNotFound();
            }
                
            return View(response);
        }

        // GET: Responses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = await db.Responses.FindAsync(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Response response = await db.Responses.FindAsync(id);
            db.Responses.Remove(response);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}