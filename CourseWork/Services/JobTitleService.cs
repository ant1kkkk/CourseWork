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

            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new
                    {
                        JobTitleName = request.JobTitleName,
                        Salary = request.Salary
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine("Create JobTitle Error");
            }
        }

        public void Delete(int idJobTitle, WorkersDbContext context)
        {
            const string query = $@"DELETE FROM jobtitles
                                        WHERE idJobTitle = @IdJobTitle";
            try
            {
                using NpgsqlConnection connection = context.Create();

                connection.Execute(
                    query,
                    new { IdJobTitle = idJobTitle });
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete JobTitle Error");
            }
        }

        public Jobtitle? Get(int idJobTitle, WorkersDbContext context)
        {
            const string query = $@"SELECT      idJobTitle        AS {nameof(Jobtitle.IdJobTitle)}
                                                ,sJobTitleName    AS {nameof(Jobtitle.JobTitleName)}
                                                ,mSalary          AS {nameof(Jobtitle.Salary)}
                                    FROM jobtitles
                                    WHERE idJobtitle = @IdJobTitle";

            Jobtitle? jobTitle = null;

            try
            {
                using NpgsqlConnection connection = context.Create();

                jobTitle = connection.QuerySingleOrDefault<Jobtitle>(
                    query,
                    new { IdJobTitle = idJobTitle });
            }
            catch (Exception e)
            {
                Console.WriteLine("Get JobTitle Error");
            }

            return jobTitle;
        }

        public List<Jobtitle> GetJobTitles(WorkersDbContext context)
        {
            const string query = $@"SELECT      idJobTitle        AS {nameof(Jobtitle.IdJobTitle)}
                                                ,sJobTitleName    AS {nameof(Jobtitle.JobTitleName)}
                                                ,mSalary          AS {nameof(Jobtitle.Salary)}
                                    FROM jobtitles";

            IEnumerable<Jobtitle>? jobTitles = null;
            try
            {
                using NpgsqlConnection connection = context.Create();

                jobTitles = connection.Query<Jobtitle>(query);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get JobTitles Error");
            }

            return jobTitles.ToList();
        }

        public void Update(int idJobTitle, WorkersDbContext context, UpdateJobTitleRequest request)
        {
            const string query = $@"UPDATE jobtitles
                                    SET     sJobTitleName = @JobTitleName
                                            ,mSalary = @Salary
                                    WHERE idJobTitle = @IdJobTitle";

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("Update JobTitle Error");
            }
        }
    }
}