using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Services;

namespace CourseWork.Endpoints
{
    public static class DepartmentEndpoints
    {
        private static readonly DepartmentService _departmentService = new();

        public static void MapDepartmentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("departments", async (WorkersDbContext context) => 
                Results.Ok(_departmentService.GetDepartments(context)))
                .RequireAuthorization(auth =>
                {
                    auth.RequireRole("User", "Admin");
                });

            app.MapGet("departments/{id:int}", async (int id, WorkersDbContext context) =>
            {
                var employee = _departmentService.Get(id, context);

                return employee is not null ? Results.Ok(employee) : Results.NotFound();
            })
            .WithName("GetDepartmentById")
            .RequireAuthorization(auth =>
            {
                auth.RequireRole("User", "Admin");
            });

            app.MapPost("departments", async (WorkersDbContext context, AddDepartmentRequest request) =>
            {
                _departmentService.Create(context, request);

                return Results.Created();
            })
            .RequireAuthorization(auth =>
            {
                auth.RequireRole("Admin");
            });

            app.MapPut("departments/{id:int}", async (int id, WorkersDbContext context, UpdateDepartmentRequest request) =>
            {
                _departmentService.Update(id, context, request);

                return Results.NoContent();
            })
            .RequireAuthorization(auth =>
            {
                auth.RequireRole("Admin");
            });

            app.MapDelete("departments/{id:int}", async (int id, WorkersDbContext context) =>
            {
                _departmentService.Delete(id, context);

                return Results.NoContent();
            })
            .RequireAuthorization(auth =>
            {
                auth.RequireRole("Admin");
            });
        }
    }
}