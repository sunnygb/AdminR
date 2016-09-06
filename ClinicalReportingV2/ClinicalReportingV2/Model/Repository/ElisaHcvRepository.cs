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
    public class ElisaHcvRepository : IElisaHcvsRepository,IDisposable
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

      public async Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv)
       {
          await this.conn.InsertAsync(elisahcv);
          elisahcv.SerialNo =this.conn.LastInsertId();
          return elisahcv;
       
       }
       
      public async Task<List<ElisaHcv>> GetAllElisaHcvAsync()
       {
         return await this.conn.SelectAsync<ElisaHcv>();
       
       }
       
      public async Task<ElisaHcv> FindElisaHcvAsync(long id)
       {
         return await this.conn.SingleByIdAsync<ElisaHcv>(id);
       
       }
       
      public async Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv)
       {
          var result= await this.conn.UpdateAsync<ElisaHcv>(elisahcv);
          return elisahcv;
       
       }
       
      public async Task RemoveElisaHcvAsync(long id)
       {
         await this.conn.DeleteByIdAsync<ElisaHcv>(id);
       
       }
       
      public async Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id)
       {
          var elisahcv = await this.conn.SingleByIdAsync<ElisaHcv>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (elisahcv != null && patient != null)
           {
             elisahcv.Patient = patient;
           }
         
  
         return elisahcv;
         }
       
       
      public async Task<ElisaHcv> SaveElisaHcvAsync(ElisaHcv elisahcv)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(elisahcv.IsNew)
                {
                   await this.AddElisaHcvAsync(elisahcv);
                }
                else
                {
                   await this.UpdateElisaHcvAsync(elisahcv);
                }
                
                
                    
                 // One To One 
                 if(elisahcv.Patient!=null)
                 {
                    if(elisahcv.Patient.IsDeleted)
                    {
                      var id = elisahcv.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!elisahcv.Patient.IsDeleted)
                    {
                      var patient = elisahcv.Patient;
                      patient.PatientID = elisahcv.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return elisahcv;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}