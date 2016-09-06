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
    public class ElisaTbRepository : IElisaTbsRepository,IDisposable
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

      public async Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb)
       {
          await this.conn.InsertAsync(elisatb);
          elisatb.SerialNo =this.conn.LastInsertId();
          return elisatb;
       
       }
       
      public async Task<List<ElisaTb>> GetAllElisaTbAsync()
       {
         return await this.conn.SelectAsync<ElisaTb>();
       
       }
       
      public async Task<ElisaTb> FindElisaTbAsync(long id)
       {
         return await this.conn.SingleByIdAsync<ElisaTb>(id);
       
       }
       
      public async Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb)
       {
          var result= await this.conn.UpdateAsync<ElisaTb>(elisatb);
          return elisatb;
       
       }
       
      public async Task RemoveElisaTbAsync(long id)
       {
         await this.conn.DeleteByIdAsync<ElisaTb>(id);
       
       }
       
      public async Task<ElisaTb> GetElisaTbWithChildrenAsync(long id)
       {
          var elisatb = await this.conn.SingleByIdAsync<ElisaTb>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (elisatb != null && patient != null)
           {
             elisatb.Patient = patient;
           }
         
  
         return elisatb;
         }
       
       
      public async Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(elisatb.IsNew)
                {
                   await this.AddElisaTbAsync(elisatb);
                }
                else
                {
                   await this.UpdateElisaTbAsync(elisatb);
                }
                
                
                    
                 // One To One 
                 if(elisatb.Patient!=null)
                 {
                    if(elisatb.Patient.IsDeleted)
                    {
                      var id = elisatb.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!elisatb.Patient.IsDeleted)
                    {
                      var patient = elisatb.Patient;
                      patient.PatientID = elisatb.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return elisatb;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}