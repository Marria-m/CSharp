using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Controllers
{
    public class DepartmentController : Controller
    {
        // /Department/ShowAll
        public IActionResult ShowAll()
        {
            DepartmentBL departmentBL = new DepartmentBL();
            List<Department> deptList = departmentBL.GetAll();
            return View("ShowAll", deptList);
        }

        // /Department/ShowDetails?id=2
        public IActionResult ShowDetails(int id)
        {
            DepartmentBL departmentBL = new DepartmentBL();
            Department dept = departmentBL.GetById(id);

            if (dept == null)
                return NotFound();

            DepartmentDetailsVM vm = new DepartmentDetailsVM
            {
                DepartmentName = dept.Name,
                StudentsAbove25 = dept.Students?
                                      .Where(s => s.Age > 25)
                                      .Select(s => s.Name)
                                      .ToList() ?? new List<string>(),
                DepartmentState = dept.Students?.Count > 50 ? "Main" : "Branch"
            };

            return View("ShowDetails", vm);
        }

        // GET /Department/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        // POST /Department/Add
        [HttpPost]
        public IActionResult Add(Department dept)
        {
            DepartmentBL departmentBL = new DepartmentBL();
            departmentBL.Add(dept);
            return RedirectToAction("ShowAll");
        }
    }
}