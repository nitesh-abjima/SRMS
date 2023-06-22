using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using SRMS.Infrastructure;
using SRMS.Models;
using System.Diagnostics;

namespace SRMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAccess _userAccess;
        private readonly IStudent _student;
        private readonly IResultRepo _results;

        public HomeController(ILogger<HomeController> logger, IUserAccess userAccess, IStudent student, IResultRepo results)
        {
            _logger = logger;
            _userAccess = userAccess;
            _student = student;
            _results = results;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TeacherDashboard()
        {
            var students = _student.GetAllStudents();

            return View(students);
        }
        public IActionResult StudentDashboard()
        {
            return View();
        }
        public IActionResult CreateStudent()
        {
            return View();
        }
        public IActionResult Result()
        {
            var result = _results.GetResult();
            return View(result);
        }

        //public IActionResult Logout()
        //{
        //    // Perform logout actions

        //    return RedirectToAction("Index", "Home");
        //}


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
                        else
                        {
                            return RedirectToAction("StudentDashboard");
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
            if (ModelState.IsValid)
            {
                try
                {
                    bool S = await _userAccess.SignupUser(user);
                    if (S)
                    {
                        TempData["SignupSuccessMessage"] = "<script>alert('Signup Successfull !') </script >";
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