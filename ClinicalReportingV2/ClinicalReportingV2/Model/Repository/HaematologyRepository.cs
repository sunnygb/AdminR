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
    public class HaematologyRepository : IHaematologiesRepository,IDisposable
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

      public async Task<Haematology> AddHaematologyAsync(Haematology haematology)
       {
          await this.conn.InsertAsync(haematology);
          haematology.SerialNo =this.conn.LastInsertId();
          return haematology;
       
       }
       
      public async Task<List<Haematology>> GetAllHaematologyAsync()
       {
         return await this.conn.SelectAsync<Haematology>();
       
       }
       
      public async Task<Haematology> FindHaematologyAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Haematology>(id);
       
       }
       
      public async Task<Haematology> UpdateHaematologyAsync(Haematology haematology)
       {
          var result= await this.conn.UpdateAsync<Haematology>(haematology);
          return haematology;
       
       }
       
      public async Task RemoveHaematologyAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Haematology>(id);
       
       }
       
      public async Task<Haematology> GetHaematologyWithChildrenAsync(long id)
       {
          var haematology = await this.conn.SingleByIdAsync<Haematology>(id);
          
          
          
   
                 // One To One 
           var patient = await this.conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (haematology != null && patient != null)
           {
             haematology.Patient = patient;
           }
         
  
         return haematology;
         }
       
       
      public async Task<Haematology> SaveHaematologyAsync(Haematology haematology)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(haematology.IsNew)
                {
                   await this.AddHaematologyAsync(haematology);
                }
                else
                {
                   await this.UpdateHaematologyAsync(haematology);
                }
                
                
                    
                 // One To One 
                 if(haematology.Patient!=null)
                 {
                    if(haematology.Patient.IsDeleted)
                    {
                      var id = haematology.Patient.PatientID;
                      await this._conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!haematology.Patient.IsDeleted)
                    {
                      var patient = haematology.Patient;
                      patient.PatientID = haematology.SerialNo;
                      await this.conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return haematology;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}