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
    public class SemenAnalysisRepository : ISemenAnalysesRepository,IDisposable
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

      public async Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis)
       {
          await this.conn.InsertAsync(semenanalysis);
          semenanalysis.SerialNo =this.conn.LastInsertId();
          return semenanalysis;
       
       }
       
      public async Task<List<SemenAnalysis>> GetAllSemenAnalysisAsync()
       {
         return await this.conn.SelectAsync<SemenAnalysis>();
       
       }
       
      public async Task<SemenAnalysis> FindSemenAnalysisAsync(long id)
       {
         return await this.conn.SingleByIdAsync<SemenAnalysis>(id);
       
       }
       
      public async Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis)
       {
          var result= await this.conn.UpdateAsync<SemenAnalysis>(semenanalysis);
          return semenanalysis;
       
       }
       
      public async Task RemoveSemenAnalysisAsync(long id)
       {
         await this.conn.DeleteByIdAsync<SemenAnalysis>(id);
       
       }
       
      public async Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id)
       {
          var semenanalysis = await this.conn.SingleByIdAsync<SemenAnalysis>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (semenanalysis != null && patient != null)
           {
             semenanalysis.Patient = patient;
           }
         
  
         return semenanalysis;
         }
       
       
      public async Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(semenanalysis.IsNew)
                {
                   await this.AddSemenAnalysisAsync(semenanalysis);
                }
                else
                {
                   await this.UpdateSemenAnalysisAsync(semenanalysis);
                }
                
                
                    
                 // One To One 
                 if(semenanalysis.Patient!=null)
                 {
                    if(semenanalysis.Patient.IsDeleted)
                    {
                      var id = semenanalysis.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!semenanalysis.Patient.IsDeleted)
                    {
                      var patient = semenanalysis.Patient;
                      patient.PatientID = semenanalysis.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return semenanalysis;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}