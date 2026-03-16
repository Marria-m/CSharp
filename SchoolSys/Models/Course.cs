using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    // Many-to-One with Department → DepartmentId FK
    // Many-to-Many with Student  → through StuCrsRes (junction table)
    // One-to-Many with Teacher   → CourseId FK on Teacher
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }
        public List<Teacher>? Teachers { get; set; }
        public List<StuCrsRes>? StuCrsRes { get; set; }
    }
}
