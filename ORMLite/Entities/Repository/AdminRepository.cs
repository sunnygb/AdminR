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
    public class AdminRepository : IAdminsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Admin Add(Admin admin)
       {
          this.conn.Insert(admin);
          admin.AdminId =this.conn.LastInsertId();
          return admin;
       
       }
       
      public List<Admin> GetAll()
       {
         return this.conn.Select<Admin>();
       
       }
       
      public Admin Find(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Admin Update(Admin admin)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Admin GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(Admin admin)
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