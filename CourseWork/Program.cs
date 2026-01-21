using CourseWork.Database;
using CourseWork.Endpoints;
using CourseWork.Extensions;
using CourseWork.Services;
using CourseWork.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<WorkersDbContext>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<JwtService>();
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapEmployeeEndpoints();
app.MapDepartmentEndpoints();
app.MapJobTitleEndpoints();
app.MapAuthEndpoints();

app.Run();