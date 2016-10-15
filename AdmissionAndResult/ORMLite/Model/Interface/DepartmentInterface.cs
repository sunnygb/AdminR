using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface IDepartmentsRepository
    {
       Task<Department> AddDepartmentAsync(Department department);
       Task<List< Department>> GetAllDepartmentAsync();
       Task<Department> FindDepartmentAsync(long id);
       Task<Department> UpdateDepartmentAsync(Department department);
       Task RemoveDepartmentAsync(long id); 
       
       Task<Department> GetDepartmentWithChildrenAsync(long id);
       Task<Department> SaveDepartmentAsync(Department department);
    }
}