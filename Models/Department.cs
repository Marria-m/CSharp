namespace SchoolSystem.Models
{
    // Convention: Id → Primary Key + Identity(1,1)
    // One-to-Many with Students  (DepartmentId FK on Student)
    // One-to-Many with Courses   (DepartmentId FK on Course)
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MgrName { get; set; }

        public List<Student>? Students { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
