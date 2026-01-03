using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Services;

namespace CourseWork.Endpoints
{
    public static class EmployeeEndpoints
    {
        private static readonly EmployeeService _employeeService = new();
        public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("employees", async (WorkersDbContext context) => Results.Ok(_employeeService.GetEmployees(context)));

            app.MapGet("employees/{id:int}", async (int id, WorkersDbContext context) =>
            {
                var employee = _employeeService.Get(id, context);

                return employee is not null ? Results.Ok(employee) : Results.NotFound();
            })
            .WithName("GetEmployeeById");

            app.MapPost("employees", async (WorkersDbContext context, AddEmployeeRequest request) =>
            {
                _employeeService.Create(context, request);

                return Results.Created();
            });

            app.MapPut("employees/{id:int}", async (int id, WorkersDbContext context, UpdateEmployeeRequest request) =>
            {
                _employeeService.Update(id, context, request);

                return Results.NoContent();
            });

            app.MapDelete("employees/{id:int}", async (int id, WorkersDbContext context) =>
            {
                _employeeService.MoveEmployeeToArchive(id, context);
                _employeeService.Delete(id, context);

                return Results.NoContent();
            });
        }
    }
}