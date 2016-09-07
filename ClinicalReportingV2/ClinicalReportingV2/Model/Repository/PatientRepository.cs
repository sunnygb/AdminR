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
    public class PatientRepository : IPatientsRepository,IDisposable
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

      public async Task<Patient> AddPatientAsync(Patient patient)
       {
          await this.conn.InsertAsync(patient);
          patient.PatientID =this.conn.LastInsertId();
          return patient;
       
       }
       
      public async Task<List<Patient>> GetAllPatientAsync()
       {
         return await this.conn.SelectAsync<Patient>();
       
       }
       
      public async Task<Patient> FindPatientAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Patient>(id);
       
       }
       
      public async Task<Patient> UpdatePatientAsync(Patient patient)
       {
          var result= await this.conn.UpdateAsync<Patient>(patient);
          return patient;
       
       }
       
      public async Task RemovePatientAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Patient>(id);
       
       }
       
      public async Task<Patient> GetPatientWithChildrenAsync(long id)
       {
          var patient = await this.conn.SingleByIdAsync<Patient>(id);
          
          
          
        
                 //One To Many
           var haematologies = await this.conn.SelectAsync<Haematology>(e => e.SerialNo == id);
           if (patient != null && haematologies != null)
           {
             patient.Haematologies.AddRange(haematologies);
           }      
                  
                  
                  
        
                 //One To Many
           var elisatbs = await this.conn.SelectAsync<ElisaTb>(e => e.SerialNo == id);
           if (patient != null && elisatbs != null)
           {
             patient.ElisaTbs.AddRange(elisatbs);
           }      
                  
                  
                  
        
                 //One To Many
           var elisahcvs = await this.conn.SelectAsync<ElisaHcv>(e => e.SerialNo == id);
           if (patient != null && elisahcvs != null)
           {
             patient.ElisaHcvs.AddRange(elisahcvs);
           }      
                  
                  
                  
        
                 //One To Many
           var elisahbsags = await this.conn.SelectAsync<ElisaHbsag>(e => e.SerialNo == id);
           if (patient != null && elisahbsags != null)
           {
             patient.ElisaHbsags.AddRange(elisahbsags);
           }      
                  
                  
                  
        
                 //One To Many
           var bloodgroups = await this.conn.SelectAsync<BloodGroup>(e => e.SerialNo == id);
           if (patient != null && bloodgroups != null)
           {
             patient.BloodGroups.AddRange(bloodgroups);
           }      
                  
                  
                  
        
                 //One To Many
           var biochemistries = await this.conn.SelectAsync<Biochemistry>(e => e.SerialNo == id);
           if (patient != null && biochemistries != null)
           {
             patient.Biochemistries.AddRange(biochemistries);
           }      
                  
                  
                  
        
                 //One To Many
           var semenanalyses = await this.conn.SelectAsync<SemenAnalysis>(e => e.SerialNo == id);
           if (patient != null && semenanalyses != null)
           {
             patient.SemenAnalyses.AddRange(semenanalyses);
           }      
                  
                  
                  
        
                 //One To Many
           var serologies = await this.conn.SelectAsync<Serology>(e => e.SerialNo == id);
           if (patient != null && serologies != null)
           {
             patient.Serologies.AddRange(serologies);
           }      
                  
                  
                  
        
                 //One To Many
           var urineexaminations = await this.conn.SelectAsync<UrineExamination>(e => e.SerialNo == id);
           if (patient != null && urineexaminations != null)
           {
             patient.UrineExaminations.AddRange(urineexaminations);
           }      
                  
                  
                  
  
         return patient;
         }
       
       
      public async Task<Patient> SavePatientAsync(Patient patient)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(patient.IsNew)
                {
                   await this.AddPatientAsync(patient);
                }
                else
                {
                   await this.UpdatePatientAsync(patient);
                }
                
                
        
                 //One To Many
                  foreach(var haematology in patient.Haematologies.Where(s => !s.IsDeleted))
                  { 
                  
                    haematology.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(haematology);
                  }
                  foreach(var haematology in patient.Haematologies.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<Haematology>(haematology.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisatb in patient.ElisaTbs.Where(s => !s.IsDeleted))
                  { 
                  
                    elisatb.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(elisatb);
                  }
                  foreach(var elisatb in patient.ElisaTbs.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<ElisaTb>(elisatb.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisahcv in patient.ElisaHcvs.Where(s => !s.IsDeleted))
                  { 
                  
                    elisahcv.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(elisahcv);
                  }
                  foreach(var elisahcv in patient.ElisaHcvs.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<ElisaHcv>(elisahcv.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisahbsag in patient.ElisaHbsags.Where(s => !s.IsDeleted))
                  { 
                  
                    elisahbsag.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(elisahbsag);
                  }
                  foreach(var elisahbsag in patient.ElisaHbsags.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<ElisaHbsag>(elisahbsag.SerialNo);
                  }
        
                 //One To Many
                  foreach(var bloodgroup in patient.BloodGroups.Where(s => !s.IsDeleted))
                  { 
                  
                    bloodgroup.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(bloodgroup);
                  }
                  foreach(var bloodgroup in patient.BloodGroups.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<BloodGroup>(bloodgroup.SerialNo);
                  }
        
                 //One To Many
                  foreach(var biochemistry in patient.Biochemistries.Where(s => !s.IsDeleted))
                  { 
                  
                    biochemistry.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(biochemistry);
                  }
                  foreach(var biochemistry in patient.Biochemistries.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<Biochemistry>(biochemistry.SerialNo);
                  }
        
                 //One To Many
                  foreach(var semenanalysis in patient.SemenAnalyses.Where(s => !s.IsDeleted))
                  { 
                  
                    semenanalysis.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(semenanalysis);
                  }
                  foreach(var semenanalysis in patient.SemenAnalyses.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<SemenAnalysis>(semenanalysis.SerialNo);
                  }
        
                 //One To Many
                  foreach(var serology in patient.Serologies.Where(s => !s.IsDeleted))
                  { 
                  
                    serology.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(serology);
                  }
                  foreach(var serology in patient.Serologies.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<Serology>(serology.SerialNo);
                  }
        
                 //One To Many
                  foreach(var urineexamination in patient.UrineExaminations.Where(s => !s.IsDeleted))
                  { 
                  
                    urineexamination.PatientID =patient.PatientID;
                    await this.conn.SaveAsync(urineexamination);
                  }
                  foreach(var urineexamination in patient.UrineExaminations.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<UrineExamination>(urineexamination.SerialNo);
                  }
                 
                   
                    txScope.Complete();
            }
            return patient;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}