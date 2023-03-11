using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Controllers;

namespace Dobany.Web.Public.Controllers
{
    public class HomeController : DobanyControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}