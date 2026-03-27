using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contexts;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    public class StudentController : Controller
    {
        // /Student/ShowAll
        public IActionResult ShowAll()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> studentList = studentBL.GetAll();
            return View("ShowAll", studentList); // Model: List<Student>
        }

        // /Student/ShowDetails?id=3
        public IActionResult ShowDetails(int id)
        {
            StudentBL studentBL = new StudentBL();
            Student student = studentBL.GetById(id);
            return View("ShowDetails", student); // Model: Student
        }
    }
}