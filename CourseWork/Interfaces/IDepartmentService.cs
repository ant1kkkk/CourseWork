using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;

namespace CourseWork.Interfaces
{
    public interface IDepartmentService
    {
        void Create(WorkersDbContext context, AddDepartmentRequest request);
        void Delete(int id, WorkersDbContext context);
        Department Get(int id, WorkersDbContext context);
        List<Department> GetDepartments(WorkersDbContext context);
        void Update(int id, WorkersDbContext context, UpdateDepartmentRequest request);
    }
}