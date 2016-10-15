using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;
using ServiceStack.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalReporting.Model.Repository
{    



#region Interface

    public interface IAdminsRepository
    {
       Task<Admin> AddAdminAsync(Admin admin);
       Task<List< Admin>> GetAllAdminAsync();
       Task<Admin> FindAdminAsync(long id);
       Task<Admin> UpdateAdminAsync(Admin admin);
       Task RemoveAdminAsync(long id); 
       Task<Admin> GetAdminWithChildrenAsync(long id);
       Task<Admin> SaveAdminAsync(Admin admin);
       Task<List<Admin>> QueryAsync(string query);
       
       Admin AddAdmin(Admin admin);
       List< Admin> GetAllAdmin();
       Admin FindAdmin(long id);
       Admin UpdateAdmin(Admin admin);
       void RemoveAdmin(long id); 
       Admin GetWithChildren(long id);
       Admin SaveAdmin(Admin admin);
       List< Admin> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class AdminRepository : IAdminsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public AdminRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Admin AddAdmin(Admin admin)
       {
          this.Conn.Insert(admin);
          admin.AdminId =this.Conn.LastInsertId();
          return admin;
       
       }
       
      public List<Admin> GetAllAdmin()
       {
         return Conn.Select<Admin>();
       
       }
       
      public Admin FindAdmin(long id)
       {
         return Conn.SingleById<Admin>(id);
       
       }
       
      public Admin UpdateAdmin(Admin admin)
       {
          var result=Conn.Update<Admin>(admin);
          return admin;
       
       }
       
      public void RemoveAdmin(long id)
       {
          Conn.DeleteById<Admin>(id);
       
       }
       
      public Admin GetWithChildren(long id)
       {
          var admin = Conn.SingleById<Admin>(id);
          
          
          
        
                 //One To Many
           var verifyingagents = Conn.Select<VerifyingAgent>().Where(a => a.VerifyingAgentId == id).ToList();
           if (admin != null && verifyingagents != null)
           {
             admin.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
  
         return admin;
         }
       
       
      public Admin SaveAdmin(Admin admin)
      {
          using(var txScope= new TransactionScope())
            {
                if(admin.IsNew)
                {
                    this.AddAdmin(admin);
                }
                else
                {
                    this.UpdateAdmin(admin);
                }
                
                
        
                 //One To Many
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.AdminId =admin.AdminId;
                    Conn.Save(verifyingagent);
                  }
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return admin;
       
       }
       
       public List< Admin> Query(string query)
       {
          return Conn.Select<Admin>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Admin> AddAdminAsync(Admin admin)
       {
          await Conn.InsertAsync(admin);
          admin.AdminId =Conn.LastInsertId();
          return admin;
       
       }
       
      public async Task<List<Admin>> GetAllAdminAsync()
       {
         return await Conn.SelectAsync<Admin>();
       
       }
       
      public async Task<Admin> FindAdminAsync(long id)
       {
         return await Conn.SingleByIdAsync<Admin>(id);
       
       }
       
      public async Task<Admin> UpdateAdminAsync(Admin admin)
       {
          await Conn.UpdateAsync<Admin>(admin);
          return admin;
       
       }
       
      public async Task RemoveAdminAsync(long id)
       {
         await Conn.DeleteByIdAsync<Admin>(id);
       
       }
       
      public async Task<Admin> GetAdminWithChildrenAsync(long id)
       {
          var admin = await Conn.SingleByIdAsync<Admin>(id);
          
          
          
        
                 //One To Many
           var verifyingagents = await Conn.SelectAsync<VerifyingAgent>(e => e.VerifyingAgentId == id);
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
                   await AddAdminAsync(admin);
                }
                else
                {
                   await UpdateAdminAsync(admin);
                }
                
                
        
                 //One To Many
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.AdminId =admin.AdminId;
                    await Conn.SaveAsync(verifyingagent);
                  }
                  foreach(var verifyingagent in admin.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return admin;
       
       }
       
      public async Task<List<Admin>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Admin>(query);
      }
      
      
       #endregion
       
       
       
#region Design Repository
       


      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignAdminsRepository : IAdminsRepository
    {
    
    
       public Admin AddAdmin(Admin admin)
       {
          return null;
       }
       public List< Admin> GetAllAdmin()
       {
           var resultList = new List<Admin>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Admin
                {
                    
                  AdminId = i+12345, 
                  AdminName =  "AdminName"+i, 
                  Password =  "Password"+i, 
                  HireDate =  "HireDate"+i, 
                  ChangeDate =  "ChangeDate"+i, 
                });
            }
            return resultList;
         
       }
       public  Admin FindAdmin(long id)
       {
             return new Admin
                {
                    
                    AdminId =  12345,
                    AdminName =  "AdminName",
                    Password =  "Password",
                    HireDate =  "HireDate",
                    ChangeDate =  "ChangeDate",
                };
       }
       public Admin UpdateAdmin(Admin admin)
       {
         return null;
       }
       public void RemoveAdmin(long id)
       {
          return;
       
       }
       public Admin GetWithChildren(long id)
       {
              
        // One to Many
        var verifyingagent1= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };
        var verifyingagent2= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };         

         
        return new Admin
                {
                    
                    AdminId = 12345,
                    AdminName =  "AdminName",
                    Password =  "Password",
                    HireDate =  "HireDate",
                    ChangeDate =  "ChangeDate",
                    
                     // One to Many
                     VerifyingAgents = new List<VerifyingAgent>{verifyingagent1,verifyingagent2},
                     
                };
         
       }
       public Admin SaveAdmin(Admin admin)
       {
         return null;
       }
       public List< Admin> Query(string query)
       {
          var resultList = new List<Admin>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Admin
                {
                    
                  AdminId = i+12345, 
                  AdminName =  "AdminName"+i, 
                  Password =  "Password"+i, 
                  HireDate =  "HireDate"+i, 
                  ChangeDate =  "ChangeDate"+i, 
                });
            }
            return resultList;
       }
    
      public Task<Admin> AddAdminAsync(Admin admin)
      {
         return null;
      }
      public async Task<List<Admin>> GetAllAdminAsync()
      {
            var resultList = new List<Admin>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Admin
                {
                    
                  AdminId = i+12345, 
                  AdminName =  "AdminName"+i, 
                  Password =  "Password"+i, 
                  HireDate =  "HireDate"+i, 
                  ChangeDate =  "ChangeDate"+i, 
                });
            }
            return resultList;
      }
      public async Task<Admin> FindAdminAsync(long id)
      {
         return new Admin
                {
                    
                    AdminId =  12345,
                    AdminName =  "AdminName",
                    Password =  "Password",
                    HireDate =  "HireDate",
                    ChangeDate =  "ChangeDate",
                };
      }
      public async Task<Admin> UpdateAdminAsync(Admin admin)
      {
        return null;
      }
      public async Task RemoveAdminAsync(long id)
      {
        
      }
       
      public async Task<Admin> GetAdminWithChildrenAsync(long id)
      {
        // One to Many
        var verifyingagent1= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };
        var verifyingagent2= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };         

         
        return new Admin
                {
                    
                    AdminId = 12345,
                    AdminName =  "AdminName",
                    Password =  "Password",
                    HireDate =  "HireDate",
                    ChangeDate =  "ChangeDate",
                    
                     // One to Many
                     VerifyingAgents = new List<VerifyingAgent>{verifyingagent1,verifyingagent2},
                     
                };
         
      }
      public async Task<Admin> SaveAdminAsync(Admin admin)
      {
        return null;
      }
      public async Task<List<Admin>> QueryAsync(string query)
      {
         var resultList = new List<Admin>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Admin
                {
                    
                  AdminId = i+12345, 
                  AdminName =  "AdminName"+i, 
                  Password =  "Password"+i, 
                  HireDate =  "HireDate"+i, 
                  ChangeDate =  "ChangeDate"+i, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}