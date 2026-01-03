namespace CourseWork.Dtos
{
    public sealed record AddJobTitleRequest(string JobTitleName, decimal Salary);
    public sealed record UpdateJobTitleRequest(string JobTitleName, decimal Salary);
}