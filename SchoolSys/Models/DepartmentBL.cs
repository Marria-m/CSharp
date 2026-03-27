using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contexts;   

namespace SchoolSystem.Models
{
    public class DepartmentBL
    {
        SchoolDbContext context = new SchoolDbContext();

        // GetAll - fetch all departments including their students
        public List<Department> GetAll()
        {
            return context.Departments
                          .Include(d => d.Students)
                          .ToList();
        }

        // GetById - fetch one department by id including students
        public Department GetById(int id)
        {
            return context.Departments
                          .Include(d => d.Students)
                          .FirstOrDefault(d => d.Id == id);
        }

        // Add - add new department to DB
        public void Add(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }
    }
}