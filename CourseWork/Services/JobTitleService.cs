using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;
using CourseWork.Interfaces;
using Dapper;
using Npgsql;

namespace CourseWork.Services
{
    public class JobTitleService : IJobTitleService
    {
        public void Create(WorkersDbContext context, AddJobTitleRequest request)
        {
            const string query = $@"INSERT INTO jobtitles(sJobTitleName, mSalary)
                                        VALUES(@JobTitleName, @Salary)";

            using NpgsqlConnection connection = context.Create();

            connection.Execute(
                query,
                new
                {
                    JobTitleName = request.JobTitleName,
                    Salary = request.Salary
                });
        }

        public void Delete(int idJobTitle, WorkersDbContext context)
        {
            const string query = $@"DELETE FROM jobtitles
                                        WHERE idJobTitle = @IdJobTitle";

            using NpgsqlConnection connection = context.Create();

            connection.Execute(
                query,
                new { IdJobTitle = idJobTitle });
        }

        public Jobtitle Get(int idJobTitle, WorkersDbContext context)
        {
            const string query = $@"SELECT      idJobTitle        AS {nameof(Jobtitle.IdJobTitle)}
                                                ,sJobTitleName    AS {nameof(Jobtitle.JobTitleName)}
                                                ,mSalary          AS {nameof(Jobtitle.Salary)}
                                    FROM jobtitles
                                    WHERE idJobtitle = @IdJobTitle";

            using NpgsqlConnection connection = context.Create();

            var jobTitle = connection.QuerySingleOrDefault<Jobtitle>(
                query,
                new { IdJobTitle = idJobTitle });

            return jobTitle!;
        }

        public List<Jobtitle> GetJobTitles(WorkersDbContext context)
        {
            const string query = $@"SELECT      idJobTitle        AS {nameof(Jobtitle.IdJobTitle)}
                                                ,sJobTitleName    AS {nameof(Jobtitle.JobTitleName)}
                                                ,mSalary          AS {nameof(Jobtitle.Salary)}
                                    FROM jobtitles";

            using NpgsqlConnection connection = context.Create();

            var jobTitles = connection.Query<Jobtitle>(query);

            return jobTitles.ToList();
        }

        public void Update(int idJobTitle, WorkersDbContext context, UpdateJobTitleRequest request)
        {
            const string query = $@"UPDATE jobtitles
                                    SET     sJobTitleName = @JobTitleName
                                            ,mSalary = @Salary
                                    WHERE idJobTitle = @IdJobTitle";

            using NpgsqlConnection connection = context.Create();

            connection.Execute(
                query,
                new
                {
                    IdJobtitle = idJobTitle,
                    JobTitleName = request.JobTitleName,
                    Salary = request.Salary
                });
        }
    }
}