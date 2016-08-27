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
         return this.conn.SingleById<Course>(id);
       
       }
       
      public Course Update(Course course)
       {
          var result=this.conn.Update<Course>(course);
          return course;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<Course>(id);
       
       }
       
      public Course GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Course Save(Course course)
       {
          using(var txScope= new TransactionScope())
            {
                if(course.IsNew)
                {
                    this.Add(course);
                }
                else
                {
                    this.Update(course);
                }
                
                
                    
                    
                 // One To One 
                 var student = course.Student;
                 student.StudentId = course.CourseId;
                 this.conn.Save(student);
        
                 //One To Many
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.CourseId =course.CourseId;
                    this.conn.Save(selectedstudent);
                  }
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    this.conn.DeleteById<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                    
                   
                    txScope.Complete();
            }
            return course;
       
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