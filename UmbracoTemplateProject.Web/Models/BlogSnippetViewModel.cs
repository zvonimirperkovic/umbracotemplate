using System;
using System.Collections.Generic;

namespace UmbracoTemplateProject.Web.Models
{
    public class BlogSnippetViewModel
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}