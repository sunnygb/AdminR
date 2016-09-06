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
    public class UrineExaminationRepository : IUrineExaminationsRepository,IDisposable
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

      public async Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination)
       {
          await this.conn.InsertAsync(urineexamination);
          urineexamination.SerialNo =this.conn.LastInsertId();
          return urineexamination;
       
       }
       
      public async Task<List<UrineExamination>> GetAllUrineExaminationAsync()
       {
         return await this.conn.SelectAsync<UrineExamination>();
       
       }
       
      public async Task<UrineExamination> FindUrineExaminationAsync(long id)
       {
         return await this.conn.SingleByIdAsync<UrineExamination>(id);
       
       }
       
      public async Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination)
       {
          var result= await this.conn.UpdateAsync<UrineExamination>(urineexamination);
          return urineexamination;
       
       }
       
      public async Task RemoveUrineExaminationAsync(long id)
       {
         await this.conn.DeleteByIdAsync<UrineExamination>(id);
       
       }
       
      public async Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id)
       {
          var urineexamination = await this.conn.SingleByIdAsync<UrineExamination>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (urineexamination != null && patient != null)
           {
             urineexamination.Patient = patient;
           }
         
  
         return urineexamination;
         }
       
       
      public async Task<UrineExamination> SaveUrineExaminationAsync(UrineExamination urineexamination)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(urineexamination.IsNew)
                {
                   await this.AddUrineExaminationAsync(urineexamination);
                }
                else
                {
                   await this.UpdateUrineExaminationAsync(urineexamination);
                }
                
                
                    
                 // One To One 
                 if(urineexamination.Patient!=null)
                 {
                    if(urineexamination.Patient.IsDeleted)
                    {
                      var id = urineexamination.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!urineexamination.Patient.IsDeleted)
                    {
                      var patient = urineexamination.Patient;
                      patient.PatientID = urineexamination.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return urineexamination;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}