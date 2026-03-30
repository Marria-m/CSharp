using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contexts;

namespace SchoolSystem.Models
{
    public class StudentBL
    {
        SchoolDbContext context = new SchoolDbContext();

        // 1- GetAll
        public List<Student> GetAll()
        {
            return context.Students
                          .Include(s => s.Department)
                          .ToList();
        }

        // 2- GetById
        public Student GetById(int id)
        {
            return context.Students
                          .Include(s => s.Department)
                          .Include(s => s.StuCrsRes)
                              .ThenInclude(sc => sc.Course)
                          .FirstOrDefault(s => s.Id == id);
        }

        // 3- Add to DB
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        // 4- Save changes
        public void Save()
        {
            context.SaveChanges();
        }

        // 5- Delete
        public void Delete(int id)
        {
            Student student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}