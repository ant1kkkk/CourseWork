namespace CourseWork.Dtos;

public sealed record AddUserRequest(string UserName, string FirstName, int IdRole, string Password);
public sealed record LoginUserRequest(string UserName, string Password);