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
    public class BiochemistryRepository : IBiochemistriesRepository,IDisposable
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

      public async Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry)
       {
          await this.conn.InsertAsync(biochemistry);
          biochemistry.SerialNo =this.conn.LastInsertId();
          return biochemistry;
       
       }
       
      public async Task<List<Biochemistry>> GetAllBiochemistryAsync()
       {
         return await this.conn.SelectAsync<Biochemistry>();
       
       }
       
      public async Task<Biochemistry> FindBiochemistryAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Biochemistry>(id);
       
       }
       
      public async Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry)
       {
          var result= await this.conn.UpdateAsync<Biochemistry>(biochemistry);
          return biochemistry;
       
       }
       
      public async Task RemoveBiochemistryAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Biochemistry>(id);
       
       }
       
      public async Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id)
       {
          var biochemistry = await this.conn.SingleByIdAsync<Biochemistry>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (biochemistry != null && patient != null)
           {
             biochemistry.Patient = patient;
           }
         
  
         return biochemistry;
         }
       
       
      public async Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(biochemistry.IsNew)
                {
                   await this.AddBiochemistryAsync(biochemistry);
                }
                else
                {
                   await this.UpdateBiochemistryAsync(biochemistry);
                }
                
                
                    
                 // One To One 
                 if(biochemistry.Patient!=null)
                 {
                    if(biochemistry.Patient.IsDeleted)
                    {
                      var id = biochemistry.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!biochemistry.Patient.IsDeleted)
                    {
                      var patient = biochemistry.Patient;
                      patient.PatientID = biochemistry.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return biochemistry;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}