using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;
using CourseWork.Interfaces;
using Dapper;
using Npgsql;

namespace CourseWork.Services
{
    public class EmployeeService : IEmployeeService
    {
        public void Create(WorkersDbContext context, AddEmployeeRequest request)
        {
            const string query = $@"INSERT INTO employees(sFirstName, sLastName, iAge, idJobTitle, idDepartment, dEmploymentDate)
                                        VALUES(@FirstName, @LastName, @Age, @IdJobTitle, @IdDepartment, @EmploymentDate)";

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Age = request.Age,
                        IdJobTitle = request.IdJobTitle,
                        IdDepartment = request.IdDepartment,
                        EmploymentDate = request.EmploymentDate
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error");
            }
            
        }

        public void Delete(int id, WorkersDbContext context)
        {
            const string query = $@"DELETE FROM employees
                                        WHERE id = @Id";

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new { Id = id });
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error");
            }
        }

        public Employee? Get(int id, WorkersDbContext context)
        {
            const string query = $@"SELECT      id                  AS {nameof(Employee.Id)}
                                                ,sFirstName         AS {nameof(Employee.FirstName)}
                                                ,sLastName          AS {nameof(Employee.LastName)}
                                                ,iAge               AS {nameof(Employee.Age)}
                                                ,idJobTitle         AS {nameof(Employee.IdJobTitle)}
                                                ,idDepartment       AS {nameof(Employee.IdDepartment)}
                                                ,dEmploymentDate    AS {nameof(Employee.EmploymentDate)}
                                    FROM employees
                                    WHERE id = @Id";

            Employee? employee = null;

            try
            {
                using NpgsqlConnection connection = context.Create();

                employee = connection.QuerySingleOrDefault<Employee>(
                    query,
                    new { Id = id });
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error");
            }

            return employee;
        }

        public List<Employee> GetEmployees(WorkersDbContext context)
        {   
            const string query = $@"SELECT      id                  AS {nameof(Employee.Id)}
                                                ,sFirstName         AS {nameof(Employee.FirstName)}
                                                ,sLastName          AS {nameof(Employee.LastName)}
                                                ,iAge               AS {nameof(Employee.Age)}
                                                ,idJobTitle         AS {nameof(Employee.IdJobTitle)}
                                                ,idDepartment       AS {nameof(Employee.IdDepartment)}
                                                ,dEmploymentDate    AS {nameof(Employee.EmploymentDate)}
                                    FROM employees";

            IEnumerable<Employee>? employees = null;

            try
            {
                using NpgsqlConnection connection = context.Create();

                employees = connection.Query<Employee>(query);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error");
            }

            return employees.ToList();
        }

        public void Update(int id, WorkersDbContext context, UpdateEmployeeRequest request)
        {
            const string query = $@"UPDATE employees
                                    SET     sFirstName = @FirstName
                                            ,sLastName = @LastName
                                            ,iAge = @Age
                                            ,idJobTitle = @IdJobTitle
                                            ,idDepartment = @IdDepartment
                                            ,dEmploymentDate = @EmploymentDate
                                    WHERE id = @Id";

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new
                    {
                        Id = id,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Age = request.Age,
                        IdJobTitle = request.IdJobTitle,
                        IdDepartment = request.IdDepartment,
                        EmploymentDate = request.EmploymentDate
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error");
            }
        }

        public void MoveEmployeeToArchive(int id, WorkersDbContext context)
        {
            const string query = $@"CALL sp_move_employee_into_archive(@id)";

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new
                    {
                        id = id
                    }); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error");
            }
        }
    }
}