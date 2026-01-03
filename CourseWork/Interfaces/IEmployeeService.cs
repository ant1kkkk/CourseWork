using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;

namespace CourseWork.Interfaces
{
    public interface IEmployeeService
    {
        void Create(WorkersDbContext context, AddEmployeeRequest request);
        void Delete(int id, WorkersDbContext context);
        Employee Get(int id, WorkersDbContext context);
        List<Employee> GetEmployees(WorkersDbContext context);
        void Update(int id, WorkersDbContext context, UpdateEmployeeRequest request);
    }
}