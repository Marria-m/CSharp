using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    // Many-to-One with Department → DepartmentId FK
    // Many-to-Many with Course   → through StuCrsRes (junction table)
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }
        public List<StuCrsRes>? StuCrsRes { get; set; }
    }
}
