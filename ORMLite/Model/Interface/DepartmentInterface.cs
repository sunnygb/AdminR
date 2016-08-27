using System.Collections.Generic;

namespace AdmissionAndResult.Data.Services
{
    public interface IDepartmentsRepository
    {
       Department Add(Department department);
       List< Department> GetAll();
       Department Find(long id);
       Department Update(Department department);
       void Remove(long id); 
       
       Department GetAllWithChildren(long id);
       Department Save(Department department);
    }
}