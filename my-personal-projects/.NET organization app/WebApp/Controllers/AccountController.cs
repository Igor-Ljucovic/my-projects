using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        Debug.WriteLine("app context konstruktor kod account");
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        Debug.WriteLine("vracen register");
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        Debug.WriteLine("register sa userom pre ifa");
        if (ModelState.IsValid)
        {
            Debug.WriteLine("pocetak ifa al pre drugog ifa");
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(user);
            }

            Debug.WriteLine("Dodat korisnik");

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
        {
            Debug.WriteLine("MODEL ERROR: " + modelError.ErrorMessage);
        }

        return View(user);
    }

    [HttpGet]
    public IActionResult Login()
    {
        Debug.WriteLine("login");
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }

        HttpContext.Session.SetInt32("UserID", user.UserID);
        HttpContext.Session.SetString("Username", user.Username);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
