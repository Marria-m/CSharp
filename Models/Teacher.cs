using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    // Many-to-One with Course      → CourseId FK
    // Many-to-One with Department  → DepartmentId FK
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Course? Course { get; set; }
        public Department? Department { get; set; }
    }
}
