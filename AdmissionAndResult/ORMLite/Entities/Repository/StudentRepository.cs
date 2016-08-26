using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AdmissionAndResult.Data.Services;
using System.Text;
using System.Transactions;
using System.Linq;

namespace AdmissionAndResult.Data.Repository
{    
    public class StudentRepository : IStudentsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Student Add(Student student)
       {
          this.conn.Insert(student);
          student.StudentId =this.conn.LastInsertId();
          return student;
       
       }
       
      public List<Student> GetAll()
       {
         return this.conn.Select<Student>();
       
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
       private static IDbConnection GetConnection()
       {
          string connectionString =Environment.CurrentDirectory + "\\SystemDB.db";
          var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
          var db = dbFactory.OpenDbConnection();
          return db;

       
       }
   
    }
}