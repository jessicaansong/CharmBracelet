using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Charm.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Charm.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        ////// GET //////////////


        public ActionResult Index(int? page, string Query)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var p = db.Posts.AsQueryable();
            if (!String.IsNullOrEmpty(Query))
            {
                p = db.Posts.Where(s => s.Title.Contains(Query) || s.Blog.Contains(Query));
            }
            return View(p.OrderByDescending(x => x.Created).ToPagedList(pageNumber, pageSize)); //This command tells it to extract the information from the database.
        }




        //================== DETAILS  ================================================//


        ////// GET //////////////
        public ActionResult Details(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.FirstOrDefault(p => p.Slug == slug);
            ViewBag.PostList = db.Posts.ToList();

            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);

        }



        //================== DETAILS ENDS ===========================================//



        //================== ADMIN ================================================//


        public ActionResult Admin()
        {
            return View(db.Posts.ToList()); //Must send your blog posts to a list, so that iEnumerable can accept it
        }


        //================== ADMIN ENDS ================================================//




        //================== CREATE ================================================//

        ////// GET //////////////
        [Authorize(Roles = ("Admin"))]
        public ActionResult Create()
        {

            return View();
        }



        //////   POST  /////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created,Updated,Title,Slug,Blog,MediaUrl")] BlogPost blogPost, HttpPostedFileBase image)
        {

            if (image != null && image.ContentLength > 0)
            {
                //check the file name to make sure its an image
                var ext = System.IO.Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != "gif " && ext != ".bmp" && ext != ".pdf")
                    ModelState.AddModelError("image", "Invalid Format");
            }

            if (ModelState.IsValid)
            {
                string slug = StringUtilities.UrlFriendly(blogPost.Title); //slug to automatically populate
                if (String.IsNullOrWhiteSpace(slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(blogPost);
                }
                if (db.Posts.Any(p => p.Slug == slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(blogPost);
                }
                else
                {

                    blogPost.Slug = slug;

                }
                if (image != null)
                {
                    //relative server path
                    var filePath = "/MyUploads/";
                    //path on physical drive on server
                    var absPath = Server.MapPath("~" + filePath);
                    // media url for relative path
                    blogPost.MediaUrl = filePath + "/" + image.FileName;
                    // save image
                    Directory.CreateDirectory(absPath);
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }

                blogPost.Created = System.DateTimeOffset.Now;
                db.Posts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }


        //================== CREATE ENDS  ===============================================//



        //================== EDIT  ===============================================//

        //======  GET ==========//

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }



        //////   POST  /////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Updated,Title,Slug,Blog,MediaUrl")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Updated = System.DateTimeOffset.Now;
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //================== EDIT ENDS===============================================/



        //================== DELETE ===============================================/

        //////   GET  /////////
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        //////   POST  /////////
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.Posts.Find(id);
            db.Posts.Remove(blogPost);
            db.SaveChanges();
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




        //================== DELETE ENDS===============================================//


        //================== COMMENT ============================================//

        //===CREATE COMMENT ============================================//


        //////////// P O S T /////////////

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateComment([Bind(Include ="PostId,Body")]
        //{
        //    var post = db.Posts.Find(comment.PostId);
        //    if (post == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        
        //    if (ModelState.IsValid)
        //    {
        //        comment.Created = DateTimeOffset.Now;
        //        comment.AuthorId = User.Identity.GetUserId();

        //        db.Comments.Add(comment);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Details", new { slug = post.Slug });
        //}

    
