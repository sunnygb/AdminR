using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface ISelectedStudentsRepository
    {
       Task<SelectedStudent> AddSelectedStudentAsync(SelectedStudent selectedstudent);
       Task<List< SelectedStudent>> GetAllSelectedStudentAsync();
       Task<SelectedStudent> FindSelectedStudentAsync(long id);
       Task<SelectedStudent> UpdateSelectedStudentAsync(SelectedStudent selectedstudent);
       Task RemoveSelectedStudentAsync(long id); 
       
       Task<SelectedStudent> GetSelectedStudentWithChildrenAsync(long id);
       Task<SelectedStudent> SaveSelectedStudentAsync(SelectedStudent selectedstudent);
    }
}