namespace CourseWork.Entities
{
    public sealed class Department
    {
        public int IdDepartment { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public DateOnly DepartmentCreationDate { get; set; }
        public DateOnly HeadAppointmentDate { get; set; }
        public int IdHead { get; set; }
    }
}