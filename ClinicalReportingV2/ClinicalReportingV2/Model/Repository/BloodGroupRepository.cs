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

    public interface IBloodGroupsRepository
    {
       Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup);
       Task<List< BloodGroup>> GetAllBloodGroupAsync();
       Task<BloodGroup> FindBloodGroupAsync(long id);
       Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup);
       Task RemoveBloodGroupAsync(long id); 
       Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id);
       Task<BloodGroup> SaveBloodGroupAsync(BloodGroup bloodgroup);
       Task<List<BloodGroup>> QueryAsync(string query);
       
       BloodGroup AddBloodGroup(BloodGroup bloodgroup);
       List< BloodGroup> GetAllBloodGroup();
       BloodGroup FindBloodGroup(long id);
       BloodGroup UpdateBloodGroup(BloodGroup bloodgroup);
       void RemoveBloodGroup(long id); 
       BloodGroup GetWithChildren(long id);
       BloodGroup SaveBloodGroup(BloodGroup bloodgroup);
       List< BloodGroup> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class BloodGroupRepository : IBloodGroupsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public BloodGroupRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public BloodGroup AddBloodGroup(BloodGroup bloodgroup)
       {
          this.Conn.Insert(bloodgroup);
          bloodgroup.SerialNo =this.Conn.LastInsertId();
          return bloodgroup;
       
       }
       
      public List<BloodGroup> GetAllBloodGroup()
       {
         return Conn.Select<BloodGroup>();
       
       }
       
      public BloodGroup FindBloodGroup(long id)
       {
         return Conn.SingleById<BloodGroup>(id);
       
       }
       
      public BloodGroup UpdateBloodGroup(BloodGroup bloodgroup)
       {
          var result=Conn.Update<BloodGroup>(bloodgroup);
          return bloodgroup;
       
       }
       
      public void RemoveBloodGroup(long id)
       {
          Conn.DeleteById<BloodGroup>(id);
       
       }
       
      public BloodGroup GetWithChildren(long id)
       {
          var bloodgroup = Conn.SingleById<BloodGroup>(id);
          
          
          
   
                 // One To One 
           var patient = Conn.Select<Patient>().Where(a => a.PatientID == id).SingleOrDefault();
           if (bloodgroup != null && patient != null)
           {
             bloodgroup.Patient = patient;
           }
         
  
         return bloodgroup;
         }
       
       
      public BloodGroup SaveBloodGroup(BloodGroup bloodgroup)
      {
          using(var txScope= new TransactionScope())
            {
                if(bloodgroup.IsNew)
                {
                    this.AddBloodGroup(bloodgroup);
                }
                else
                {
                    this.UpdateBloodGroup(bloodgroup);
                }
                
                
                    
                    
                 // One To One 
                 if(bloodgroup.Patient !=null)
                 {
                    var patient = bloodgroup.Patient;
                    patient.PatientID = bloodgroup.SerialNo;
                    Conn.Save(patient);
                 }
                 
                   
                    txScope.Complete();
            }
            return bloodgroup;
       
       }
       
       public List< BloodGroup> Query(string query)
       {
          return Conn.Select<BloodGroup>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup)
       {
          await Conn.InsertAsync(bloodgroup);
          bloodgroup.SerialNo =Conn.LastInsertId();
          return bloodgroup;
       
       }
       
      public async Task<List<BloodGroup>> GetAllBloodGroupAsync()
       {
         return await Conn.SelectAsync<BloodGroup>();
       
       }
       
      public async Task<BloodGroup> FindBloodGroupAsync(long id)
       {
         return await Conn.SingleByIdAsync<BloodGroup>(id);
       
       }
       
      public async Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup)
       {
          await Conn.UpdateAsync<BloodGroup>(bloodgroup);
          return bloodgroup;
       
       }
       
      public async Task RemoveBloodGroupAsync(long id)
       {
         await Conn.DeleteByIdAsync<BloodGroup>(id);
       
       }
       
      public async Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id)
       {
          var bloodgroup = await Conn.SingleByIdAsync<BloodGroup>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (bloodgroup != null && patient != null)
           {
             bloodgroup.Patient = patient;
           }
         
  
         return bloodgroup;
         }
       
       
      public async Task<BloodGroup> SaveBloodGroupAsync(BloodGroup bloodgroup)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(bloodgroup.IsNew)
                {
                   await AddBloodGroupAsync(bloodgroup);
                }
                else
                {
                   await UpdateBloodGroupAsync(bloodgroup);
                }
                
                
                    
                 // One To One 
                 if(bloodgroup.Patient!=null)
                 {
                    if(bloodgroup.Patient.IsDeleted)
                    {
                      var id = bloodgroup.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!bloodgroup.Patient.IsDeleted)
                    {
                      var patient = bloodgroup.Patient;
                      patient.PatientID = bloodgroup.SerialNo;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return bloodgroup;
       
       }
       
      public async Task<List<BloodGroup>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<BloodGroup>(query);
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
    
    public class DesignBloodGroupsRepository : IBloodGroupsRepository
    {
    
    
       public BloodGroup AddBloodGroup(BloodGroup bloodgroup)
       {
          return null;
       }
       public List< BloodGroup> GetAllBloodGroup()
       {
           var resultList = new List<BloodGroup>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new BloodGroup
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientBloodGroup =  "PatientBloodGroup"+i, 
                  DonarName =  "DonarName"+i, 
                  DonarBloodGroup =  "DonarBloodGroup"+i, 
                  HbsAg =  "HbsAg"+i, 
                  AntiHCV =  "AntiHCV"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
         
       }
       public  BloodGroup FindBloodGroup(long id)
       {
             return new BloodGroup
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientBloodGroup =  "PatientBloodGroup",
                    DonarName =  "DonarName",
                    DonarBloodGroup =  "DonarBloodGroup",
                    HbsAg =  "HbsAg",
                    AntiHCV =  "AntiHCV",
                    Fee =  12345,
                };
       }
       public BloodGroup UpdateBloodGroup(BloodGroup bloodgroup)
       {
         return null;
       }
       public void RemoveBloodGroup(long id)
       {
          return;
       
       }
       public BloodGroup GetWithChildren(long id)
       {
              
        //One to One
        var patient = new Patient 
        {
        PatientID = 12345, 
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new BloodGroup
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    PatientBloodGroup =  "PatientBloodGroup",
                    DonarName =  "DonarName",
                    DonarBloodGroup =  "DonarBloodGroup",
                    HbsAg =  "HbsAg",
                    AntiHCV =  "AntiHCV",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
       }
       public BloodGroup SaveBloodGroup(BloodGroup bloodgroup)
       {
         return null;
       }
       public List< BloodGroup> Query(string query)
       {
          var resultList = new List<BloodGroup>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new BloodGroup
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientBloodGroup =  "PatientBloodGroup"+i, 
                  DonarName =  "DonarName"+i, 
                  DonarBloodGroup =  "DonarBloodGroup"+i, 
                  HbsAg =  "HbsAg"+i, 
                  AntiHCV =  "AntiHCV"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
       }
    
      public Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup)
      {
         return null;
      }
      public async Task<List<BloodGroup>> GetAllBloodGroupAsync()
      {
            var resultList = new List<BloodGroup>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new BloodGroup
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientBloodGroup =  "PatientBloodGroup"+i, 
                  DonarName =  "DonarName"+i, 
                  DonarBloodGroup =  "DonarBloodGroup"+i, 
                  HbsAg =  "HbsAg"+i, 
                  AntiHCV =  "AntiHCV"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<BloodGroup> FindBloodGroupAsync(long id)
      {
         return new BloodGroup
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientBloodGroup =  "PatientBloodGroup",
                    DonarName =  "DonarName",
                    DonarBloodGroup =  "DonarBloodGroup",
                    HbsAg =  "HbsAg",
                    AntiHCV =  "AntiHCV",
                    Fee =  12345,
                };
      }
      public async Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup)
      {
        return null;
      }
      public async Task RemoveBloodGroupAsync(long id)
      {
        
      }
       
      public async Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id)
      {
        //One to One
        var patient = new Patient 
        {
        PatientID = 12345, 
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new BloodGroup
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    PatientBloodGroup =  "PatientBloodGroup",
                    DonarName =  "DonarName",
                    DonarBloodGroup =  "DonarBloodGroup",
                    HbsAg =  "HbsAg",
                    AntiHCV =  "AntiHCV",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<BloodGroup> SaveBloodGroupAsync(BloodGroup bloodgroup)
      {
        return null;
      }
      public async Task<List<BloodGroup>> QueryAsync(string query)
      {
         var resultList = new List<BloodGroup>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new BloodGroup
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientBloodGroup =  "PatientBloodGroup"+i, 
                  DonarName =  "DonarName"+i, 
                  DonarBloodGroup =  "DonarBloodGroup"+i, 
                  HbsAg =  "HbsAg"+i, 
                  AntiHCV =  "AntiHCV"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}