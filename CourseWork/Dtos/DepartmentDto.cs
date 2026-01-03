namespace CourseWork.Dtos
{
    public sealed record AddDepartmentRequest(string DepartmentName, DateTime DepartmentCreationDate,
                                                DateTime HeadAppointmentDate, int IdHead);
    public sealed record UpdateDepartmentRequest(string DepartmentName, DateTime DepartmentCreationDate,
                                                DateTime HeadAppointmentDate, int IdHead);
}