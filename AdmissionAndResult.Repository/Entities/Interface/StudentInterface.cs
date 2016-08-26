using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IStudentsRepository
    {
    
      
       List< Student> GetAll();
       Student Find(int id);
       Student Update(Student student);
       void Remove(int id); 
       Student GetFull(int id);
       void Save(Student student);
      
      
    }
}