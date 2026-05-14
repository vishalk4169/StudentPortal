using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using System.Linq;

namespace StudentPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
public string Test()
{
    return "Account Controller Works";
}
        // REGISTER PAGE OPEN
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST METHOD
       [HttpPost]
public IActionResult Register(User user)
{
    var existingUser = _context.Users
        .FirstOrDefault(x => x.Email == user.Email);

    if (existingUser != null)
    {
        ViewBag.Message = "User already exists!";
        return View();
    }

    _context.Users.Add(user);
    _context.SaveChanges();

    ViewBag.Message = "Registration successful!";
    return View();
}

        // LOGIN PAGE OPEN
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST METHOD
        [HttpPost]
        public IActionResult Login(User user)
        {
            var validUser = _context.Users
                .FirstOrDefault(x =>
                    x.Email == user.Email &&
                    x.Password == user.Password);

            if (validUser != null)
{
    HttpContext.Session.SetString("UserEmail", validUser.Email);
    HttpContext.Session.SetString("UserName", validUser.Name);

    TempData["Message"] = "Login Successful!";

    return RedirectToAction("Index", "Dashboard");
}
    
            ViewBag.Message = "Invalid email or password!";
            return View();
        }
        public IActionResult Logout()
{
    HttpContext.Session.Clear();

    return RedirectToAction("Login");
}
    }
}