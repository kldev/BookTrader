using Microsoft.AspNetCore.Mvc;

namespace BookTrader.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi=true)]
    public class HomeController
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return new RedirectResult("index.html");
        }
        
        [HttpGet("/Docs")]
        public ActionResult Docs()
        {
            return new RedirectResult("/swagger");
        }
    }
}