using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface ICoursesRepository
    {
       Task<Course> AddCourseAsync(Course course);
       Task<List< Course>> GetAllCourseAsync();
       Task<Course> FindCourseAsync(long id);
       Task<Course> UpdateCourseAsync(Course course);
       Task RemoveCourseAsync(long id); 
       
       Task<Course> GetCourseWithChildrenAsync(long id);
       Task<Course> SaveCourseAsync(Course course);
    }
}