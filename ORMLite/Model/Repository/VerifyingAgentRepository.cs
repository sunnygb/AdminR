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
    public class VerifyingAgentRepository : IVerifyingAgentsRepository,IDisposable
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

      public async Task<VerifyingAgent> AddVerifyingAgentAsync(VerifyingAgent verifyingagent)
       {
          await this.conn.InsertAsync(verifyingagent);
          verifyingagent.VerifyingAgentId =this.conn.LastInsertId();
          return verifyingagent;
       
       }
       
      public async Task<List<VerifyingAgent>> GetAllVerifyingAgentAsync()
       {
         return await this.conn.SelectAsync<VerifyingAgent>();
       
       }
       
      public async Task<VerifyingAgent> FindVerifyingAgentAsync(long id)
       {
         return await this.conn.SingleByIdAsync<VerifyingAgent>(id);
       
       }
       
      public async Task<VerifyingAgent> UpdateVerifyingAgentAsync(VerifyingAgent verifyingagent)
       {
          var result= await this.conn.UpdateAsync<VerifyingAgent>(verifyingagent);
          return verifyingagent;
       
       }
       
      public async Task RemoveVerifyingAgentAsync(long id)
       {
         await this.conn.DeleteByIdAsync<VerifyingAgent>(id);
       
       }
       
      public async Task<VerifyingAgent> GetVerifyingAgentWithChildrenAsync(long id)
       {
          var verifyingagent = await this.conn.SingleByIdAsync<VerifyingAgent>(id);
          
          
          
   
                 // One To One 
           var admin = await this.conn.SingleAsync<Admin>(a => a.Where(e => e.AdminId == id));
           if (verifyingagent != null && admin != null)
           {
             verifyingagent.Admin = admin;
           }
         
   
                 // One To One 
           var student = await this.conn.SingleAsync<Student>(a => a.Where(e => e.StudentId == id));
           if (verifyingagent != null && student != null)
           {
             verifyingagent.Student = student;
           }
         
  
         return verifyingagent;
         }
       
       
      public async Task<VerifyingAgent> SaveVerifyingAgentAsync(VerifyingAgent verifyingagent)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(verifyingagent.IsNew)
                {
                   await this.AddVerifyingAgentAsync(verifyingagent);
                }
                else
                {
                   await this.UpdateVerifyingAgentAsync(verifyingagent);
                }
                
                
                    
                    
                 // One To One 
                 if(verifyingagent.Admin!=null)
                 {
                    if(verifyingagent.Admin.IsDeleted)
                    {
                      var id = verifyingagent.Admin.AdminId;
                      await this._conn.DeleteByIdAsync<Admin>(id);
                    }
                    else if(!verifyingagent.Admin.IsDeleted)
                    {
                      var admin = verifyingagent.Admin;
                      admin.AdminId = verifyingagent.VerifyingAgentId;
                      await this.conn.SaveAsync(admin);
                    }
                    
                  }
                    
                    
                 // One To One 
                 if(verifyingagent.Student!=null)
                 {
                    if(verifyingagent.Student.IsDeleted)
                    {
                      var id = verifyingagent.Student.StudentId;
                      await this._conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!verifyingagent.Student.IsDeleted)
                    {
                      var student = verifyingagent.Student;
                      student.StudentId = verifyingagent.VerifyingAgentId;
                      await this.conn.SaveAsync(student);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return verifyingagent;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}