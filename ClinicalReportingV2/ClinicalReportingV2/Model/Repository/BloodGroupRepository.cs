using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using ClinicalReporting.Data.Services;
using System.Text;
using System.Transactions;
using System.Linq;
using ServiceStack.Data;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Repository
{    
    public class BloodGroupRepository : IBloodGroupsRepository,IDisposable
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

      public async Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup)
       {
          await this.conn.InsertAsync(bloodgroup);
          bloodgroup.SerialNo =this.conn.LastInsertId();
          return bloodgroup;
       
       }
       
      public async Task<List<BloodGroup>> GetAllBloodGroupAsync()
       {
         return await this.conn.SelectAsync<BloodGroup>();
       
       }
       
      public async Task<BloodGroup> FindBloodGroupAsync(long id)
       {
         return await this.conn.SingleByIdAsync<BloodGroup>(id);
       
       }
       
      public async Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup)
       {
          var result= await this.conn.UpdateAsync<BloodGroup>(bloodgroup);
          return bloodgroup;
       
       }
       
      public async Task RemoveBloodGroupAsync(long id)
       {
         await this.conn.DeleteByIdAsync<BloodGroup>(id);
       
       }
       
      public async Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id)
       {
          var bloodgroup = await this.conn.SingleByIdAsync<BloodGroup>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
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
                   await this.AddBloodGroupAsync(bloodgroup);
                }
                else
                {
                   await this.UpdateBloodGroupAsync(bloodgroup);
                }
                
                
                    
                 // One To One 
                 if(bloodgroup.Patient!=null)
                 {
                    if(bloodgroup.Patient.IsDeleted)
                    {
                      var id = bloodgroup.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!bloodgroup.Patient.IsDeleted)
                    {
                      var patient = bloodgroup.Patient;
                      patient.PatientID = bloodgroup.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return bloodgroup;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}