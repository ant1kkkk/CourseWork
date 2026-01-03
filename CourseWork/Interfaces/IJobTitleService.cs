using CourseWork.Database;
using CourseWork.Dtos;
using CourseWork.Entities;

namespace CourseWork.Interfaces
{
    public interface IJobTitleService
    {
        void Create(WorkersDbContext context, AddJobTitleRequest request);
        void Delete(int id, WorkersDbContext context);
        Jobtitle Get(int id, WorkersDbContext context);
        List<Jobtitle> GetJobTitles(WorkersDbContext context);
        void Update(int id, WorkersDbContext context, UpdateJobTitleRequest request);
    }
}