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
    public class QualificationRepository : IQualificationsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Qualification Add(Qualification qualification)
       {
          this.conn.Insert(qualification);
          qualification.QualificationId =this.conn.LastInsertId();
          return qualification;
       
       }
       
      public List<Qualification> GetAll()
       {
         return this.conn.Select<Qualification>();
       
       }
       
      public Qualification Find(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Qualification Update(Qualification qualification)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Qualification GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(Qualification qualification)
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