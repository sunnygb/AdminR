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
    public class SelectedStudentRepository : ISelectedStudentsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public SelectedStudent Add(SelectedStudent selectedstudent)
       {
          this.conn.Insert(selectedstudent);
          selectedstudent.SelectedStudentId =this.conn.LastInsertId();
          return selectedstudent;
       
       }
       
      public List<SelectedStudent> GetAll()
       {
         return this.conn.Select<SelectedStudent>();
       
       }
       
      public SelectedStudent Find(long id)
       {
         return this.conn.SingleById<SelectedStudent>(id);
       
       }
       
      public SelectedStudent Update(SelectedStudent selectedstudent)
       {
          var result=this.conn.Update<SelectedStudent>(selectedstudent);
          return selectedstudent;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<SelectedStudent>(id);
       
       }
       
      public SelectedStudent GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public SelectedStudent Save(SelectedStudent selectedstudent)
       {
          using(var txScope= new TransactionScope())
            {
                if(selectedstudent.IsNew)
                {
                    this.Add(selectedstudent);
                }
                else
                {
                    this.Update(selectedstudent);
                }
                
                
                    
                    
                 // One To One 
                 var department = selectedstudent.Department;
                 department.DepartmentID = selectedstudent.SelectedStudentId;
                 this.conn.Save(department);
                    
                    
                 // One To One 
                 var course = selectedstudent.Course;
                 course.CourseId = selectedstudent.SelectedStudentId;
                 this.conn.Save(course);
                    
                    
                 // One To One 
                 var student = selectedstudent.Student;
                 student.StudentId = selectedstudent.SelectedStudentId;
                 this.conn.Save(student);
                    
                   
                    txScope.Complete();
            }
            return selectedstudent;
       
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