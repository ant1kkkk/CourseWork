using Npgsql;

namespace CourseWork.Database
{
    public sealed class WorkersDbContext
    {
        private readonly string _connectionString;

        public WorkersDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString")!;
        }

        public NpgsqlConnection Create() => new NpgsqlConnection(_connectionString);
    }
}