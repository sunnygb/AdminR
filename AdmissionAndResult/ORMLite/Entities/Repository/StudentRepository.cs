using System;
using System.Collections.Generic;
using AdmissionAndResult.Data.Services;
using System.Text;
using System.Transactions;
using System.Linq;

namespace AdmissionAndResult.Data.Repository
{    
    public class StudentRepository : IStudentsRepository 
    {

      public Student Add(Student student)
       {
          throw new NotImplementedException();
       
       }
       
      public List< Student> GetAll()
       {
          throw new NotImplementedException();
       
       }
       
      public Student Find(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Student Update(Student student)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Student GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(Student student)
       {
          throw new NotImplementedException();
       
       }
   
    }
}