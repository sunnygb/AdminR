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

    public interface IVerifyingAgentsRepository
    {
       Task<VerifyingAgent> AddVerifyingAgentAsync(VerifyingAgent verifyingagent);
       Task<List< VerifyingAgent>> GetAllVerifyingAgentAsync();
       Task<VerifyingAgent> FindVerifyingAgentAsync(long id);
       Task<VerifyingAgent> UpdateVerifyingAgentAsync(VerifyingAgent verifyingagent);
       Task RemoveVerifyingAgentAsync(long id); 
       Task<VerifyingAgent> GetVerifyingAgentWithChildrenAsync(long id);
       Task<VerifyingAgent> SaveVerifyingAgentAsync(VerifyingAgent verifyingagent);
       Task<List<VerifyingAgent>> QueryAsync(string query);
       
       VerifyingAgent AddVerifyingAgent(VerifyingAgent verifyingagent);
       List< VerifyingAgent> GetAllVerifyingAgent();
       VerifyingAgent FindVerifyingAgent(long id);
       VerifyingAgent UpdateVerifyingAgent(VerifyingAgent verifyingagent);
       void RemoveVerifyingAgent(long id); 
       VerifyingAgent GetWithChildren(long id);
       VerifyingAgent SaveVerifyingAgent(VerifyingAgent verifyingagent);
       List< VerifyingAgent> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class VerifyingAgentRepository : IVerifyingAgentsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public VerifyingAgentRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public VerifyingAgent AddVerifyingAgent(VerifyingAgent verifyingagent)
       {
          this.Conn.Insert(verifyingagent);
          verifyingagent.VerifyingAgentId =this.Conn.LastInsertId();
          return verifyingagent;
       
       }
       
      public List<VerifyingAgent> GetAllVerifyingAgent()
       {
         return Conn.Select<VerifyingAgent>();
       
       }
       
      public VerifyingAgent FindVerifyingAgent(long id)
       {
         return Conn.SingleById<VerifyingAgent>(id);
       
       }
       
      public VerifyingAgent UpdateVerifyingAgent(VerifyingAgent verifyingagent)
       {
          var result=Conn.Update<VerifyingAgent>(verifyingagent);
          return verifyingagent;
       
       }
       
      public void RemoveVerifyingAgent(long id)
       {
          Conn.DeleteById<VerifyingAgent>(id);
       
       }
       
      public VerifyingAgent GetWithChildren(long id)
       {
          var verifyingagent = Conn.SingleById<VerifyingAgent>(id);
          
          
          
   
                 // One To One 
           var admin = Conn.Select<Admin>().Where(a => a.AdminId == id).SingleOrDefault();
           if (verifyingagent != null && admin != null)
           {
             verifyingagent.Admin = admin;
           }
         
   
                 // One To One 
           var student = Conn.Select<Student>().Where(a => a.StudentId == id).SingleOrDefault();
           if (verifyingagent != null && student != null)
           {
             verifyingagent.Student = student;
           }
         
  
         return verifyingagent;
         }
       
       
      public VerifyingAgent SaveVerifyingAgent(VerifyingAgent verifyingagent)
      {
          using(var txScope= new TransactionScope())
            {
                if(verifyingagent.IsNew)
                {
                    this.AddVerifyingAgent(verifyingagent);
                }
                else
                {
                    this.UpdateVerifyingAgent(verifyingagent);
                }
                
                
                    
                    
                 // One To One 
                 if(verifyingagent.Admin !=null)
                 {
                    var admin = verifyingagent.Admin;
                    admin.AdminId = verifyingagent.VerifyingAgentId;
                    Conn.Save(admin);
                 }
                    
                    
                 // One To One 
                 if(verifyingagent.Student !=null)
                 {
                    var student = verifyingagent.Student;
                    student.StudentId = verifyingagent.VerifyingAgentId;
                    Conn.Save(student);
                 }
                 
                   
                    txScope.Complete();
            }
            return verifyingagent;
       
       }
       
       public List< VerifyingAgent> Query(string query)
       {
          return Conn.Select<VerifyingAgent>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<VerifyingAgent> AddVerifyingAgentAsync(VerifyingAgent verifyingagent)
       {
          await Conn.InsertAsync(verifyingagent);
          verifyingagent.VerifyingAgentId =Conn.LastInsertId();
          return verifyingagent;
       
       }
       
      public async Task<List<VerifyingAgent>> GetAllVerifyingAgentAsync()
       {
         return await Conn.SelectAsync<VerifyingAgent>();
       
       }
       
      public async Task<VerifyingAgent> FindVerifyingAgentAsync(long id)
       {
         return await Conn.SingleByIdAsync<VerifyingAgent>(id);
       
       }
       
      public async Task<VerifyingAgent> UpdateVerifyingAgentAsync(VerifyingAgent verifyingagent)
       {
          await Conn.UpdateAsync<VerifyingAgent>(verifyingagent);
          return verifyingagent;
       
       }
       
      public async Task RemoveVerifyingAgentAsync(long id)
       {
         await Conn.DeleteByIdAsync<VerifyingAgent>(id);
       
       }
       
      public async Task<VerifyingAgent> GetVerifyingAgentWithChildrenAsync(long id)
       {
          var verifyingagent = await Conn.SingleByIdAsync<VerifyingAgent>(id);
          
          
          
   
                 // One To One 
           var admin = await Conn.SingleAsync<Admin>(e => e.AdminId == id);
           if (verifyingagent != null && admin != null)
           {
             verifyingagent.Admin = admin;
           }
         
   
                 // One To One 
           var student = await Conn.SingleAsync<Student>(e => e.StudentId == id);
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
                   await AddVerifyingAgentAsync(verifyingagent);
                }
                else
                {
                   await UpdateVerifyingAgentAsync(verifyingagent);
                }
                
                
                    
                 // One To One 
                 if(verifyingagent.Admin!=null)
                 {
                    if(verifyingagent.Admin.IsDeleted)
                    {
                      var id = verifyingagent.Admin.AdminId;
                      await Conn.DeleteByIdAsync<Admin>(id);
                    }
                    else if(!verifyingagent.Admin.IsDeleted)
                    {
                      var admin = verifyingagent.Admin;
                      admin.AdminId = verifyingagent.VerifyingAgentId;
                      await Conn.SaveAsync(admin);
                    }
                    
                  }
                    
                 // One To One 
                 if(verifyingagent.Student!=null)
                 {
                    if(verifyingagent.Student.IsDeleted)
                    {
                      var id = verifyingagent.Student.StudentId;
                      await Conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!verifyingagent.Student.IsDeleted)
                    {
                      var student = verifyingagent.Student;
                      student.StudentId = verifyingagent.VerifyingAgentId;
                      await Conn.SaveAsync(student);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return verifyingagent;
       
       }
       
      public async Task<List<VerifyingAgent>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<VerifyingAgent>(query);
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
    
    public class DesignVerifyingAgentsRepository : IVerifyingAgentsRepository
    {
    
    
       public VerifyingAgent AddVerifyingAgent(VerifyingAgent verifyingagent)
       {
          return null;
       }
       public List< VerifyingAgent> GetAllVerifyingAgent()
       {
           var resultList = new List<VerifyingAgent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new VerifyingAgent
                {
                    
                  VerifyingAgentId = i+12345, 
                  VerifyingAgentName =  "VerifyingAgentName"+i, 
                  DegreeVerification =  "DegreeVerification"+i, 
                  AdminId = i+12345, 
                  SendDate =  "SendDate"+i, 
                  ReciveDate =  "ReciveDate"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
         
       }
       public  VerifyingAgent FindVerifyingAgent(long id)
       {
             return new VerifyingAgent
                {
                    
                    VerifyingAgentId =  12345,
                    VerifyingAgentName =  "VerifyingAgentName",
                    DegreeVerification =  "DegreeVerification",
                    AdminId =  12345,
                    SendDate =  "SendDate",
                    ReciveDate =  "ReciveDate",
                    StudentId =  12345,
                };
       }
       public VerifyingAgent UpdateVerifyingAgent(VerifyingAgent verifyingagent)
       {
         return null;
       }
       public void RemoveVerifyingAgent(long id)
       {
          return;
       
       }
       public VerifyingAgent GetWithChildren(long id)
       {
              
        //One to One
        var admin = new Admin 
        {
        AdminId = 12345, 
                AdminName =  "AdminName", 
                Password =  "Password", 
                HireDate =  "HireDate", 
                ChangeDate =  "ChangeDate", 
        };

        //One to One
        var student = new Student 
        {
        StudentId = 12345, 
                StudentName =  "StudentName", 
                StudentEmail =  "StudentEmail", 
                FatherName =  "FatherName", 
                FatherMonthlyIncome =  "FatherMonthlyIncome", 
                FatherOccupation =  "FatherOccupation", 
                PostalAddress =  "PostalAddress", 
                PermanentAddress =  "PermanentAddress", 
                DateOfBirth =  "DateOfBirth", 
                NICNo =  "NICNo", 
                BloodGroup =  "BloodGroup", 
                PhoneNumber =  "PhoneNumber", 
                ResidentalPhoneNumber =  "ResidentalPhoneNumber", 
                Date =  "Date", 
                FathersNumber =  "FathersNumber", 
        };

         
        return new VerifyingAgent
                {
                    
                    VerifyingAgentId = 12345,
                    VerifyingAgentName =  "VerifyingAgentName",
                    DegreeVerification =  "DegreeVerification",
                    AdminId = 12345,
                    SendDate =  "SendDate",
                    ReciveDate =  "ReciveDate",
                    StudentId = 12345,
                    
                     //One to One
                     Admin = admin,
                     //One to One
                     Student = student,
                     
                };
         
       }
       public VerifyingAgent SaveVerifyingAgent(VerifyingAgent verifyingagent)
       {
         return null;
       }
       public List< VerifyingAgent> Query(string query)
       {
          var resultList = new List<VerifyingAgent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new VerifyingAgent
                {
                    
                  VerifyingAgentId = i+12345, 
                  VerifyingAgentName =  "VerifyingAgentName"+i, 
                  DegreeVerification =  "DegreeVerification"+i, 
                  AdminId = i+12345, 
                  SendDate =  "SendDate"+i, 
                  ReciveDate =  "ReciveDate"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
       }
    
      public Task<VerifyingAgent> AddVerifyingAgentAsync(VerifyingAgent verifyingagent)
      {
         return null;
      }
      public async Task<List<VerifyingAgent>> GetAllVerifyingAgentAsync()
      {
            var resultList = new List<VerifyingAgent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new VerifyingAgent
                {
                    
                  VerifyingAgentId = i+12345, 
                  VerifyingAgentName =  "VerifyingAgentName"+i, 
                  DegreeVerification =  "DegreeVerification"+i, 
                  AdminId = i+12345, 
                  SendDate =  "SendDate"+i, 
                  ReciveDate =  "ReciveDate"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<VerifyingAgent> FindVerifyingAgentAsync(long id)
      {
         return new VerifyingAgent
                {
                    
                    VerifyingAgentId =  12345,
                    VerifyingAgentName =  "VerifyingAgentName",
                    DegreeVerification =  "DegreeVerification",
                    AdminId =  12345,
                    SendDate =  "SendDate",
                    ReciveDate =  "ReciveDate",
                    StudentId =  12345,
                };
      }
      public async Task<VerifyingAgent> UpdateVerifyingAgentAsync(VerifyingAgent verifyingagent)
      {
        return null;
      }
      public async Task RemoveVerifyingAgentAsync(long id)
      {
        
      }
       
      public async Task<VerifyingAgent> GetVerifyingAgentWithChildrenAsync(long id)
      {
        //One to One
        var admin = new Admin 
        {
        AdminId = 12345, 
                AdminName =  "AdminName", 
                Password =  "Password", 
                HireDate =  "HireDate", 
                ChangeDate =  "ChangeDate", 
        };

        //One to One
        var student = new Student 
        {
        StudentId = 12345, 
                StudentName =  "StudentName", 
                StudentEmail =  "StudentEmail", 
                FatherName =  "FatherName", 
                FatherMonthlyIncome =  "FatherMonthlyIncome", 
                FatherOccupation =  "FatherOccupation", 
                PostalAddress =  "PostalAddress", 
                PermanentAddress =  "PermanentAddress", 
                DateOfBirth =  "DateOfBirth", 
                NICNo =  "NICNo", 
                BloodGroup =  "BloodGroup", 
                PhoneNumber =  "PhoneNumber", 
                ResidentalPhoneNumber =  "ResidentalPhoneNumber", 
                Date =  "Date", 
                FathersNumber =  "FathersNumber", 
        };

         
        return new VerifyingAgent
                {
                    
                    VerifyingAgentId = 12345,
                    VerifyingAgentName =  "VerifyingAgentName",
                    DegreeVerification =  "DegreeVerification",
                    AdminId = 12345,
                    SendDate =  "SendDate",
                    ReciveDate =  "ReciveDate",
                    StudentId = 12345,
                    
                     //One to One
                     Admin = admin,
                     //One to One
                     Student = student,
                     
                };
         
      }
      public async Task<VerifyingAgent> SaveVerifyingAgentAsync(VerifyingAgent verifyingagent)
      {
        return null;
      }
      public async Task<List<VerifyingAgent>> QueryAsync(string query)
      {
         var resultList = new List<VerifyingAgent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new VerifyingAgent
                {
                    
                  VerifyingAgentId = i+12345, 
                  VerifyingAgentName =  "VerifyingAgentName"+i, 
                  DegreeVerification =  "DegreeVerification"+i, 
                  AdminId = i+12345, 
                  SendDate =  "SendDate"+i, 
                  ReciveDate =  "ReciveDate"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}