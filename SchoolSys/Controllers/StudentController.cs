using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();
        DepartmentBL departmentBL = new DepartmentBL();

        // /Student/Index
        public IActionResult Index(string? searchName, int? deptId, int page = 1)
        {
            int pageSize = 5;

            List<Student> students = studentBL.GetAll();

            // Search by name
            if (!string.IsNullOrEmpty(searchName))
                students = students.Where(s => s.Name.Contains(searchName,
                               StringComparison.OrdinalIgnoreCase)).ToList();

            // Filter by department
            if (deptId != null && deptId > 0)
                students = students.Where(s => s.DepartmentId == deptId).ToList();

            // Pagination
            int totalPages = (int)Math.Ceiling(students.Count / (double)pageSize);
            students = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.SearchName = searchName;
            ViewBag.DeptId = deptId;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Departments = departmentBL.GetAll();

            return View("Index", students); // Model : List<Student>
        }

        // /Student/Details?id=3
        public IActionResult Details(int id)
        {
            Student student = studentBL.GetById(id);
            return View("Details", student); // Model : Student
        }

        // GET /Student/Add
        [HttpGet]
        public IActionResult Add()
        {
            // Sources
            List<Department> DeptList = departmentBL.GetAll();
 
            // Mapping → ViewModel (empty student + departments)
            StudentDeptViewModel SDVM = new StudentDeptViewModel()
            {
                Departments = DeptList
            };
 
            return View("Add", SDVM); // Model : StudentDeptViewModel
        }

        // POST /Student/SaveAdd
        [HttpPost]
        public IActionResult SaveAdd(Student studentSent)
        {
            if (studentSent.Name != null)
            {
                studentBL.Add(studentSent);
                return RedirectToAction(nameof(Index));
            }
            return View("Add", studentSent);
        }

        // GET /Student/Edit?id=3
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Sources
            Student Stu = studentBL.GetById(id);
            List<Department> DeptList = departmentBL.GetAll();

            // Mapping
            StudentDeptViewModel SDVM = new StudentDeptViewModel()
            {
                Id = Stu.Id,
                Name = Stu.Name,
                Age = Stu.Age,
                DepartmentId = Stu.DepartmentId,
                Departments = DeptList
            };

            return View("Edit", SDVM); // Model : StudentDeptViewModel
        }

        // POST /Student/SaveEdit/3
        [HttpPost]
        public IActionResult SaveEdit(Student NewStudent, int id)
        {
            // Get old student from DB
            Student OldStudent = studentBL.GetById(id);

            if (NewStudent.Name != null)
            {
                // Update local object
                OldStudent.Name = NewStudent.Name;
                OldStudent.Age = NewStudent.Age;
                OldStudent.DepartmentId = NewStudent.DepartmentId;

                // Save to DB
                studentBL.Save();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Edit", new { id = id });
        }

        // GET /Student/Delete?id=3 (warning)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = studentBL.GetById(id);
            return View("Delete", student); // Model : Student
        }

        // POST /Student/ConfirmDelete
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            studentBL.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}