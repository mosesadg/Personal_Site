using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;


namespace TestApp.Controllers
{
    
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        //[AllowAnonymous]
        public ActionResult Index(int? page, string searchString)
        {
            //return View(db.Posts.OrderByDescending(p => p.Created).Take(3).ToList());
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(post.ToPagedList(pageNumber, pageSize));
            //var model = db.Posts.ToPagedList();

            var posts = from p in db.Posts
                           select p;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                posts = db.Posts.Where(p => p.Title.Contains(searchString) || p.Body.Contains(searchString) || p.Comments.Any(c => c.Body.Contains(searchString) ||c.Author.DisplayName.Contains(searchString)));

                return View(posts.OrderByDescending(p => p.Created).ToPagedList(page ?? 1, 10));
            }
            else
            {
                return View(db.Posts.OrderByDescending(p => p.Created).ToPagedList(page ?? 1, 3));
            }
            
                        

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View(db.Posts.ToList());
        }

        public ActionResult Moderator()
        {
            return View(db.Comments.ToList());
        }

       /* // GET: Posts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }*/


        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p=>p.Slug == Slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }



        [Authorize(Roles = "Admin")]
        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Created,Body,Title,Published")] Post post, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var Slug = StringUtilities.URLFriendly(post.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(post);
                }
                if (db.Posts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(post);
                }
                else
                {
                    post.Created = System.DateTimeOffset.Now;
                    post.Slug = Slug;

                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
       // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Updated,Title,Body,MediaURL,Slug")] Post post)
        {
            if (ModelState.IsValid)
            {

                //New Code
                db.Posts.Attach(post);
                post.Updated = System.DateTimeOffset.Now;

                db.Entry(post).Property(p => p.Body).IsModified = true;
                db.Entry(post).Property(p => p.Title).IsModified = true;
                db.Entry(post).Property(p => p.Updated).IsModified = true;

                // Existing code
                //db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                db.Entry(post).Property(p => p.Body).IsModified = true;

            }
            return View(post);
        }
        [Authorize(Roles = "Admin")]
        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Authorize(Roles = "Admin")]
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "PostID, Body")] Comment comment, string slug)
        {
            if (ModelState.IsValid)
            {

                comment.AuthorID = User.Identity.GetUserId();
                comment.Created = System.DateTimeOffset.Now;

                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", new { slug = slug });
                
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
      [Authorize(Roles = "Admin, Moderator")]
        // GET: Posts/Delete/5
        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        
        //Post delete
        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id, string slug)
        {

            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", new { slug = slug });
            
        }



        // GET: Posts/Edit/5
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        [Authorize(Roles = "Admin, Moderator")]
        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment([Bind(Include = "Id,PostID, Body")] Comment comment)
        {
            if (ModelState.IsValid)
            {

                //New Code
                db.Comments.Attach(comment);
                comment.Updated = System.DateTimeOffset.Now;

                db.Entry(comment).Property(c => c.Body).IsModified = true;
                db.Entry(comment).Property(c => c.Updated).IsModified = true;

                // Existing code
                //db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                db.Entry(comment).Property(c => c.Body).IsModified = true;

            }
            return View(comment);
        }

      


        //[HttpPost]
        //    [ValidateAntiForgeryToken ]
        //    public ActionResult CreatePhoto (Post post, HttpPostedFileBase image)
        //    {
        //        if (image!=null && image.ContentLength >0)
        //        {
        //            //check the file to make sure
        //            //it's an image type
        //            var ext = Path.GetExtention(image.FileName);
        //            if (ext != ".png" && ext != ".jpg")
        //                //Otherwise throw an error
        //                ModelState.AddModelError("Image", "Invalid format.");
        //         }
                
        //        if(ModelState.IsValid)
        //        {
        //            var Slug = StringUtilities.URLFriendly(post.Title);
        //            if (String.IsNullOrWhiteSpace(Slug))
        //            {
        //                ModelState.AddModelError("Title", "Invalid title.");
        //                return View(post);
        //             }
        //            if(db.Posts.Any(p=>p.Slug ==Slug))
        //            {
        //                ModelState.AddModelError("Title", "The title must be unique.");
        //                return View(post);
        //             }
        //            else
        //            {
        //                //relative server path 
        //                var filePath = "/Uploads/blog/images/";
        //                //path on physical drive on server
        //                var absPath = Server.MapPath("~" + filePath);
        //                //media url for reative 
        //                post.MediaURL = filePath + image.FileName;
        //                //Save image
        //                image.SaveAs(Path.Combine(absPath, image.FileName));

        //                post.Created = System.DateTimeOffset.Now;
        //                post.Slug = Slug;

        //                db.Posts.Add(post);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");

        //            }


        //            return View(post);

        //        }

                           
        //    }
    
    }


    


}
