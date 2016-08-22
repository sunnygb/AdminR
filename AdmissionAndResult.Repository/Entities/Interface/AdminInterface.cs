using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IAdminsRepository
    {
    
      
      public List< Admin> GetAll();
      public Admin Find(int id);
      public Admin Update(Admin admin);
      public void Remove(int id); 
      public Admin GetFull(int id);
      public void Save(Admin admin);
      
      
    }
}