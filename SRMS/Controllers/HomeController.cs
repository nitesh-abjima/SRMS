using Microsoft.AspNetCore.Mvc;
using SRMS.Infrastructure;
using SRMS.Models;
using System.Diagnostics;

namespace SRMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAccess _userAccess;

        public HomeController(ILogger<HomeController> logger, IUserAccess userAccess)
        {
            _logger = logger;
            _userAccess = userAccess;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TeacherDashboard()
        {
            return View();
        }
        public IActionResult StudentDashboard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool S = await _userAccess.LoginUser(user.Username, user.Password, user.UserType);

                    if (S)
                    {
                        string userType = user.UserType;

                        if (userType == "Teacher")
                        {
                            return RedirectToAction("TeacherDashboard");
                        }
                        else if (userType == "Student")
                        {
                            return RedirectToAction("StudentDashboard");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid user type.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View();
        }


        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(Users user)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    bool S = await _userAccess.SignupUser(user);
                    if (S)
                    {
                        return RedirectToAction("Index");
                    }
                    //else
                    //{
                    //    ModelState.AddModelError(string.Empty, "Username or email already exists.");
                    //}
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}