using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyTool.Models;

namespace SurveyTool.Controllers
{
    public class QuestionOptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuestionOptions
        public async Task<ActionResult> Index()
        {
            var questionOptions = db.QuestionOptions.Include(q => q.Question);
            return View(await questionOptions.ToListAsync());
        }

        // GET: QuestionOptions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionOption questionOption = await db.QuestionOptions.FindAsync(id);
            if (questionOption == null)
            {
                return HttpNotFound();
            }
            return View(questionOption);
        }

        // GET: QuestionOptions/Create
        public ActionResult Create(int? id)
        {
            QuestionOption model = new QuestionOption();

            if (id.HasValue)
            {
                ViewBag.QuestionId = new SelectList(db.Questions.Where(w=> w.QuestionId.Equals(id.Value)), "QuestionId", "Title");
            }
            else
            {

                ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Title");
            }

            return View(model);
        }

        // POST: QuestionOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QuestionOptionId,QuestionId,Name,IsEnabled")] QuestionOption questionOption)
        {
            TryUpdateModel(questionOption);
            questionOption.ModifiedDate = DateTime.Now;
            questionOption.EntryDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.QuestionOptions.Add(questionOption);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Title", questionOption.QuestionId);
            return View(questionOption);
        }

        // GET: QuestionOptions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionOption questionOption = await db.QuestionOptions.FindAsync(id);
            if (questionOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Title", questionOption.QuestionId);
            return View(questionOption);
        }

        // POST: QuestionOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QuestionOptionId,QuestionId,Name,IsEnabled")] QuestionOption questionOption)
        {
            TryUpdateModel(questionOption);
            questionOption.ModifiedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(questionOption).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Title", questionOption.QuestionId);
            return View(questionOption);
        }

        // GET: QuestionOptions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionOption questionOption = await db.QuestionOptions.FindAsync(id);
            if (questionOption == null)
            {
                return HttpNotFound();
            }
            return View(questionOption);
        }

        // POST: QuestionOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuestionOption questionOption = await db.QuestionOptions.FindAsync(id);
            db.QuestionOptions.Remove(questionOption);
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
    }
}
