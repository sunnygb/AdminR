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

namespace AdmissionAndResult.Data.Repository
{    
    public class AdminRepository : IAdminsRepository,IDisposable
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
         return this.conn.SingleById<Admin>(id);
       
       }
       
      public Admin Update(Admin admin)
       {
          var result=this.conn.Update<Admin>(admin);
          return admin;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<Admin>(id);
       
       }
       
      public Admin GetAllWithChildren(long id)
       {
          var admin = this.conn.SingleById<Admin>(id);
          
          
          
        
                 //One To Many
           var verifyingagents = this.conn.Select<VerifyingAgent>().Where(a => a.VerifyingAgentId == id).ToList();
           if (admin != null && verifyingagents != null)
           {
             admin.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
  
         return admin;
         }
       
       
      public Admin Save(Admin admin)
      {
          using(var txScope= new TransactionScope())
            {
                if(admin.IsNew)
                {
                    this.Add(admin);
                }
                else
                {
                    this.Update(admin);
                }
                
                
        
                 //One To Many
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.AdminId =admin.AdminId;
                    this.conn.Save(verifyingagent);
                  }
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    this.conn.DeleteById<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return admin;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}