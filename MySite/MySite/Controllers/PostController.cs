using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySite.Models;
using System.Text.Encodings.Web;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MySite.Controllers
{
    [Route("api")]
    public class PostController : Controller
    {
        private readonly ApplicationContext context;

        public PostController(ApplicationContext context)
        {
            this.context = context;
        }

        [Route("allPosts")]
        [HttpGet]
        public async Task<IActionResult> AllPosts()
        {
            ViewBag.Comments = context.Comments.ToList();
            var posts = await context.Posts.ToListAsync();
            return View(posts);
        }

        [Route("newPost")]
        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [Route("newPost")]
        [HttpPost]
        public async Task<IActionResult> NewPost(Post post, IFormFile uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)uploadImage.Length);
                }

                post.Image = imageData;
            }

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();

            return Redirect("/Post/Index");
        }

        [Route("deletePost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Post dbPost = context.Posts.Where(post=>post.Id == id).FirstOrDefault();

            context.Posts.Remove(dbPost);
            await context.SaveChangesAsync();

            return Redirect("/api/allPosts");
        }

        [Route("editPost/{id}")]
        [HttpGet]
        public IActionResult EditPost(int id)
        {
            Post dbPost = context.Posts.Where(post => post.Id == id).FirstOrDefault();

            return View(dbPost);
        }

        [Route("editPost/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditPost(Post post, IFormFile uploadImage)
        {
            Post dbPost = context.Posts.Where(dpost => dpost.Id == post.Id).FirstOrDefault();
            dbPost.Title = post.Title;
            dbPost.Text = post.Text;
            dbPost.Date = post.Date;

            if (uploadImage != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)uploadImage.Length);
                }

                dbPost.Image = imageData;
            }

            context.Posts.Update(dbPost);
            await context.SaveChangesAsync();
            return Redirect("/api/allPosts");
        }

        [Route("viewPost/{id}")]
        [HttpGet]
        public async Task<IActionResult> ViewPost(int id)
        {
            Post dbPost = await context.Posts.FirstOrDefaultAsync(m => m.Id == id);

            dbPost.Comments = await context.Comments.Where(comment => comment.PostId == id).ToListAsync();

            return View(dbPost);
        }

        [Route("deleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var dbComment = await context.Comments.FirstAsync(comment => comment.Id == id);
            var dbComments = await context.Comments.Where(comment => comment.ParentCommentId == id).ToListAsync();

            int postId = dbComment.PostId;

            if (dbComments.Count() != 0)
            {

                context.Comments.RemoveRange(dbComments);
            }

            context.Comments.Remove(dbComment);

            await context.SaveChangesAsync();
            return Redirect(String.Format("/api/viewPost/{0}#comments", postId));
        }

        [Route("getComments/{postId}")]
        [HttpGet]
        public async Task<PartialViewResult> GetComments(int postId)
        {
            var comments = await context.Comments.Where(comment => comment.PostId == postId).ToListAsync();
            comments = comments.Where(comment => comment.ParentCommentId == null).ToList();

            return PartialView(comments);
        }

        [Route("getComments")]
        [HttpPost]
        public async Task<PartialViewResult> GetComments(Comment comment)
        {
            if (comment.Nickname == null)
            {
                comment.Nickname = "Аноним";
            }

            comment.Date = DateTime.Now;

            await context.AddAsync(comment);
            await context.SaveChangesAsync();

            var comments = await context.Comments.Where(dbComment => dbComment.PostId == comment.PostId).ToListAsync();
            comments = comments.Where(comment => comment.ParentCommentId == null).ToList();

            return PartialView(comments);
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchPosts(string title)
        {
            var dbPosts = await context.Posts.Where(post => post.Title.Contains(title)).ToListAsync();
            dbPosts.ForEach(post => post.Comments = context.Comments.Where(comment => comment.PostId == post.Id).ToList());

            ViewBag.SearchTitle = title;

            return View(dbPosts);
        }


        [Route("searchPartial/{title}")]
        [HttpGet]
        public async Task<PartialViewResult> SearchPartial(string title)
        {
            if (title == string.Empty || title == null)
            {
                return PartialView();
            }

            var dbPosts = await context.Posts.Where(post => post.Title.Contains(title)).ToListAsync();

            return PartialView(dbPosts);
        }
    }
}
