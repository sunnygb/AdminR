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
    public class CourseRepository : ICoursesRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Course Add(Course course)
       {
          this.conn.Insert(course);
          course.CourseId =this.conn.LastInsertId();
          return course;
       
       }
       
      public List<Course> GetAll()
       {
         return this.conn.Select<Course>();
       
       }
       
      public Course Find(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Course Update(Course course)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Course GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(Course course)
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