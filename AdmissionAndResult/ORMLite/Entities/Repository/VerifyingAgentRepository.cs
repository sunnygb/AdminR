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
    public class VerifyingAgentRepository : IVerifyingAgentsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public VerifyingAgent Add(VerifyingAgent verifyingagent)
       {
          this.conn.Insert(verifyingagent);
          verifyingagent.VerifyingAgentId =this.conn.LastInsertId();
          return verifyingagent;
       
       }
       
      public List<VerifyingAgent> GetAll()
       {
         return this.conn.Select<VerifyingAgent>();
       
       }
       
      public VerifyingAgent Find(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public VerifyingAgent Update(VerifyingAgent verifyingagent)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public VerifyingAgent GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(VerifyingAgent verifyingagent)
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