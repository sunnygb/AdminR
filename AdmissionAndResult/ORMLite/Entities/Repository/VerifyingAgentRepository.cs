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
         return this.conn.SingleById<VerifyingAgent>(id);
       
       }
       
      public VerifyingAgent Update(VerifyingAgent verifyingagent)
       {
          var result=this.conn.Update<VerifyingAgent>(verifyingagent);
          return verifyingagent;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<VerifyingAgent>(id);
       
       }
       
      public VerifyingAgent GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public VerifyingAgent Save(VerifyingAgent verifyingagent)
       {
          using(var txScope= new TransactionScope())
            {
                if(verifyingagent.IsNew)
                {
                    this.Add(verifyingagent);
                }
                else
                {
                    this.Update(verifyingagent);
                }
                
                
                    
                    
                 // One To One 
                 var admin = verifyingagent.Admin;
                 admin.AdminId = verifyingagent.VerifyingAgentId;
                 this.conn.Save(admin);
                    
                    
                 // One To One 
                 var student = verifyingagent.Student;
                 student.StudentId = verifyingagent.VerifyingAgentId;
                 this.conn.Save(student);
                    
                   
                    txScope.Complete();
            }
            return verifyingagent;
       
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