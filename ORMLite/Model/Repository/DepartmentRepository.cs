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
    public class DepartmentRepository : IDepartmentsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Department Add(Department department)
       {
          this.conn.Insert(department);
          department.DepartmentID =this.conn.LastInsertId();
          return department;
       
       }
       
      public List<Department> GetAll()
       {
         return this.conn.Select<Department>();
       
       }
       
      public Department Find(long id)
       {
         return this.conn.SingleById<Department>(id);
       
       }
       
      public Department Update(Department department)
       {
          var result=this.conn.Update<Department>(department);
          return department;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<Department>(id);
       
       }
       
      public Department GetAllWithChildren(long id)
       {
          var department = this.conn.SingleById<Department>(id);
          
          
          
        
                 //One To Many
           var selectedstudents = this.conn.Select<SelectedStudent>().Where(a => a.SelectedStudentId == id).ToList();
           if (department != null && selectedstudents != null)
           {
             department.SelectedStudents.AddRange(selectedstudents);
           }      
                  
                  
                  
  
         return department;
         }
       
       
      public Department Save(Department department)
       {
          using(var txScope= new TransactionScope())
            {
                if(department.IsNew)
                {
                    this.Add(department);
                }
                else
                {
                    this.Update(department);
                }
                
                
        
                 //One To Many
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.DepartmentID =department.DepartmentID;
                    this.conn.Save(selectedstudent);
                  }
                  foreach(var selectedstudent in department.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    this.conn.DeleteById<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return department;
       
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