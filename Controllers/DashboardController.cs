using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class DashboardController : Controller
    {
       public IActionResult Index()
{
    var user = HttpContext.Session.GetString("UserEmail");

    if (user == null)
    {
        return RedirectToAction("Login", "Account");
    }

    ViewBag.User = HttpContext.Session.GetString("UserName");

    return View();
}
    }
}