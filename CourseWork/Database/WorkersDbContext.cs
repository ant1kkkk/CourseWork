using Npgsql;

namespace CourseWork.Database
{
    public sealed class WorkersDbContext(IConfiguration configuration)
    {
        private readonly string _connectionString = configuration.GetConnectionString("DbConnectionString")!;

        public NpgsqlConnection Create() => new NpgsqlConnection(_connectionString);
    }
}