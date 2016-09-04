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
    public class CourseRepository : ICoursesRepository,IDisposable
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

      public async Task<Course> AddCourseAsync(Course course)
       {
          await this.conn.InsertAsync(course);
          course.CourseId =this.conn.LastInsertId();
          return course;
       
       }
       
      public async Task<List<Course>> GetAllCourseAsync()
       {
         return await this.conn.SelectAsync<Course>();
       
       }
       
      public async Task<Course> FindCourseAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Course>(id);
       
       }
       
      public async Task<Course> UpdateCourseAsync(Course course)
       {
          var result= await this.conn.UpdateAsync<Course>(course);
          return course;
       
       }
       
      public async Task RemoveCourseAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Course>(id);
       
       }
       
      public async Task<Course> GetCourseWithChildrenAsync(long id)
       {
          var course = await this.conn.SingleByIdAsync<Course>(id);
          
          
          
   
                 // One To One 
           var student = await this.conn.SingleAsync<Student>(a => a.Where(e => e.StudentId == id));
           if (course != null && student != null)
           {
             course.Student = student;
           }
         
        
                 //One To Many
           var selectedstudents = await this.conn.SelectAsync<SelectedStudent>(a=> a.Where(e => e.SelectedStudentId == id));
           if (course != null && selectedstudents != null)
           {
             course.SelectedStudents.AddRange(selectedstudents);
           }      
                  
                  
                  
  
         return course;
         }
       
       
      public async Task<Course> SaveCourseAsync(Course course)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(course.IsNew)
                {
                   await this.AddCourseAsync(course);
                }
                else
                {
                   await this.UpdateCourseAsync(course);
                }
                
                
                    
                    
                 // One To One 
                 if(course.Student!=null)
                 {
                    if(course.Student.IsDeleted)
                    {
                      var id = course.Student.StudentId;
                      await this._conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!course.Student.IsDeleted)
                    {
                      var student = course.Student;
                      student.StudentId = course.CourseId;
                      await this.conn.SaveAsync(student);
                    }
                    
                  }
        
                 //One To Many
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.CourseId =course.CourseId;
                    await this.conn.SaveAsync(selectedstudent);
                  }
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return course;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}