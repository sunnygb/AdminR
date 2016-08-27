using AdmissionAndResult.Data.Services;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

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
          var student = this.conn.SingleById<Student>(id);
          
          
          
        
                 //One To Many
           var courses = this.conn.Select<Course>().Where(a => a.CourseId == id).ToList();
           if (student != null && courses != null)
           {
             student.Courses.AddRange(courses);
           }      
                  
                  
                  
        
                 //One To Many
           var verifyingagents = this.conn.Select<VerifyingAgent>().Where(a => a.VerifyingAgentId == id).ToList();
           if (student != null && verifyingagents != null)
           {
             student.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
   
                 // One To One 
           var qualification = this.conn.Select<Qualification>().Where(a => a.QualificationId == id).SingleOrDefault();
           if (student != null && qualification != null)
           {
             student.Qualification = qualification;
           }
         
   
                 // One To One 
           var selectedselectedstudent = this.conn.Select<SelectedStudent>().Where(a => a.SelectedStudentId == id).SingleOrDefault();
           if (student != null && selectedselectedstudent != null)
           {
             student.SelectedSelectedStudent = selectedselectedstudent;
           }
         
  
         return student;
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
                 if(student.Qualification !=null)
                 {
                    var qualification = student.Qualification;
                    qualification.QualificationId = student.StudentId;
                    this.conn.Save(qualification);
                 }
                    
                    
                 // One To One 
                 if(student.SelectedSelectedStudent !=null)
                 {
                    var selectedselectedstudent = student.SelectedSelectedStudent;
                    selectedselectedstudent.SelectedStudentId = student.StudentId;
                    this.conn.Save(selectedselectedstudent);
                 }
                 
                   
                    txScope.Complete();
            }
            return student;
       
       }
          
       
       private static IDbConnection GetConnection()
       {
           string connectionString ="D:\\AdmissionAndResult\\ORMLite.Tests\\bin\\Debug\\SystemDB.db";
          var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
          var db = dbFactory.OpenDbConnection();
          return db;

       
       }
   
    }
}