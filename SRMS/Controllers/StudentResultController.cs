using Microsoft.AspNetCore.Mvc;
using SRMS.Infrastructure;

namespace SRMS.Controllers
{
    public class StudentResultController : Controller
    {
        private readonly IStudentResult _studentResult;

        public StudentResultController(IStudentResult studentResult)
        {
            _studentResult = studentResult;
        }

        public async Task<IActionResult> GetStudentResult(int rollNo)
        {
            try
            {
                var studentResult = await _studentResult.GetStudentResultByRollNo(rollNo);

                if (studentResult == null)
                {
                    return NotFound();
                }

                return View("~/Views/StudentResult/StudentResult.cshtml", studentResult);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                //TempData["ErrorMessage"] = "<script>alert('Student with this roll no does not exists !') </script >";
                //return RedirectToAction("StudentDashboard", "Home");
                //return View("~/Views/Home/StudentDashboard.cshtml");
            }
            return View("~/Views/Home/StudentDashboard.cshtml");

        }
    }
}
