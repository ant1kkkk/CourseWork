using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Services;

namespace CourseWork.Endpoints
{
    public static class JobTitleEndpoints
    {
        private static readonly JobTitleService _jobtitleSerivce = new();

        public static void MapJobTitleEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("jobtitles", async (WorkersDbContext context) => Results.Ok(_jobtitleSerivce.GetJobTitles(context)));

            app.MapGet("jobtitles/{id:int}", async (int id, WorkersDbContext context) =>
            {
                var employee = _jobtitleSerivce.Get(id, context);

                return employee is not null ? Results.Ok(employee) : Results.NotFound();
            })
            .WithName("GetJobTitleById");

            app.MapPost("jobtitles", async (WorkersDbContext context, AddJobTitleRequest request) =>
            {
                _jobtitleSerivce.Create(context, request);

                return Results.Created();
            });

            app.MapPut("jobtitles/{id:int}", async (int id, WorkersDbContext context, UpdateJobTitleRequest request) =>
            {
                _jobtitleSerivce.Update(id, context, request);

                return Results.NoContent();
            });

            app.MapDelete("jobtitles/{id:int}", async (int id, WorkersDbContext context) =>
            {
                _jobtitleSerivce.Delete(id, context);

                return Results.NoContent();
            });
        }
    }
}