using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Services;

namespace CourseWork.Endpoints;

public static class AuthEndpoints
{
    private static readonly UserService _userService = new();
    
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", async (WorkersDbContext context, AddUserRequest request) =>
        {
            _userService.Register(context, request);

            return Results.Created();
        });
        
        app.MapPost("login", async (WorkersDbContext context, LoginUserRequest request, JwtService jwtService) =>
        {
            var token = _userService.Login(context, request, jwtService);

            return Results.Ok(token);
        });
    }
}