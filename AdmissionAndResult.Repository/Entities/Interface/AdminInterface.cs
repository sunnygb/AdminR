using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IAdminsRepository
    {
    
      
       List< Admin> GetAll();
       Admin Find(int id);
       Admin Update(Admin admin);
       void Remove(int id); 
       Admin GetFull(int id);
       void Save(Admin admin);
      
      
    }
}