using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Npgsql;

namespace CourseWork.Services;

public class UserService
{
    public void Register(WorkersDbContext context, AddUserRequest request)
    {
        const string query = $@"INSERT INTO Users(sUserName, sFirstName, idRole, sPassword)
                                        VALUES(@UserName, @FirstName, @IdRole, @Password)";

        try
        {
            using NpgsqlConnection connection = context.Create();

            connection.Execute(
                query,
                new
                {
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    IdRole = request.IdRole,
                    Password = new PasswordHasher<AddUserRequest>().HashPassword(request, request.Password)
                });
        }
        catch (Exception e)
        {
            Console.WriteLine("Create User Error");
        }
    }

    public string Login(WorkersDbContext context, LoginUserRequest request, JwtService jwtService)
    {
        const string query = $@"SELECT  sUserName AS {nameof(User.UserName)},
                                        sFirstName AS {nameof(User.FirstName)},
                                        sPassword AS {nameof(User.Password)},
                                        sRoleName AS {nameof(User.Role)}
                                            FROM vdrUser
                                            WHERE sUserName = @UserName";

        User? user = null;
        
        using NpgsqlConnection connection = context.Create();

        user = connection.QuerySingleOrDefault<User>(
            query,
            new
            {
                UserName = request.UserName 
            });
            
        var password = new PasswordHasher<User>()
                .VerifyHashedPassword(
                    user, user.Password, request.Password);

        if (password == PasswordVerificationResult.Success)
        {
            return jwtService.GenerateJwtToken(user);
        }
        else
        {
            throw new Exception("Unauthorized");
        }
    }
}