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
    [Authorize(Roles ="Admin")]
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        public ActionResult Index()
        {
            List<Client> clients = new List<Client>();

            foreach (var item in db.Users.ToList())
            {
                Client client = new Client();
                client.ClientId = item.Id;
                client.UserName = item.UserName;
                client.Email = item.Email;
                client.PhoneNumber = item.PhoneNumber;

                clients.Add(client);
            }

            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Where(w => w.Id.Equals(id)).SingleOrDefault();

            if (user == null)
            {
                return HttpNotFound();
            }

            Client client = new Client();
            client.ClientId = user.Id;
            client.UserName = user.UserName;
            client.Email = user.Email;
            client.PhoneNumber = user.PhoneNumber;


            return View(client);
        }

        
        // GET: Clients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Where(w => w.Id.Equals(id)).SingleOrDefault();

            if (user == null)
            {
                return HttpNotFound();
            }

            Client client = new Client();
            client.ClientId = user.Id;
            client.UserName = user.UserName;
            client.Email = user.Email;
            client.PhoneNumber = user.PhoneNumber;

            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClientId,Email,PhoneNumber")] Client client)
        {
            var user = db.Users.Where(w => w.Id.Equals(client.ClientId)).SingleOrDefault();

            user.Email = client.Email;
            user.PhoneNumber = client.PhoneNumber;
            
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Where(w => w.Id.Equals(id)).SingleOrDefault();

            if (user == null)
            {
                return HttpNotFound();
            }

            Client client = new Client();
            client.ClientId = user.Id;
            client.UserName = user.UserName;
            client.Email = user.Email;
            client.PhoneNumber = user.PhoneNumber;

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var user = db.Users.Where(w => w.Id.Equals(id)).SingleOrDefault();

            db.Users.Remove(user);
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
