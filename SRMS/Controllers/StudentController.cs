using Microsoft.AspNetCore.Mvc;
using SRMS.Infrastructure;
using SRMS.Models;

namespace SRMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _student.AddStudent(student);
                    return RedirectToAction("TeacherDashboard", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View("~/Views/Home/CreateStudent.cshtml", student);
        }

    }
}
