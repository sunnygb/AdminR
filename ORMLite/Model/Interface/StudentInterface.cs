using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface IStudentsRepository
    {
       Task<Student> AddStudentAsync(Student student);
       Task<List< Student>> GetAllStudentAsync();
       Task<Student> FindStudentAsync(long id);
       Task<Student> UpdateStudentAsync(Student student);
       Task RemoveStudentAsync(long id); 
       
       Task<Student> GetStudentWithChildrenAsync(long id);
       Task<Student> SaveStudentAsync(Student student);
    }
}