using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface ICoursesRepository
    {
    
      
       List< Course> GetAll();
       Course Find(int id);
       Course Update(Course course);
       void Remove(int id); 
       Course GetFull(int id);
       void Save(Course course);
      
      
    }
}