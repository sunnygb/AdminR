﻿using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;
using ServiceStack.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalReporting.Model.Repository
{    

    public interface IElisaHcvsRepository
    {
       Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv);
       Task<List< ElisaHcv>> GetAllElisaHcvAsync();
       Task<ElisaHcv> FindElisaHcvAsync(long id);
       Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv);
       Task RemoveElisaHcvAsync(long id); 
       
       Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id);
       Task<ElisaHcv> SaveElisaHcvAsync(ElisaHcv elisahcv);
       Task<List<ElisaHcv>> QueryAsync(string query);
       IDbConnection Custom { get;  }
    }


    public class ElisaHcvRepository : IElisaHcvsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public ElisaHcvRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       

      public async Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv)
       {
          await Conn.InsertAsync(elisahcv);
          elisahcv.SerialNo =Conn.LastInsertId();
          return elisahcv;
       
       }
       
      public async Task<List<ElisaHcv>> GetAllElisaHcvAsync()
       {
         return await Conn.SelectAsync<ElisaHcv>();
       
       }
       
      public async Task<ElisaHcv> FindElisaHcvAsync(long id)
       {
         return await Conn.SingleByIdAsync<ElisaHcv>(id);
       
       }
       
      public async Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv)
       {
          await Conn.UpdateAsync<ElisaHcv>(elisahcv);
          return elisahcv;
       
       }
       
      public async Task RemoveElisaHcvAsync(long id)
       {
         await Conn.DeleteByIdAsync<ElisaHcv>(id);
       
       }
       
      public async Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id)
       {
          var elisahcv = await Conn.SingleByIdAsync<ElisaHcv>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
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
                   await AddElisaHcvAsync(elisahcv);
                }
                else
                {
                   await UpdateElisaHcvAsync(elisahcv);
                }
                
                
                    
                 // One To One 
                 if(elisahcv.Patient!=null)
                 {
                    if(elisahcv.Patient.IsDeleted)
                    {
                      var id = elisahcv.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!elisahcv.Patient.IsDeleted)
                    {
                      var patient = elisahcv.Patient;
                      patient.PatientID = elisahcv.SerialNo;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return elisahcv;
       
       }
       
      public async Task<List<ElisaHcv>> QueryAsync(string query)
      {
        var result = await Conn.SelectAsync<ElisaHcv>(query);
        return result;
      }
      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignElisaHcvsRepository : IElisaHcvsRepository
    {
      public Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv)
      {
         return null;
      }
      public async Task<List<ElisaHcv>> GetAllElisaHcvAsync()
      {
            var resultList = new List<ElisaHcv>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaHcv
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientValue = i+12345, 
                  CutOffValue = i+12345, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<ElisaHcv> FindElisaHcvAsync(long id)
      {
         return new ElisaHcv
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientValue =  12345,
                    CutOffValue =  12345,
                    Fee =  12345,
                };
      }
      public async Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv)
      {
        return null;
      }
      public async Task RemoveElisaHcvAsync(long id)
      {
        
      }
       
      public async Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id)
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

         
        return new ElisaHcv
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    PatientValue = 12345,
                    CutOffValue = 12345,
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<ElisaHcv> SaveElisaHcvAsync(ElisaHcv elisahcv)
      {
        return null;
      }
      public async Task<List<ElisaHcv>> QueryAsync(string query)
      {
         return null;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
    
    
    
    
    
    
    
}