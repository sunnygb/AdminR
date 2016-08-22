using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IDepartmentsRepository
    {
    
      
      public List< Department> GetAll();
      public Department Find(int id);
      public Department Update(Department department);
      public void Remove(int id); 
      public Department GetFull(int id);
      public void Save(Department department);
      
      
    }
}