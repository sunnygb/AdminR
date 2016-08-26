using System;
using System.Collections.Generic;
using System.Text;

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
       void Save(Department department);
    }
}