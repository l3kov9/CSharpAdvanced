namespace AjaxMVCDemos.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AjaxMVCDemos.Models;

    public class BooksController : Controller
    {
        public const string QuotesUrl = @"http://nvp-playground.azurewebsites.net/api/quotes/random/txt";

        public ActionResult Index()
        {
            var data = BooksData
                .GetAll()
                .AsQueryable()
                .Select(BookViewModel.FromBook)
                .ToList();

            return this.View(data);
        }

        public ActionResult Search(string query)
        {
            var result = BooksData
                .GetAll()
                .AsQueryable()
                .Where(book => book.Title.ToLower().Contains(query.ToLower()))
                .Select(BookViewModel.FromBook)
                .ToList();

            return this.PartialView("_BookResult", result);
        }

        public ActionResult ContentById(int id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var book = BooksData.GetAll().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Book not found");
            }

            return this.Content(book.Content);
        }

        public ActionResult All()
        {
            return this.View();
        }

        public JsonResult AllBooks()
        {
            var books = BooksData.GetAll()
                .AsQueryable().Select(TitledBookViewModel.FromBook);

            var client = new WebClient();
            var quoteAsText = client.DownloadString(QuotesUrl);

            var quoteLines = quoteAsText.Split(new[] { Environment.NewLine },StringSplitOptions.None);

            var quote = new Quote()
            {
                Text = quoteLines[0].Replace('’','*'),
                Author = quoteLines[1]
            };

            return this.Json(quote, JsonRequestBehavior.AllowGet);
        }
    }

    public class Quote
    {
        public string Text { get; set; }

        public string Author { get; set; }
    }
}