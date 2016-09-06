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
    public class ElisaHbsagRepository : IElisaHbsagsRepository,IDisposable
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

      public async Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag)
       {
          await this.conn.InsertAsync(elisahbsag);
          elisahbsag.SerialNo =this.conn.LastInsertId();
          return elisahbsag;
       
       }
       
      public async Task<List<ElisaHbsag>> GetAllElisaHbsagAsync()
       {
         return await this.conn.SelectAsync<ElisaHbsag>();
       
       }
       
      public async Task<ElisaHbsag> FindElisaHbsagAsync(long id)
       {
         return await this.conn.SingleByIdAsync<ElisaHbsag>(id);
       
       }
       
      public async Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag)
       {
          var result= await this.conn.UpdateAsync<ElisaHbsag>(elisahbsag);
          return elisahbsag;
       
       }
       
      public async Task RemoveElisaHbsagAsync(long id)
       {
         await this.conn.DeleteByIdAsync<ElisaHbsag>(id);
       
       }
       
      public async Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id)
       {
          var elisahbsag = await this.conn.SingleByIdAsync<ElisaHbsag>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (elisahbsag != null && patient != null)
           {
             elisahbsag.Patient = patient;
           }
         
  
         return elisahbsag;
         }
       
       
      public async Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(elisahbsag.IsNew)
                {
                   await this.AddElisaHbsagAsync(elisahbsag);
                }
                else
                {
                   await this.UpdateElisaHbsagAsync(elisahbsag);
                }
                
                
                    
                 // One To One 
                 if(elisahbsag.Patient!=null)
                 {
                    if(elisahbsag.Patient.IsDeleted)
                    {
                      var id = elisahbsag.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!elisahbsag.Patient.IsDeleted)
                    {
                      var patient = elisahbsag.Patient;
                      patient.PatientID = elisahbsag.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return elisahbsag;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}