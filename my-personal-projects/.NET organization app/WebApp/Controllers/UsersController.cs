using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
    //    private IUserService userService;

    //    public UsersController(IUserService userService)
    //    {
    //        this.userService = userService;
    //    }

    //    public IActionResult Index()
    //    {
    //        List<UserViewModel> result =
    //            userService.GetUsers().Select(
    //                u => new UserViewModel
    //                {
    //                    Id = u.Id,
    //                    FirstName = u.FirstName,
    //                    LastName = u.LastName,
    //                }
    //                ).ToList();


    //        return View(result);
    //    }

    //    public IActionResult Details
    //        ([FromRoute(Name ="id")]int userId)
    //    {
    //        User u = userService.GetById(userId);
    //        if (u == null)
    //        {
    //            return RedirectToAction("Index");
    //        }
    //        UserViewModel viewModel = new UserViewModel
    //        {
    //           Id = u.Id,
    //           FirstName = u.FirstName,
    //           LastName = u.LastName,
    //        };
            
    //        return View(viewModel);
    //    }

    //    [HttpGet]
    //    public IActionResult Add()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult Add(UserViewModel user)
    //    {
    //        var id = userService.GetUsers().Max(u => u.Id) + 1;
    //        user.Id = id;

    //        userService.GetUsers().Add(new Domain.User
    //        {
    //            Id = user.Id,
    //            FirstName = user.FirstName,
    //            LastName = user.LastName
    //        });
            
    //        return RedirectToAction("Index");
    //    }
    }
}
