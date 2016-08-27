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
          var selectedstudent = this.conn.SingleById<SelectedStudent>(id);
          
          
          
   
                 // One To One 
           var selectedstudentmember = this.conn.Select<Student>().Where(a => a.StudentId == id).SingleOrDefault();
           if (selectedstudent != null && selectedstudentmember != null)
           {
             selectedstudent.Student = selectedstudentmember;
           }
         
   
                 // One To One 
           var department = this.conn.Select<Department>().Where(a => a.DepartmentID == id).SingleOrDefault();
           if (selectedstudent != null && department != null)
           {
             selectedstudent.Department = department;
           }
         
   
                 // One To One 
           var course = this.conn.Select<Course>().Where(a => a.CourseId == id).SingleOrDefault();
           if (selectedstudent != null && course != null)
           {
             selectedstudent.Course = course;
           }
         
  
         return selectedstudent;
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
                 if(selectedstudent.Student !=null)
                 {
                     var selectedstudentmember = selectedstudent.Student;
                    selectedstudentmember.StudentId = selectedstudent.SelectedStudentId;
                    this.conn.Save(selectedstudentmember);
                 }
                    
                    
                 // One To One 
                 if(selectedstudent.Department !=null)
                 {
                    var department = selectedstudent.Department;
                    department.DepartmentID = selectedstudent.SelectedStudentId;
                    this.conn.Save(department);
                 }
                    
                    
                 // One To One 
                 if(selectedstudent.Course !=null)
                 {
                    var course = selectedstudent.Course;
                    course.CourseId = selectedstudent.SelectedStudentId;
                    this.conn.Save(course);
                 }
                 
                   
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