using Microsoft.AspNetCore.Mvc;
using SRMS.Infrastructure;
using SRMS.Models;

namespace SRMS.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultRepo _result;

        public ResultController(IResultRepo result)
        {
            _result = result;
        }

        public async Task<IActionResult> EditResult(int id)
        {
            var result = await _result.GetResultById(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        public IActionResult AddResult()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddResult(Result result)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //// Calculate marks and percentage
                    //decimal marks = result.Maths + result.English + result.Science + result.History;
                    //decimal percentage = marks / 4;

                    //result.Marks = marks;
                    //result.Percentage = percentage;

                    await _result.AddResult(result);
                    return RedirectToAction("Result", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult EditResult(Result result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            _result.EditResult(result);

            return RedirectToAction("Result", "Home");
        }
    }
}
