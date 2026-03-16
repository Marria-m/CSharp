using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contexts;

namespace SchoolSystem.Models
{
    public class StudentBL
    {
        SchoolDbContext db = new SchoolDbContext();

        public List<Student> GetAll()
        {
            return db.Students
                     .Include(s => s.Department)
                     .ToList();
        }

        public Student GetById(int id)
        {
            return db.Students
                     .Include(s => s.Department)
                     .Include(s => s.StuCrsRes)
                     .ThenInclude(sc => sc.Course)
                     .FirstOrDefault(s => s.Id == id);
        }
    }
}
