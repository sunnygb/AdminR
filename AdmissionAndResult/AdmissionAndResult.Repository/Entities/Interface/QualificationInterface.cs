using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IQualificationsRepository
    {
    
      
       List< Qualification> GetAll();
       Qualification Find(int id);
       Qualification Update(Qualification qualification);
       void Remove(int id); 
       Qualification GetFull(int id);
       void Save(Qualification qualification);
      
      
    }
}