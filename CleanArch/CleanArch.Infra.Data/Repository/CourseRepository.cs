using System.Collections.Generic;
using CleanArch.Domain;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CourseRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Course> GetCourses()
        {
            return _dbContext.Courses;
        }
    }
}
