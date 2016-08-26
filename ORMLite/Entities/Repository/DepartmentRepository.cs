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
          throw new NotImplementedException();
       
       }
       
      public Department Update(Department department)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Department GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(Department department)
       {
          throw new NotImplementedException();
       
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