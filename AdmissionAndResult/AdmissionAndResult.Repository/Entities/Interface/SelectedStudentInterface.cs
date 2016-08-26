using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface ISelectedStudentsRepository
    {
    
      
       List< SelectedStudent> GetAll();
       SelectedStudent Find(int id);
       SelectedStudent Update(SelectedStudent selectedstudent);
       void Remove(int id); 
       SelectedStudent GetFull(int id);
       void Save(SelectedStudent selectedstudent);
      
      
    }
}