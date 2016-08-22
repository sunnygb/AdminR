using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface ISelectedStudentsRepository
    {
    
      
      public List< SelectedStudent> GetAll();
      public SelectedStudent Find(int id);
      public SelectedStudent Update(SelectedStudent selectedstudent);
      public void Remove(int id); 
      public SelectedStudent GetFull(int id);
      public void Save(SelectedStudent selectedstudent);
      
      
    }
}