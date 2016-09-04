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

      public async Task<Admin> AddAdminAsync(Admin admin)
       {
          await this.conn.InsertAsync(admin);
          admin.AdminId =this.conn.LastInsertId();
          return admin;
       
       }
       
      public async Task<List<Admin>> GetAllAdminAsync()
       {
         return await this.conn.SelectAsync<Admin>();
       
       }
       
      public async Task<Admin> FindAdminAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Admin>(id);
       
       }
       
      public async Task<Admin> UpdateAdminAsync(Admin admin)
       {
          var result= await this.conn.UpdateAsync<Admin>(admin);
          return admin;
       
       }
       
      public async Task RemoveAdminAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Admin>(id);
       
       }
       
      public async Task<Admin> GetAdminWithChildrenAsync(long id)
       {
          var admin = await this.conn.SingleByIdAsync<Admin>(id);
          
          
          
        
                 //One To Many
           var verifyingagents = await this.conn.SelectAsync<VerifyingAgent>(a=> a.Where(e => e.VerifyingAgentId == id));
           if (admin != null && verifyingagents != null)
           {
             admin.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
  
         return admin;
         }
       
       
      public async Task<Admin> SaveAdminAsync(Admin admin)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(admin.IsNew)
                {
                   await this.AddAdminAsync(admin);
                }
                else
                {
                   await this.UpdateAdminAsync(admin);
                }
                
                
        
                 //One To Many
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.AdminId =admin.AdminId;
                    await this.conn.SaveAsync(verifyingagent);
                  }
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<VerifyingAgent>(verifyingagent.VerifyingAgentId);
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