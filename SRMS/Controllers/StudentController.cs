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

        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _student.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _student.AddStudent(student);
                    return RedirectToAction("TeacherDashboard", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View("~/Views/Home/CreateStudent.cshtml", student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            await _student.EditStudent(student);

            return RedirectToAction("TeacherDashboard", "Home");
        }

    }
}
