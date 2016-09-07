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
    public class SerologyRepository : ISerologiesRepository,IDisposable
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

      public async Task<Serology> AddSerologyAsync(Serology serology)
       {
          await this.conn.InsertAsync(serology);
          serology.Serialno =this.conn.LastInsertId();
          return serology;
       
       }
       
      public async Task<List<Serology>> GetAllSerologyAsync()
       {
         return await this.conn.SelectAsync<Serology>();
       
       }
       
      public async Task<Serology> FindSerologyAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Serology>(id);
       
       }
       
      public async Task<Serology> UpdateSerologyAsync(Serology serology)
       {
          var result= await this.conn.UpdateAsync<Serology>(serology);
          return serology;
       
       }
       
      public async Task RemoveSerologyAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Serology>(id);
       
       }
       
      public async Task<Serology> GetSerologyWithChildrenAsync(long id)
       {
          var serology = await this.conn.SingleByIdAsync<Serology>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (serology != null && patient != null)
           {
             serology.Patient = patient;
           }
         
  
         return serology;
         }
       
       
      public async Task<Serology> SaveSerologyAsync(Serology serology)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(serology.IsNew)
                {
                   await this.AddSerologyAsync(serology);
                }
                else
                {
                   await this.UpdateSerologyAsync(serology);
                }
                
                
                    
                 // One To One 
                 if(serology.Patient!=null)
                 {
                    if(serology.Patient.IsDeleted)
                    {
                      var id = serology.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!serology.Patient.IsDeleted)
                    {
                      var patient = serology.Patient;
                      patient.PatientID = serology.Serialno;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return serology;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}