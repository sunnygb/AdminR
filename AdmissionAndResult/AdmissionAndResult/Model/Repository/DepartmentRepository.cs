using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;
using ServiceStack.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalReporting.Model.Repository
{    



#region Interface

    public interface IDepartmentsRepository
    {
       Task<Department> AddDepartmentAsync(Department department);
       Task<List< Department>> GetAllDepartmentAsync();
       Task<Department> FindDepartmentAsync(long id);
       Task<Department> UpdateDepartmentAsync(Department department);
       Task RemoveDepartmentAsync(long id); 
       Task<Department> GetDepartmentWithChildrenAsync(long id);
       Task<Department> SaveDepartmentAsync(Department department);
       Task<List<Department>> QueryAsync(string query);
       
       Department AddDepartment(Department department);
       List< Department> GetAllDepartment();
       Department FindDepartment(long id);
       Department UpdateDepartment(Department department);
       void RemoveDepartment(long id); 
       Department GetWithChildren(long id);
       Department SaveDepartment(Department department);
       List< Department> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class DepartmentRepository : IDepartmentsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public DepartmentRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Department AddDepartment(Department department)
       {
          this.Conn.Insert(department);
          department.DepartmentID =this.Conn.LastInsertId();
          return department;
       
       }
       
      public List<Department> GetAllDepartment()
       {
         return Conn.Select<Department>();
       
       }
       
      public Department FindDepartment(long id)
       {
         return Conn.SingleById<Department>(id);
       
       }
       
      public Department UpdateDepartment(Department department)
       {
          var result=Conn.Update<Department>(department);
          return department;
       
       }
       
      public void RemoveDepartment(long id)
       {
          Conn.DeleteById<Department>(id);
       
       }
       
      public Department GetWithChildren(long id)
       {
          var department = Conn.SingleById<Department>(id);
          
          
          
        
                 //One To Many
           var selectedstudents = Conn.Select<SelectedStudent>().Where(a => a.SelectedStudentId == id).ToList();
           if (department != null && selectedstudents != null)
           {
             department.SelectedStudents.AddRange(selectedstudents);
           }      
                  
                  
                  
  
         return department;
         }
       
       
      public Department SaveDepartment(Department department)
      {
          using(var txScope= new TransactionScope())
            {
                if(department.IsNew)
                {
                    this.AddDepartment(department);
                }
                else
                {
                    this.UpdateDepartment(department);
                }
                
                
        
                 //One To Many
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.DepartmentID =department.DepartmentID;
                    Conn.Save(selectedstudent);
                  }
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return department;
       
       }
       
       public List< Department> Query(string query)
       {
          return Conn.Select<Department>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Department> AddDepartmentAsync(Department department)
       {
          await Conn.InsertAsync(department);
          department.DepartmentID =Conn.LastInsertId();
          return department;
       
       }
       
      public async Task<List<Department>> GetAllDepartmentAsync()
       {
         return await Conn.SelectAsync<Department>();
       
       }
       
      public async Task<Department> FindDepartmentAsync(long id)
       {
         return await Conn.SingleByIdAsync<Department>(id);
       
       }
       
      public async Task<Department> UpdateDepartmentAsync(Department department)
       {
          await Conn.UpdateAsync<Department>(department);
          return department;
       
       }
       
      public async Task RemoveDepartmentAsync(long id)
       {
         await Conn.DeleteByIdAsync<Department>(id);
       
       }
       
      public async Task<Department> GetDepartmentWithChildrenAsync(long id)
       {
          var department = await Conn.SingleByIdAsync<Department>(id);
          
          
          
        
                 //One To Many
           var selectedstudents = await Conn.SelectAsync<SelectedStudent>(e => e.SelectedStudentId == id);
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
                   await AddDepartmentAsync(department);
                }
                else
                {
                   await UpdateDepartmentAsync(department);
                }
                
                
        
                 //One To Many
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.DepartmentID =department.DepartmentID;
                    await Conn.SaveAsync(selectedstudent);
                  }
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return department;
       
       }
       
      public async Task<List<Department>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Department>(query);
      }
      
      
       #endregion
       
       
       
