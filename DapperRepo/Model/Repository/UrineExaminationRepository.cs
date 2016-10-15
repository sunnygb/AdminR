using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;
using ServiceStack.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalReporting.Model.Repository
{    

    public interface IUrineExaminationsRepository
    {
       Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination);
       Task<List< UrineExamination>> GetAllUrineExaminationAsync();
       Task<UrineExamination> FindUrineExaminationAsync(long id);
       Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination);
       Task RemoveUrineExaminationAsync(long id); 
       
       Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id);
       Task<UrineExamination> SaveUrineExaminationAsync(UrineExamination urineexamination);
       Task<List<UrineExamination>> QueryAsync(string query);
       IDbConnection Custom { get;  }
    }


    public class UrineExaminationRepository : IUrineExaminationsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public UrineExaminationRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       

      public async Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination)
       {
          await Conn.InsertAsync(urineexamination);
          urineexamination.SerialNo =Conn.LastInsertId();
          return urineexamination;
       
       }
       
      public async Task<List<UrineExamination>> GetAllUrineExaminationAsync()
       {
         return await Conn.SelectAsync<UrineExamination>();
       
       }
       
      public async Task<UrineExamination> FindUrineExaminationAsync(long id)
       {
         return await Conn.SingleByIdAsync<UrineExamination>(id);
       
       }
       
      public async Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination)
       {
          await Conn.UpdateAsync<UrineExamination>(urineexamination);
          return urineexamination;
       
       }
       
      public async Task RemoveUrineExaminationAsync(long id)
       {
         await Conn.DeleteByIdAsync<UrineExamination>(id);
       
       }
       
      public async Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id)
       {
          var urineexamination = await Conn.SingleByIdAsync<UrineExamination>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
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
                   await AddUrineExaminationAsync(urineexamination);
                }
                else
                {
                   await UpdateUrineExaminationAsync(urineexamination);
                }
                
                
                    
                 // One To One 
                 if(urineexamination.Patient!=null)
                 {
                    if(urineexamination.Patient.IsDeleted)
                    {
                      var id = urineexamination.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!urineexamination.Patient.IsDeleted)
                    {
                      var patient = urineexamination.Patient;
                      patient.PatientID = urineexamination.SerialNo;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return urineexamination;
       
       }
       
      public async Task<List<UrineExamination>> QueryAsync(string query)
      {
        var result = await Conn.SelectAsync<UrineExamination>(query);
        return result;
      }
      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignUrineExaminationsRepository : IUrineExaminationsRepository
    {
      public Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination)
      {
         return null;
      }
      public async Task<List<UrineExamination>> GetAllUrineExaminationAsync()
      {
            var resultList = new List<UrineExamination>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new UrineExamination
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  Colour =  "Colour"+i, 
                  Reaction =  "Reaction"+i, 
                  SpecificGravity =  "SpecificGravity"+i, 
                  Albumin =  "Albumin"+i, 
                  Sugar =  "Sugar"+i, 
                  Ketone =  "Ketone"+i, 
                  Blood =  "Blood"+i, 
                  Bilirubin =  "Bilirubin"+i, 
                  UrobilNogen =  "UrobilNogen"+i, 
                  PusCells =  "PusCells"+i, 
                  Rbc =  "Rbc"+i, 
                  EPiCells =  "EPiCells"+i, 
                  Cast =  "Cast"+i, 
                  Crystals =  "Crystals"+i, 
                  CalOxalate =  "CalOxalate"+i, 
                  UricAcid =  "UricAcid"+i, 
                  Amorphous =  "Amorphous"+i, 
                  Others =  "Others"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<UrineExamination> FindUrineExaminationAsync(long id)
      {
         return new UrineExamination
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    Colour =  "Colour",
                    Reaction =  "Reaction",
                    SpecificGravity =  "SpecificGravity",
                    Albumin =  "Albumin",
                    Sugar =  "Sugar",
                    Ketone =  "Ketone",
                    Blood =  "Blood",
                    Bilirubin =  "Bilirubin",
                    UrobilNogen =  "UrobilNogen",
                    PusCells =  "PusCells",
                    Rbc =  "Rbc",
                    EPiCells =  "EPiCells",
                    Cast =  "Cast",
                    Crystals =  "Crystals",
                    CalOxalate =  "CalOxalate",
                    UricAcid =  "UricAcid",
                    Amorphous =  "Amorphous",
                    Others =  "Others",
                    Fee =  12345,
                };
      }
      public async Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination)
      {
        return null;
      }
      public async Task RemoveUrineExaminationAsync(long id)
      {
        
      }
       
      public async Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id)
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

         
        return new UrineExamination
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    Colour =  "Colour",
                    Reaction =  "Reaction",
                    SpecificGravity =  "SpecificGravity",
                    Albumin =  "Albumin",
                    Sugar =  "Sugar",
                    Ketone =  "Ketone",
                    Blood =  "Blood",
                    Bilirubin =  "Bilirubin",
                    UrobilNogen =  "UrobilNogen",
                    PusCells =  "PusCells",
                    Rbc =  "Rbc",
                    EPiCells =  "EPiCells",
                    Cast =  "Cast",
                    Crystals =  "Crystals",
                    CalOxalate =  "CalOxalate",
                    UricAcid =  "UricAcid",
                    Amorphous =  "Amorphous",
                    Others =  "Others",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<UrineExamination> SaveUrineExaminationAsync(UrineExamination urineexamination)
      {
        return null;
      }
      public async Task<List<UrineExamination>> QueryAsync(string query)
      {
         return null;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
    
    
    
    
    
    
    
}