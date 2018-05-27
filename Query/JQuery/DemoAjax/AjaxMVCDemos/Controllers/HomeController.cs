namespace AjaxMVCDemos.Controllers
{
    using AjaxMVCDemos.Models;
    using System;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public const string QuotesUrl = @"http://nvp-playground.azurewebsites.net/api/quotes/random/txt";

        public ActionResult Index()
        {
            return this.View();
        }

        [ChildActionOnly]
        public ActionResult ServerTime()
        {
            //var isAjax = Request.IsAjaxRequest();
            
            
            Thread.Sleep(2000);
            return this.Content(  " " + DateTime.Now.ToLongTimeString());
        }

        public ActionResult JQueryAjax()
        {
            return this.View();
        }

        public ActionResult AjaxActionLink()
        {
            return this.View();
        }

        public ActionResult Quote()
        {
            return View();
        }

        public ActionResult GetQuote()
        {
            Thread.Sleep(2000);

            var client = new WebClient();
            var quoteAsText = client.DownloadString(QuotesUrl);

            var quoteLines = quoteAsText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var quote = new RndQuote()
            {
                Text = quoteLines[0].Replace('’', '*'),
                Author = quoteLines[1]
            };

            return this.Content(quote.Text + "<br/>" + quote.Author);
        }
        public JsonResult AllBooks()
        {
            var books = BooksData.GetAll()
                .AsQueryable().Select(TitledBookViewModel.FromBook);

            var client = new WebClient();
            var quoteAsText = client.DownloadString("http://nvp-playground.azurewebsites.net/api/quotes/random/txt");

            var quoteLines = quoteAsText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var quote = new Quote()
            {
                Text = quoteLines[0],
                Author = quoteLines[1]
            };

            return this.Json(quote, JsonRequestBehavior.AllowGet);
        }
    }
    public class RndQuote
    {
        public string Text { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return string.Format("“{0}“, by {1}", this.Text, this.Author);
        }
    }
}
