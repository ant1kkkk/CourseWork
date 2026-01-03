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

        public void Delete(int idDepartment, WorkersDbContext context)
        {
            const string query = $@"DELETE FROM departments
                                        WHERE idDepartment = @IdDepartment";

            using NpgsqlConnection connection = context.Create();

            connection.Execute(
                query,
                new { IdDepartment = idDepartment });
        }

        public Department Get(int idDepartment, WorkersDbContext context)
        {
            const string query = $@"SELECT      idDepartment                    AS {nameof(Department.IdDepartment)}
                                                ,sDepartmentName                AS {nameof(Department.DepartmentName)}
                                                ,dDepartmentCreationDate        AS {nameof(Department.DepartmentCreationDate)}
                                                ,dHeadAppointmentDate           AS {nameof(Department.HeadAppointmentDate)}
                                                ,idHead                         AS {nameof(Department.IdHead)}
                                    FROM departments
                                    WHERE idDepartment = @IdDepartment";

            using NpgsqlConnection connection = context.Create();

            var department = connection.QuerySingleOrDefault<Department>(
                query,
                new { IdDepartment = idDepartment });

            return department!;
        }

        public List<Department> GetDepartments(WorkersDbContext context)
        {
            const string query = $@"SELECT      idDepartment                    AS {nameof(Department.IdDepartment)}
                                                ,sDepartmentName                AS {nameof(Department.DepartmentName)}
                                                ,dDepartmentCreationDate        AS {nameof(Department.DepartmentCreationDate)}
                                                ,dHeadAppointmentDate           AS {nameof(Department.HeadAppointmentDate)}
                                                ,idHead                         AS {nameof(Department.IdHead)}
                                    FROM departments";

            using NpgsqlConnection connection = context.Create();

            var departments = connection.Query<Department>(query);

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
    }
}