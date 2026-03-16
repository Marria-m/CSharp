namespace SchoolSystem.Models
{
    // Many-to-Many between Student and Course
    // Composite Primary Key: (StudentId + CourseId)
    // Extra column: Grade → payload data on the relationship
    public class StuCrsRes
    {
        // Composite PK
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public decimal Grade { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
