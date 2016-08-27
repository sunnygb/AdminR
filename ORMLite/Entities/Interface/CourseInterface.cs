using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data.Services
{
    public interface ICoursesRepository
    {
       Course Add(Course course);
       List< Course> GetAll();
       Course Find(long id);
       Course Update(Course course);
       void Remove(long id); 
       
       Course GetAllWithChildren(long id);
       Course Save(Course course);
    }
}