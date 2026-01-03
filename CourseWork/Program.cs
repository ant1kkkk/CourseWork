using CourseWork.Database;
using CourseWork.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<WorkersDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapEmployeeEndpoints();
app.MapDepartmentEndpoints();
app.MapJobTitleEndpoints();

app.Run();