#region Design Repository
       


      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignDepartmentsRepository : IDepartmentsRepository
    {
    
    
       public Department AddDepartment(Department department)
       {
          return null;
       }
       public List< Department> GetAllDepartment()
       {
           var resultList = new List<Department>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Department
                {
                    
                  DepartmentID = i+12345, 
                  DepartmentName =  "DepartmentName"+i, 
                  StudentStrength = i+12345, 
                  HODName =  "HODName"+i, 
                  Location =  "Location"+i, 
                });
            }
            return resultList;
         
       }
       public  Department FindDepartment(long id)
       {
             return new Department
                {
                    
                    DepartmentID =  12345,
                    DepartmentName =  "DepartmentName",
                    StudentStrength =  12345,
                    HODName =  "HODName",
                    Location =  "Location",
                };
       }
       public Department UpdateDepartment(Department department)
       {
         return null;
       }
       public void RemoveDepartment(long id)
       {
          return;
       
       }
       public Department GetWithChildren(long id)
       {
              
        // One to Many
        var selectedstudent1= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };
        var selectedstudent2= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };         

         
        return new Department
                {
                    
                    DepartmentID = 12345,
                    DepartmentName =  "DepartmentName",
                    StudentStrength = 12345,
                    HODName =  "HODName",
                    Location =  "Location",
                    
                     // One to Many
                     SelectedStudents = new List<SelectedStudent>{selectedstudent1,selectedstudent2},
                     
                };
         
       }
       public Department SaveDepartment(Department department)
       {
         return null;
       }
       public List< Department> Query(string query)
       {
          var resultList = new List<Department>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Department
                {
                    
                  DepartmentID = i+12345, 
                  DepartmentName =  "DepartmentName"+i, 
                  StudentStrength = i+12345, 
                  HODName =  "HODName"+i, 
                  Location =  "Location"+i, 
                });
            }
            return resultList;
       }
    
      public Task<Department> AddDepartmentAsync(Department department)
      {
         return null;
      }
      public async Task<List<Department>> GetAllDepartmentAsync()
      {
            var resultList = new List<Department>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Department
                {
                    
                  DepartmentID = i+12345, 
                  DepartmentName =  "DepartmentName"+i, 
                  StudentStrength = i+12345, 
                  HODName =  "HODName"+i, 
                  Location =  "Location"+i, 
                });
            }
            return resultList;
      }
      public async Task<Department> FindDepartmentAsync(long id)
      {
         return new Department
                {
                    
                    DepartmentID =  12345,
                    DepartmentName =  "DepartmentName",
                    StudentStrength =  12345,
                    HODName =  "HODName",
                    Location =  "Location",
                };
      }
      public async Task<Department> UpdateDepartmentAsync(Department department)
      {
        return null;
      }
      public async Task RemoveDepartmentAsync(long id)
      {
        
      }
       
      public async Task<Department> GetDepartmentWithChildrenAsync(long id)
      {
        // One to Many
        var selectedstudent1= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };
        var selectedstudent2= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };         

         
        return new Department
                {
                    
                    DepartmentID = 12345,
                    DepartmentName =  "DepartmentName",
                    StudentStrength = 12345,
                    HODName =  "HODName",
                    Location =  "Location",
                    
                     // One to Many
                     SelectedStudents = new List<SelectedStudent>{selectedstudent1,selectedstudent2},
                     
                };
         
      }
      public async Task<Department> SaveDepartmentAsync(Department department)
      {
        return null;
      }
      public async Task<List<Department>> QueryAsync(string query)
      {
         var resultList = new List<Department>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Department
                {
                    
                  DepartmentID = i+12345, 
                  DepartmentName =  "DepartmentName"+i, 
                  StudentStrength = i+12345, 
                  HODName =  "HODName"+i, 
                  Location =  "Location"+i, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}