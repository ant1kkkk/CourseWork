namespace CourseWork.Dtos
{
    public sealed record AddEmployeeRequest(string FirstName, string LastName, int Age,
                                                int IdJobTitle, int IdDepartment, DateTime EmploymentDate);
    public sealed record UpdateEmployeeRequest(string FirstName, string LastName, int Age,
                                                int IdJobTitle, int IdDepartment, DateTime EmploymentDate);
}