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
    public class SelectedStudentRepository : ISelectedStudentsRepository,IDisposable
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

      public async Task<SelectedStudent> AddSelectedStudentAsync(SelectedStudent selectedstudent)
       {
          await this.conn.InsertAsync(selectedstudent);
          selectedstudent.SelectedStudentId =this.conn.LastInsertId();
          return selectedstudent;
       
       }
       
      public async Task<List<SelectedStudent>> GetAllSelectedStudentAsync()
       {
         return await this.conn.SelectAsync<SelectedStudent>();
       
       }
       
      public async Task<SelectedStudent> FindSelectedStudentAsync(long id)
       {
         return await this.conn.SingleByIdAsync<SelectedStudent>(id);
       
       }
       
      public async Task<SelectedStudent> UpdateSelectedStudentAsync(SelectedStudent selectedstudent)
       {
          var result= await this.conn.UpdateAsync<SelectedStudent>(selectedstudent);
          return selectedstudent;
       
       }
       
      public async Task RemoveSelectedStudentAsync(long id)
       {
         await this.conn.DeleteByIdAsync<SelectedStudent>(id);
       
       }
       
      public async Task<SelectedStudent> GetSelectedStudentWithChildrenAsync(long id)
       {
          var selectedstudent = await this.conn.SingleByIdAsync<SelectedStudent>(id);
          
          
          
   
                 // One To One 
           var selectedstudentmember = await this.conn.SelectAsync<Student>(a => a.Where(e => e.StudentId == id));
           if (selectedstudent != null && selectedstudentmember != null)
           {
             selectedstudent.Student = selectedstudentmember.SingleOrDefault();
           }
         
   
                 // One To One 
           var department = await this.conn.SelectAsync<Department>(a => a.Where(e => e.DepartmentID == id));
           if (selectedstudent != null && department != null)
           {
             selectedstudent.Department = department.SingleOrDefault();
           }
         
   
                 // One To One 
           var course = await this.conn.SelectAsync<Course>(a => a.Where(e => e.CourseId == id));
           if (selectedstudent != null && course != null)
           {
             selectedstudent.Course = course.SingleOrDefault();
           }
         
  
         return selectedstudent;
         }
       
       
      public async Task<SelectedStudent> SaveSelectedStudentAsync(SelectedStudent selectedstudent)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(selectedstudent.IsNew)
                {
                   await this.AddSelectedStudentAsync(selectedstudent);
                }
                else
                {
                   await this.UpdateSelectedStudentAsync(selectedstudent);
                }
                
                
                    
                    
                 // One To One 
                 if(selectedstudent.Student!=null)
                 {
                    if(selectedstudent.Student.IsDeleted)
                    {
                      var id = selectedstudent.Student.StudentId;
                      await this._conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!selectedstudent.Student.IsDeleted)
                    {
                      var selectedstudentmember = selectedstudent.Student;
                      selectedstudentmember.StudentId = selectedstudent.SelectedStudentId;
                      await this.conn.SaveAsync(selectedstudentmember);
                    }
                    
                  }
                    
                    
                 // One To One 
                 if(selectedstudent.Department!=null)
                 {
                    if(selectedstudent.Department.IsDeleted)
                    {
                      var id = selectedstudent.Department.DepartmentID;
                      await this._conn.DeleteByIdAsync<Department>(id);
                    }
                    else if(!selectedstudent.Department.IsDeleted)
                    {
                      var department = selectedstudent.Department;
                      department.DepartmentID = selectedstudent.SelectedStudentId;
                      await this.conn.SaveAsync(department);
                    }
                    
                  }
                    
                    
                 // One To One 
                 if(selectedstudent.Course!=null)
                 {
                    if(selectedstudent.Course.IsDeleted)
                    {
                      var id = selectedstudent.Course.CourseId;
                      await this._conn.DeleteByIdAsync<Course>(id);
                    }
                    else if(!selectedstudent.Course.IsDeleted)
                    {
                      var course = selectedstudent.Course;
                      course.CourseId = selectedstudent.SelectedStudentId;
                      await this.conn.SaveAsync(course);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return selectedstudent;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}