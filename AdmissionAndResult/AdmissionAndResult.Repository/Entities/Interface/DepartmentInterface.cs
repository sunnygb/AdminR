using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IDepartmentsRepository
    {
    
      
       List< Department> GetAll();
       Department Find(int id);
       Department Update(Department department);
       void Remove(int id); 
       Department GetFull(int id);
       void Save(Department department);
      
      
    }
}