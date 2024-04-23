using Microsoft.AspNetCore.Mvc;

namespace EducationPortalWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
