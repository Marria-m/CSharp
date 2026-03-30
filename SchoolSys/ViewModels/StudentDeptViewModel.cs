namespace SchoolSystem.ViewModels
{
    public class StudentDeptViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? DepartmentId { get; set; }

        // for the  dropdown
        public List<SchoolSystem.Models.Department> Departments { get; set; }
    }
}