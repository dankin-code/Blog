using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Blog.Models;
using Blog.Utils;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public async Task<ActionResult> Index()
        {
            return View(await db.Posts.ToListAsync());
        }

        //Get with search string
        public ActionResult Index(string searchStr, int? page, int? size, int? count)
        {
            //Query finds all posts where the search string "searchStr"
            var result = db.Posts.Where(p => p.PostTitle.Contains(searchStr) || p.PostContent.Contains(searchStr));
            //return RedirectToAction("Index", new { posts = result, page, size, count }); this line can be used after addding paging
            return View(result);
        }


        // GET: Posts/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //public async Task<ActionResult> Create([Bind(Include = "Id,PostCreationDate,PostTitle,PostContent,Published,AuthorId")] Post post)
                public async Task<ActionResult> Create([Bind(Include = "Id,PostCreationDate,PostTitle,PostContent,MediaUrl,Published,AuthorId")] Post post, HttpPostedFileBase MediaUrl)

        {
            if (ModelState.IsValid)
            {
                post.PostCreationDate = new DateTimeOffset(DateTime.Now);
                post.AuthorId = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;

                //upload image file
                post.MediaUrl = FileUpload.UploadFile(MediaUrl);


                //HttpPostedFileBase MediaUrl = Request.Files["MediaUrl"];
                //if (MediaUrl != null && MediaUrl.ContentLength > 0)
                //{
                //    string MediaName = System.IO.Path.GetFileName(MediaUrl.FileName);
                //    string physicalPath = Server.MapPath("~/images/" + MediaName);
                //    MediaUrl.SaveAs(physicalPath);
                //}

                db.Posts.Add(post);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PostCreationDate,PostTitle,PostContent,MediaUrl,Published,AuthorId,PostUpdateDate,PostUpdateReason,EditorId")] Post post, HttpPostedFileBase MediaUrl)
        {
            if (ModelState.IsValid)
            {
                // Delete old file

                FileUpload.DeleteFile(post.MediaUrl);
                // Upload our file

                post.MediaUrl = FileUpload.UploadFile(MediaUrl);

                post.PostUpdateDate = new DateTimeOffset(DateTime.Now);
                post.EditorId = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
                db.Entry(post).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            
            // Delete old image file
            FileUpload.DeleteFile(post.MediaUrl);

            db.Posts.Remove(post);
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
