using AdmissionAndResult.Data.Services;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

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
          var verifyingagent = this.conn.SingleById<VerifyingAgent>(id);
          
          
          
   
                 // One To One 
           var admin = this.conn.Select<Admin>().Where(a => a.AdminId == id).SingleOrDefault();
           if (verifyingagent != null && admin != null)
           {
             verifyingagent.Admin = admin;
           }
         
   
                 // One To One 
           var student = this.conn.Select<Student>().Where(a => a.StudentId == id).SingleOrDefault();
           if (verifyingagent != null && student != null)
           {
             verifyingagent.Student = student;
           }
         
  
         return verifyingagent;
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
                 if(verifyingagent.Admin !=null)
                 {
                    var admin = verifyingagent.Admin;
                    admin.AdminId = verifyingagent.VerifyingAgentId;
                    this.conn.Save(admin);
                 }
                    
                    
                 // One To One 
                 if(verifyingagent.Student !=null)
                 {
                    var student = verifyingagent.Student;
                    student.StudentId = verifyingagent.VerifyingAgentId;
                    this.conn.Save(student);
                 }
                 
                   
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