using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IStudentsRepository
    {
    
      
      public List< Student> GetAll();
      public Student Find(int id);
      public Student Update(Student student);
      public void Remove(int id); 
      public Student GetFull(int id);
      public void Save(Student student);
      
      
    }
}