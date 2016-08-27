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
         return this.conn.SingleById<Student>(id);
       
       }
       
      public Student Update(Student student)
       {
          var result=this.conn.Update<Student>(student);
          return student;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<Student>(id);
       
       }
       
      public Student GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Student Save(Student student)
       {
          using(var txScope= new TransactionScope())
            {
                if(student.IsNew)
                {
                    this.Add(student);
                }
                else
                {
                    this.Update(student);
                }
                
                
        
                 //One To Many
                  foreach(var course in student.Courses.Where(s => !s.IsDeleted))
                  { 
                  
                    course.StudentId =student.StudentId;
                    this.conn.Save(course);
                  }
                  foreach(var course in student.Courses.Where(s => s.IsDeleted))
                  { 
                  
                    this.conn.DeleteById<Course>(course.CourseId);
                  }
        
                 //One To Many
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.StudentId =student.StudentId;
                    this.conn.Save(verifyingagent);
                  }
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    this.conn.DeleteById<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                    
                    
                 // One To One 
                 var qualification = student.Qualification;
                 qualification.QualificationId = student.StudentId;
                 this.conn.Save(qualification);
        
                 //One To Many
                  foreach(var selectedstudent in student.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.StudentId =student.StudentId;
                    this.conn.Save(selectedstudent);
                  }
                  foreach(var selectedstudent in student.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    this.conn.DeleteById<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                    
                   
                    txScope.Complete();
            }
            return student;
       
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