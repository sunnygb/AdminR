using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data.Services
{
    public interface IStudentsRepository
    {
       Student Add(Student student);
       List< Student> GetAll();
       Student Find(long id);
       Student Update(Student student);
       void Remove(long id); 
       
       Student GetAllWithChildren(long id);
       void Save(Student student);
    }
}