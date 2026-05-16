using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using System.Linq;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
private bool IsUserLoggedIn()
{
    return HttpContext.Session.GetString("UserEmail") != null;
}
        // SHOW ALL STUDENTS
        public IActionResult Index()
{
    if (!IsUserLoggedIn())
    {
        return RedirectToAction("Login", "Account");
    }

    var students = _context.Students.ToList();

    return View(students);
}

        // OPEN CREATE PAGE
       public IActionResult Create()
{
    if (!IsUserLoggedIn())
    {
        return RedirectToAction("Login", "Account");
    }

    return View();
}

        // SAVE STUDENT
        [HttpPost]
public IActionResult Create(Student student)
{
    if (!IsUserLoggedIn())
    {
        return RedirectToAction("Login", "Account");
    }

    if (ModelState.IsValid)
    {
        _context.Students.Add(student);

        _context.SaveChanges();

        TempData["Message"] = "Student Added Successfully!";

        return RedirectToAction("Index");
    }

    return View();
}
public IActionResult Delete(int id)
{
    var student = _context.Students.Find(id);

    if(student != null)
    {
        _context.Students.Remove(student);

        _context.SaveChanges();
    }

    TempData["DeleteMessage"] =
        "Student Deleted Successfully!";

    return RedirectToAction("Index");
}
    }
}