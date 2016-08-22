using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IQualificationsRepository
    {
    
      
      public List< Qualification> GetAll();
      public Qualification Find(int id);
      public Qualification Update(Qualification qualification);
      public void Remove(int id); 
      public Qualification GetFull(int id);
      public void Save(Qualification qualification);
      
      
    }
}