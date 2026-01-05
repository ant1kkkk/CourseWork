using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;
using CourseWork.Interfaces;
using Dapper;
using Npgsql;

namespace CourseWork.Services
{
    public class DepartmentService : IDepartmentService
    {
        public void Create(WorkersDbContext context, AddDepartmentRequest request)
        {
            const string query = $@"INSERT INTO departments(sdepartmentname, ddepartmentcreationdate, dheadappointmentdate, idhead)
                                        VALUES(@DepartmentName, @DepartmentCreationDate, @HeadAppointmentDate, @IdHead)";

            try
            {
                using NpgsqlConnection connection = context.Create();
                
                connection.Execute(
                    query,
                    new
                    {
                        DepartmentName = request.DepartmentName,
                        DepartmentCreationDate = request.DepartmentCreationDate,
                        HeadAppointmentDate = request.HeadAppointmentDate,
                        IdHead = request.IdHead
                    });
            }
            catch (PostgresException ex)
            {
                Console.WriteLine("Server Error");
            }
        }

        public void Delete(int idDepartment, WorkersDbContext context)
        {
            const string query = $@"DELETE FROM departments
                                        WHERE idDepartment = @IdDepartment";

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new { IdDepartment = idDepartment });
            }
            catch (PostgresException ex)
            {
                Console.WriteLine("Server Error");
            }
        }

        public Department? Get(int idDepartment, WorkersDbContext context)
        {
            const string query = $@"SELECT      idDepartment                    AS {nameof(Department.IdDepartment)}
                                                ,sDepartmentName                AS {nameof(Department.DepartmentName)}
                                                ,dDepartmentCreationDate        AS {nameof(Department.DepartmentCreationDate)}
                                                ,dHeadAppointmentDate           AS {nameof(Department.HeadAppointmentDate)}
                                                ,idHead                         AS {nameof(Department.IdHead)}
                                    FROM departments
                                    WHERE idDepartment = @IdDepartment";

            Department? department = null;
            
            try
            {
                using NpgsqlConnection connection = context.Create();

                department = connection.QuerySingleOrDefault<Department>(
                    query,
                    new { IdDepartment = idDepartment });

                return department!;
            }
            catch (PostgresException ex)
            {
                Console.WriteLine("Server Error");
            }

            return department;
        }

        public List<Department> GetDepartments(WorkersDbContext context)
        {
            const string query = $@"SELECT      idDepartment                    AS {nameof(Department.IdDepartment)}
                                                ,sDepartmentName                AS {nameof(Department.DepartmentName)}
                                                ,dDepartmentCreationDate        AS {nameof(Department.DepartmentCreationDate)}
                                                ,dHeadAppointmentDate           AS {nameof(Department.HeadAppointmentDate)}
                                                ,idHead                         AS {nameof(Department.IdHead)}
                                    FROM departments";

            IEnumerable<Department>? departments = null;

            try
            {
                using NpgsqlConnection connection = context.Create();

                departments = connection.Query<Department>(query);
            }
            catch (PostgresException ex)
            {
                Console.WriteLine("Server Error");
            }

            return departments.ToList();
        }

        public void Update(int idDepartment, WorkersDbContext context, UpdateDepartmentRequest request)
        {
            const string query = $@"UPDATE departments
                                    SET     sDepartmentName = @DepartmentName
                                            ,dDepartmentCreationDate = @DepartmentCreationDate
                                            ,dHeadAppointmentDate = @HeadAppointmentDate
                                            ,idHead = @IdHead
                                    WHERE idDepartment = @IdDepartment";

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new
                    {
                        IdDepartment = idDepartment,
                        DepartmentName = request.DepartmentName,
                        DepartmentCreationDate = request.DepartmentCreationDate,
                        HeadAppointmentDate = request.HeadAppointmentDate,
                        IdHead = request.IdHead
                    });
            }
            catch (PostgresException ex)
            {
                Console.WriteLine("Server Error");
            }
        }
    }
}