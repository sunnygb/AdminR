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
    public class DepartmentRepository : IDepartmentsRepository,IDisposable
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

      public async Task<Department> AddDepartmentAsync(Department department)
       {
          await this.conn.InsertAsync(department);
          department.DepartmentID =this.conn.LastInsertId();
          return department;
       
       }
       
      public async Task<List<Department>> GetAllDepartmentAsync()
       {
         return await this.conn.SelectAsync<Department>();
       
       }
       
      public async Task<Department> FindDepartmentAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Department>(id);
       
       }
       
      public async Task<Department> UpdateDepartmentAsync(Department department)
       {
          var result= await this.conn.UpdateAsync<Department>(department);
          return department;
       
       }
       
      public async Task RemoveDepartmentAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Department>(id);
       
       }
       
      public async Task<Department> GetDepartmentWithChildrenAsync(long id)
       {
          var department = await this.conn.SingleByIdAsync<Department>(id);
          
          
          
        
                 //One To Many
           var selectedstudents = await this.conn.SelectAsync<SelectedStudent>(a=> a.Where(e => e.SelectedStudentId == id));
           if (department != null && selectedstudents != null)
           {
             department.SelectedStudents.AddRange(selectedstudents);
           }      
                  
                  
                  
  
         return department;
         }
       
       
      public async Task<Department> SaveDepartmentAsync(Department department)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(department.IsNew)
                {
                   await this.AddDepartmentAsync(department);
                }
                else
                {
                   await this.UpdateDepartmentAsync(department);
                }
                
                
        
                 //One To Many
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.DepartmentID =department.DepartmentID;
                    await this.conn.SaveAsync(selectedstudent);
                  }
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return department;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}