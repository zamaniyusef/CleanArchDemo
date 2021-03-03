using System.Collections.Generic;
using CleanArch.Domain;

namespace CleanArch.Application.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
