using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface ICoursesRepository
    {
    
      
      public List< Course> GetAll();
      public Course Find(int id);
      public Course Update(Course course);
      public void Remove(int id); 
      public Course GetFull(int id);
      public void Save(Course course);
      
      
    }
}