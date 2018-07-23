using UmbracoTemplateProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Core;

namespace UmbracoTemplateProject.Web.Controllers
{
    public class BlogController : SurfaceController
    {
        public ActionResult Feed(int numberToDisplay, string category)
        {
            var blogArchive = Umbraco.TypedContentAtRoot().FirstOrDefault()?.Children("articulate")?.FirstOrDefault()?.Children("articulateArchive").FirstOrDefault();

            var blogModels = new List<BlogSnippetViewModel>();
            if (blogArchive != null)
            {
                var blogs = blogArchive.Children();

                if (!string.IsNullOrEmpty(category?.Trim()))
                {
                    blogs = blogs.Where(w => w.GetPropertyValue<string[]>("categories").InvariantContains(category));
                }

                blogs = blogs.OrderByDescending(c => c.GetPropertyValue<DateTime>("publishedDate")).Take(numberToDisplay);

                blogModels.AddRange(blogs.Select(s => new BlogSnippetViewModel
                {
                    Excerpt = s.GetPropertyValue<string>("excerpt"),
                    Title = s.Name,
                    Url = s.Url,
                    ImageUrl = s.GetCropUrl("postImage", "blogPost"),
                    Author = s.GetPropertyValue<string>("author"),
                    PublishedDate = s.GetPropertyValue<DateTime>("publishedDate"),
                    Tags = s.GetPropertyValue<string[]>("tags")?.ToList()
                }).ToList());
            }

            return PartialView("~/Views/Partials/_BlogPosts.cshtml", blogModels);
        }
    }
}