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
    public class DoctorRepository : IDoctorsRepository,IDisposable
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

      public async Task<Doctor> AddDoctorAsync(Doctor doctor)
       {
          await this.conn.InsertAsync(doctor);
          doctor.DoctorID =this.conn.LastInsertId();
          return doctor;
       
       }
       
      public async Task<List<Doctor>> GetAllDoctorAsync()
       {
         return await this.conn.SelectAsync<Doctor>();
       
       }
       
      public async Task<Doctor> FindDoctorAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Doctor>(id);
       
       }
       
      public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
       {
          var result= await this.conn.UpdateAsync<Doctor>(doctor);
          return doctor;
       
       }
       
      public async Task RemoveDoctorAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Doctor>(id);
       
       }
       
      public async Task<Doctor> GetDoctorWithChildrenAsync(long id)
       {
          var doctor = await this.conn.SingleByIdAsync<Doctor>(id);
          
          
          
        
                 //One To Many
           var refbypatients = await this.conn.SelectAsync<Patient>(e => e.PatientID == id);
           if (doctor != null && refbypatients != null)
           {
             doctor.RefByPatients.AddRange(refbypatients);
           }      
                  
                  
                  
  
         return doctor;
         }
       
       
      public async Task<Doctor> SaveDoctorAsync(Doctor doctor)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(doctor.IsNew)
                {
                   await this.AddDoctorAsync(doctor);
                }
                else
                {
                   await this.UpdateDoctorAsync(doctor);
                }
                
                
        
                 //One To Many
                  foreach(var patient in doctor.RefByPatients.Where(s => !s.IsDeleted))
                  { 
                  
                    patient.RefBy =doctor.DoctorID;
                    await this.conn.SaveAsync(patient);
                  }
                  foreach(var patient in doctor.RefByPatients.Where(s => s.IsDeleted))
                  { 
                  
                    await this.conn.DeleteByIdAsync<Patient>(patient.PatientID);
                  }
                 
                   
                    txScope.Complete();
            }
            return doctor;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}