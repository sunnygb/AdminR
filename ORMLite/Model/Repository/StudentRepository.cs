using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AdmissionAndResult.Data.Services;
using System.Text;
using System.Transactions;
using System.Linq;
using ServiceStack.Data;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Repository
{    
    public class StudentRepository : IStudentsRepository,IDisposable
    { 
      
      
       public IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection conn 
       { 
          get 
          {
            return _conn = _conn ??  DbFactory.Open();
          }
       }

      public async Task<Student> AddStudentAsync(Student student)
       {
          await this.conn.InsertAsync(student);
          student.StudentId =this.conn.LastInsertId();
          return student;
       
       }
       
      public async Task<List<Student>> GetAllStudentAsync()
       {
         return await this.conn.SelectAsync<Student>();
       
       }
       
      public async Task<Student> FindStudentAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Student>(id);
       
       }
       
      public async Task<Student> UpdateStudentAsync(Student student)
       {
          var result= await this.conn.UpdateAsync<Student>(student);
          return student;
       
       }
       
      public async Task RemoveStudentAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Student>(id);
       
       }
       
      public async Task<Student> GetStudentWithChildrenAsync(long id)
       {
          var student = await this.conn.SingleByIdAsync<Student>(id);
          
          
          
        
                 //One To Many
           var courses = await this.conn.SelectAsync<Course>(a=> a.Where(e => e.CourseId == id));
           if (student != null && courses != null)
           {
             student.Courses.AddRange(courses);
           }      
                  
                  
                  
        
                 //One To Many
           var verifyingagents = await this.conn.SelectAsync<VerifyingAgent>(a=> a.Where(e => e.VerifyingAgentId == id));
           if (student != null && verifyingagents != null)
           {
             student.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
   
                 // One To One 
           var qualification = await this.conn.SelectAsync<Qualification>(a => a.Where(e => e.QualificationId == id));
           if (student != null && qualification != null)
           {
             student.Qualification = qualification.SingleOrDefault();
           }
         
   
                 // One To One 
           var selectedselectedstudent = await this.conn.SelectAsync<SelectedStudent>(a => a.Where(e => e.SelectedStudentId == id));
           if (student != null && selectedselectedstudent != null)
           {
             student.SelectedStudent = selectedselectedstudent.SingleOrDefault();
           }
         
  
         return student;
         }
       
       
      public async Task<Student> SaveStudentAsync(Student student)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(student.IsNew)
                {
                   await this.AddStudentAsync(student);
                }
                else
                {
                   await this.UpdateStudentAsync(student);
                }
                
                
        
                 //One To Many
                  foreach(var course in student.Courses.Where(s => !s.IsDeleted))
                  { 
                  
                    course.StudentId =student.StudentId;
                    await this.conn.SaveAsync(course);
                  }
                  foreach(var course in student.Courses.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<Course>(course.CourseId);
                  }
        
                 //One To Many
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.StudentId =student.StudentId;
                    await this.conn.SaveAsync(verifyingagent);
                  }
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                    
                    
                    
                 // One To One 
                 if(student.Qualification!=null)
                 {
                    if(student.Qualification.IsDeleted)
                    {
                      var id = student.Qualification.QualificationId;
                      await this._conn.DeleteByIdAsync<Qualification>(id);
                    }
                    else if(!student.Qualification.IsDeleted)
                    {
                      var qualification = student.Qualification;
                      qualification.QualificationId = student.StudentId;
                      await this.conn.SaveAsync(qualification);
                    }
                    
                  }
                    
                    
                 // One To One 
                 if(student.SelectedStudent!=null)
                 {
                    if(student.SelectedStudent.IsDeleted)
                    {
                      var id = student.SelectedStudent.SelectedStudentId;
                      await this._conn.DeleteByIdAsync<SelectedStudent>(id);
                    }
                    else if(!student.SelectedStudent.IsDeleted)
                    {
                      var selectedselectedstudent = student.SelectedStudent;
                      selectedselectedstudent.SelectedStudentId = student.StudentId;
                      await this.conn.SaveAsync(selectedselectedstudent);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return student;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}