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



#region Interface

    public interface IPatientsRepository
    {
       Task<Patient> AddPatientAsync(Patient patient);
       Task<List< Patient>> GetAllPatientAsync();
       Task<Patient> FindPatientAsync(long id);
       Task<Patient> UpdatePatientAsync(Patient patient);
       Task RemovePatientAsync(long id); 
       Task<Patient> GetPatientWithChildrenAsync(long id);
       Task<Patient> SavePatientAsync(Patient patient);
       Task<List<Patient>> QueryAsync(string query);
       
       Patient AddPatient(Patient patient);
       List< Patient> GetAllPatient();
       Patient FindPatient(long id);
       Patient UpdatePatient(Patient patient);
       void RemovePatient(long id); 
       Patient GetWithChildren(long id);
       Patient SavePatient(Patient patient);
       List< Patient> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class PatientRepository : IPatientsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public PatientRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Patient AddPatient(Patient patient)
       {
          this.Conn.Insert(patient);
          patient.PatientID =this.Conn.LastInsertId();
          return patient;
       
       }
       
      public List<Patient> GetAllPatient()
       {
         return Conn.Select<Patient>();
       
       }
       
      public Patient FindPatient(long id)
       {
         return Conn.SingleById<Patient>(id);
       
       }
       
      public Patient UpdatePatient(Patient patient)
       {
          var result=Conn.Update<Patient>(patient);
          return patient;
       
       }
       
      public void RemovePatient(long id)
       {
          Conn.DeleteById<Patient>(id);
       
       }
       
      public Patient GetWithChildren(long id)
       {
          var patient = Conn.SingleById<Patient>(id);
          
          
          
        
                 //One To Many
           var haematologies = Conn.Select<Haematology>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && haematologies != null)
           {
             patient.Haematologies.AddRange(haematologies);
           }      
                  
                  
                  
        
                 //One To Many
           var elisatbs = Conn.Select<ElisaTb>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && elisatbs != null)
           {
             patient.ElisaTbs.AddRange(elisatbs);
           }      
                  
                  
                  
        
                 //One To Many
           var elisahcvs = Conn.Select<ElisaHcv>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && elisahcvs != null)
           {
             patient.ElisaHcvs.AddRange(elisahcvs);
           }      
                  
                  
                  
        
                 //One To Many
           var elisahbsags = Conn.Select<ElisaHbsag>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && elisahbsags != null)
           {
             patient.ElisaHbsags.AddRange(elisahbsags);
           }      
                  
                  
                  
        
                 //One To Many
           var bloodgroups = Conn.Select<BloodGroup>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && bloodgroups != null)
           {
             patient.BloodGroups.AddRange(bloodgroups);
           }      
                  
                  
                  
        
                 //One To Many
           var biochemistries = Conn.Select<Biochemistry>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && biochemistries != null)
           {
             patient.Biochemistries.AddRange(biochemistries);
           }      
                  
                  
                  
        
                 //One To Many
           var semenanalyses = Conn.Select<SemenAnalysis>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && semenanalyses != null)
           {
             patient.SemenAnalyses.AddRange(semenanalyses);
           }      
                  
                  
                  
        
                 //One To Many
           var urineexaminations = Conn.Select<UrineExamination>().Where(a => a.SerialNo == id).ToList();
           if (patient != null && urineexaminations != null)
           {
             patient.UrineExaminations.AddRange(urineexaminations);
           }      
                  
                  
                  
        
                 //One To Many
           var serologies = Conn.Select<Serology>().Where(a => a.Serialno == id).ToList();
           if (patient != null && serologies != null)
           {
             patient.Serologies.AddRange(serologies);
           }      
                  
                  
                  
  
         return patient;
         }
       
       
      public Patient SavePatient(Patient patient)
      {
          using(var txScope= new TransactionScope())
            {
                if(patient.IsNew)
                {
                    this.AddPatient(patient);
                }
                else
                {
                    this.UpdatePatient(patient);
                }
                
                
        
                 //One To Many
                  foreach(var haematology in patient.Haematologies.Where(s => !s.IsDeleted))
                  { 
                  
                    haematology.PatientID =patient.PatientID;
                    Conn.Save(haematology);
                  }
                  foreach(var haematology in patient.Haematologies.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<Haematology>(haematology.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisatb in patient.ElisaTbs.Where(s => !s.IsDeleted))
                  { 
                  
                    elisatb.PatientID =patient.PatientID;
                    Conn.Save(elisatb);
                  }
                  foreach(var elisatb in patient.ElisaTbs.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<ElisaTb>(elisatb.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisahcv in patient.ElisaHcvs.Where(s => !s.IsDeleted))
                  { 
                  
                    elisahcv.PatientID =patient.PatientID;
                    Conn.Save(elisahcv);
                  }
                  foreach(var elisahcv in patient.ElisaHcvs.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<ElisaHcv>(elisahcv.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisahbsag in patient.ElisaHbsags.Where(s => !s.IsDeleted))
                  { 
                  
                    elisahbsag.PatientID =patient.PatientID;
                    Conn.Save(elisahbsag);
                  }
                  foreach(var elisahbsag in patient.ElisaHbsags.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<ElisaHbsag>(elisahbsag.SerialNo);
                  }
        
                 //One To Many
                  foreach(var bloodgroup in patient.BloodGroups.Where(s => !s.IsDeleted))
                  { 
                  
                    bloodgroup.PatientID =patient.PatientID;
                    Conn.Save(bloodgroup);
                  }
                  foreach(var bloodgroup in patient.BloodGroups.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<BloodGroup>(bloodgroup.SerialNo);
                  }
        
                 //One To Many
                  foreach(var biochemistry in patient.Biochemistries.Where(s => !s.IsDeleted))
                  { 
                  
                    biochemistry.PatientID =patient.PatientID;
                    Conn.Save(biochemistry);
                  }
                  foreach(var biochemistry in patient.Biochemistries.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<Biochemistry>(biochemistry.SerialNo);
                  }
        
                 //One To Many
                  foreach(var semenanalysis in patient.SemenAnalyses.Where(s => !s.IsDeleted))
                  { 
                  
                    semenanalysis.PatientID =patient.PatientID;
                    Conn.Save(semenanalysis);
                  }
                  foreach(var semenanalysis in patient.SemenAnalyses.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<SemenAnalysis>(semenanalysis.SerialNo);
                  }
        
                 //One To Many
                  foreach(var urineexamination in patient.UrineExaminations.Where(s => !s.IsDeleted))
                  { 
                  
                    urineexamination.PatientID =patient.PatientID;
                    Conn.Save(urineexamination);
                  }
                  foreach(var urineexamination in patient.UrineExaminations.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<UrineExamination>(urineexamination.SerialNo);
                  }
        
                 //One To Many
                  foreach(var serology in patient.Serologies.Where(s => !s.IsDeleted))
                  { 
                  
                    serology.Patientid =patient.PatientID;
                    Conn.Save(serology);
                  }
                  foreach(var serology in patient.Serologies.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<Serology>(serology.Serialno);
                  }
                 
                   
                    txScope.Complete();
            }
            return patient;
       
       }
       
       public List< Patient> Query(string query)
       {
          return Conn.Select<Patient>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Patient> AddPatientAsync(Patient patient)
       {
          await Conn.InsertAsync(patient);
          patient.PatientID =Conn.LastInsertId();
          return patient;
       
       }
       
      public async Task<List<Patient>> GetAllPatientAsync()
       {
         return await Conn.SelectAsync<Patient>();
       
       }
       
      public async Task<Patient> FindPatientAsync(long id)
       {
         return await Conn.SingleByIdAsync<Patient>(id);
       
       }
       
      public async Task<Patient> UpdatePatientAsync(Patient patient)
       {
          await Conn.UpdateAsync<Patient>(patient);
          return patient;
       
       }
       
      public async Task RemovePatientAsync(long id)
       {
         await Conn.DeleteByIdAsync<Patient>(id);
       
       }
       
      public async Task<Patient> GetPatientWithChildrenAsync(long id)
       {
          var patient = await Conn.SingleByIdAsync<Patient>(id);
          
          
          
        
                 //One To Many
           var haematologies = await Conn.SelectAsync<Haematology>(e => e.SerialNo == id);
           if (patient != null && haematologies != null)
           {
             patient.Haematologies.AddRange(haematologies);
           }      
                  
                  
                  
        
                 //One To Many
           var elisatbs = await Conn.SelectAsync<ElisaTb>(e => e.SerialNo == id);
           if (patient != null && elisatbs != null)
           {
             patient.ElisaTbs.AddRange(elisatbs);
           }      
                  
                  
                  
        
                 //One To Many
           var elisahcvs = await Conn.SelectAsync<ElisaHcv>(e => e.SerialNo == id);
           if (patient != null && elisahcvs != null)
           {
             patient.ElisaHcvs.AddRange(elisahcvs);
           }      
                  
                  
                  
        
                 //One To Many
           var elisahbsags = await Conn.SelectAsync<ElisaHbsag>(e => e.SerialNo == id);
           if (patient != null && elisahbsags != null)
           {
             patient.ElisaHbsags.AddRange(elisahbsags);
           }      
                  
                  
                  
        
                 //One To Many
           var bloodgroups = await Conn.SelectAsync<BloodGroup>(e => e.SerialNo == id);
           if (patient != null && bloodgroups != null)
           {
             patient.BloodGroups.AddRange(bloodgroups);
           }      
                  
                  
                  
        
                 //One To Many
           var biochemistries = await Conn.SelectAsync<Biochemistry>(e => e.SerialNo == id);
           if (patient != null && biochemistries != null)
           {
             patient.Biochemistries.AddRange(biochemistries);
           }      
                  
                  
                  
        
                 //One To Many
           var semenanalyses = await Conn.SelectAsync<SemenAnalysis>(e => e.SerialNo == id);
           if (patient != null && semenanalyses != null)
           {
             patient.SemenAnalyses.AddRange(semenanalyses);
           }      
                  
                  
                  
        
                 //One To Many
           var urineexaminations = await Conn.SelectAsync<UrineExamination>(e => e.SerialNo == id);
           if (patient != null && urineexaminations != null)
           {
             patient.UrineExaminations.AddRange(urineexaminations);
           }      
                  
                  
                  
        
                 //One To Many
           var serologies = await Conn.SelectAsync<Serology>(e => e.Serialno == id);
           if (patient != null && serologies != null)
           {
             patient.Serologies.AddRange(serologies);
           }      
                  
                  
                  
  
         return patient;
         }
       
       
      public async Task<Patient> SavePatientAsync(Patient patient)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(patient.IsNew)
                {
                   await AddPatientAsync(patient);
                }
                else
                {
                   await UpdatePatientAsync(patient);
                }
                
                
        
                 //One To Many
                  foreach(var haematology in patient.Haematologies.Where(s => !s.IsDeleted))
                  { 
                  
                    haematology.PatientID =patient.PatientID;
                    await Conn.SaveAsync(haematology);
                  }
                  foreach(var haematology in patient.Haematologies.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<Haematology>(haematology.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisatb in patient.ElisaTbs.Where(s => !s.IsDeleted))
                  { 
                  
                    elisatb.PatientID =patient.PatientID;
                    await Conn.SaveAsync(elisatb);
                  }
                  foreach(var elisatb in patient.ElisaTbs.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<ElisaTb>(elisatb.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisahcv in patient.ElisaHcvs.Where(s => !s.IsDeleted))
                  { 
                  
                    elisahcv.PatientID =patient.PatientID;
                    await Conn.SaveAsync(elisahcv);
                  }
                  foreach(var elisahcv in patient.ElisaHcvs.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<ElisaHcv>(elisahcv.SerialNo);
                  }
        
                 //One To Many
                  foreach(var elisahbsag in patient.ElisaHbsags.Where(s => !s.IsDeleted))
                  { 
                  
                    elisahbsag.PatientID =patient.PatientID;
                    await Conn.SaveAsync(elisahbsag);
                  }
                  foreach(var elisahbsag in patient.ElisaHbsags.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<ElisaHbsag>(elisahbsag.SerialNo);
                  }
        
                 //One To Many
                  foreach(var bloodgroup in patient.BloodGroups.Where(s => !s.IsDeleted))
                  { 
                  
                    bloodgroup.PatientID =patient.PatientID;
                    await Conn.SaveAsync(bloodgroup);
                  }
                  foreach(var bloodgroup in patient.BloodGroups.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<BloodGroup>(bloodgroup.SerialNo);
                  }
        
                 //One To Many
                  foreach(var biochemistry in patient.Biochemistries.Where(s => !s.IsDeleted))
                  { 
                  
                    biochemistry.PatientID =patient.PatientID;
                    await Conn.SaveAsync(biochemistry);
                  }
                  foreach(var biochemistry in patient.Biochemistries.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<Biochemistry>(biochemistry.SerialNo);
                  }
        
                 //One To Many
                  foreach(var semenanalysis in patient.SemenAnalyses.Where(s => !s.IsDeleted))
                  { 
                  
                    semenanalysis.PatientID =patient.PatientID;
                    await Conn.SaveAsync(semenanalysis);
                  }
                  foreach(var semenanalysis in patient.SemenAnalyses.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<SemenAnalysis>(semenanalysis.SerialNo);
                  }
        
                 //One To Many
                  foreach(var urineexamination in patient.UrineExaminations.Where(s => !s.IsDeleted))
                  { 
                  
                    urineexamination.PatientID =patient.PatientID;
                    await Conn.SaveAsync(urineexamination);
                  }
                  foreach(var urineexamination in patient.UrineExaminations.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<UrineExamination>(urineexamination.SerialNo);
                  }
        
                 //One To Many
                  foreach(var serology in patient.Serologies.Where(s => !s.IsDeleted))
                  { 
                  
                    serology.Patientid =patient.PatientID;
                    await Conn.SaveAsync(serology);
                  }
                  foreach(var serology in patient.Serologies.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<Serology>(serology.Serialno);
                  }
                 
                   
                    txScope.Complete();
            }
            return patient;
       
       }
       
      public async Task<List<Patient>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Patient>(query);
      }
      
      
       #endregion
       

#region Design Repository
       


      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignPatientsRepository : IPatientsRepository
    {
    
    
       public Patient AddPatient(Patient patient)
       {
          return null;
       }
       public List< Patient> GetAllPatient()
       {

           var resultList = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Patient
                {
                    
                  PatientID = i+12345, 
                  Name =  "Name"+i, 
                  Age =  "Age"+i, 
                  Sex =  "Sex"+i, 
                  RefBy =  "RefBy"+i, 
                });
            }
            return resultList;
         
       }
       public  Patient FindPatient(long id)
       {
             return new Patient
                {
                    
                    PatientID =  12345,
                    Name =  "Name",
                    Age =  "Age",
                    Sex =  "Sex",
                    RefBy =  "RefBy",
                };
       }
       public Patient UpdatePatient(Patient patient)
       {
         return null;
       }
       public void RemovePatient(long id)
       {
          return;
       
       }
       public Patient GetWithChildren(long id)
       {
              
        // One to Many
        var haematology1= new Haematology 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Hb =  "Hb", 
                              HBUnit =  "HBUnit", 
                              HBNor =  "HBNor", 
                              Tlc =  "Tlc", 
                              TLCUnit =  "TLCUnit", 
                              TLCNor =  "TLCNor", 
                              Esr =  "Esr", 
                              ESRUnit =  "ESRUnit", 
                              ESRNor =  "ESRNor", 
                              Bt =  "Bt", 
                              BTUnit =  "BTUnit", 
                              BTNor =  "BTNor", 
                              Ct =  "Ct", 
                              CTUnit =  "CTUnit", 
                              CTNor =  "CTNor", 
                              PlateletsCount =  "PlateletsCount", 
                              PlateletsCountUnit =  "PlateletsCountUnit", 
                              PlateletsCountNor =  "PlateletsCountNor", 
                              Pt =  "Pt", 
                              PTUnit =  "PTUnit", 
                              PTNor =  "PTNor", 
                              Dlc =  "Dlc", 
                              DLCUnit =  "DLCUnit", 
                              DLCNor =  "DLCNor", 
                              Polymorphs =  "Polymorphs", 
                              PolymorphsUnit =  "PolymorphsUnit", 
                              PolymorphsNor =  "PolymorphsNor", 
                              Lymphocytes =  "Lymphocytes", 
                              LymphocytesUnit =  "LymphocytesUnit", 
                              LymphocytesNor =  "LymphocytesNor", 
                              Monocyte =  "Monocyte", 
                              MonocyteUnit =  "MonocyteUnit", 
                              MonocyteNor =  "MonocyteNor", 
                              Eosinophil =  "Eosinophil", 
                              EosinophilUnit =  "EosinophilUnit", 
                              EosinophilNor =  "EosinophilNor", 
                              Basophil =  "Basophil", 
                              BasophilUnit =  "BasophilUnit", 
                              BasophilNor =  "BasophilNor", 
                              MalariaParasites =  "MalariaParasites", 
                              MalariaParasitesUnit =  "MalariaParasitesUnit", 
                              MalariaParasitesNor =  "MalariaParasitesNor", 
                              BloodGroup =  "BloodGroup", 
                              BloodGroupUnit =  "BloodGroupUnit", 
                              BloodGroupNor =  "BloodGroupNor", 
                              RHFactor =  "RHFactor", 
                              RHFactorUnit =  "RHFactorUnit", 
                              RHFactorNor =  "RHFactorNor", 
                              TotalRBC =  "TotalRBC", 
                              TotalRBCUnit =  "TotalRBCUnit", 
                              TotalRBCNor =  "TotalRBCNor", 
                              PVCHaematorcrit =  "PVCHaematorcrit", 
                              PVCHaematorcritUnit =  "PVCHaematorcritUnit", 
                              PVCHaematorcritNor =  "PVCHaematorcritNor", 
                              MCV =  "MCV", 
                              MCVUnit =  "MCVUnit", 
                              MCVNor =  "MCVNor", 
                              MCH =  "MCH", 
                              MCHUnit =  "MCHUnit", 
                              MCHNor =  "MCHNor", 
                              MCHC =  "MCHC", 
                              MCHCUnit =  "MCHCUnit", 
                              MCHCNor =  "MCHCNor", 
                              Fee = 12345, 
                  };
        var haematology2= new Haematology 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Hb =  "Hb", 
                              HBUnit =  "HBUnit", 
                              HBNor =  "HBNor", 
                              Tlc =  "Tlc", 
                              TLCUnit =  "TLCUnit", 
                              TLCNor =  "TLCNor", 
                              Esr =  "Esr", 
                              ESRUnit =  "ESRUnit", 
                              ESRNor =  "ESRNor", 
                              Bt =  "Bt", 
                              BTUnit =  "BTUnit", 
                              BTNor =  "BTNor", 
                              Ct =  "Ct", 
                              CTUnit =  "CTUnit", 
                              CTNor =  "CTNor", 
                              PlateletsCount =  "PlateletsCount", 
                              PlateletsCountUnit =  "PlateletsCountUnit", 
                              PlateletsCountNor =  "PlateletsCountNor", 
                              Pt =  "Pt", 
                              PTUnit =  "PTUnit", 
                              PTNor =  "PTNor", 
                              Dlc =  "Dlc", 
                              DLCUnit =  "DLCUnit", 
                              DLCNor =  "DLCNor", 
                              Polymorphs =  "Polymorphs", 
                              PolymorphsUnit =  "PolymorphsUnit", 
                              PolymorphsNor =  "PolymorphsNor", 
                              Lymphocytes =  "Lymphocytes", 
                              LymphocytesUnit =  "LymphocytesUnit", 
                              LymphocytesNor =  "LymphocytesNor", 
                              Monocyte =  "Monocyte", 
                              MonocyteUnit =  "MonocyteUnit", 
                              MonocyteNor =  "MonocyteNor", 
                              Eosinophil =  "Eosinophil", 
                              EosinophilUnit =  "EosinophilUnit", 
                              EosinophilNor =  "EosinophilNor", 
                              Basophil =  "Basophil", 
                              BasophilUnit =  "BasophilUnit", 
                              BasophilNor =  "BasophilNor", 
                              MalariaParasites =  "MalariaParasites", 
                              MalariaParasitesUnit =  "MalariaParasitesUnit", 
                              MalariaParasitesNor =  "MalariaParasitesNor", 
                              BloodGroup =  "BloodGroup", 
                              BloodGroupUnit =  "BloodGroupUnit", 
                              BloodGroupNor =  "BloodGroupNor", 
                              RHFactor =  "RHFactor", 
                              RHFactorUnit =  "RHFactorUnit", 
                              RHFactorNor =  "RHFactorNor", 
                              TotalRBC =  "TotalRBC", 
                              TotalRBCUnit =  "TotalRBCUnit", 
                              TotalRBCNor =  "TotalRBCNor", 
                              PVCHaematorcrit =  "PVCHaematorcrit", 
                              PVCHaematorcritUnit =  "PVCHaematorcritUnit", 
                              PVCHaematorcritNor =  "PVCHaematorcritNor", 
                              MCV =  "MCV", 
                              MCVUnit =  "MCVUnit", 
                              MCVNor =  "MCVNor", 
                              MCH =  "MCH", 
                              MCHUnit =  "MCHUnit", 
                              MCHNor =  "MCHNor", 
                              MCHC =  "MCHC", 
                              MCHCUnit =  "MCHCUnit", 
                              MCHCNor =  "MCHCNor", 
                              Fee = 12345, 
                  };         

        // One to Many
        var elisatb1= new ElisaTb 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };
        var elisatb2= new ElisaTb 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };         

        // One to Many
        var elisahcv1= new ElisaHcv 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };
        var elisahcv2= new ElisaHcv 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };         

        // One to Many
        var elisahbsag1= new ElisaHbsag 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };
        var elisahbsag2= new ElisaHbsag 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };         

        // One to Many
        var bloodgroup1= new BloodGroup 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientBloodGroup =  "PatientBloodGroup", 
                              DonarName =  "DonarName", 
                              DonarBloodGroup =  "DonarBloodGroup", 
                              HbsAg =  "HbsAg", 
                              AntiHCV =  "AntiHCV", 
                              Fee = 12345, 
                  };
        var bloodgroup2= new BloodGroup 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientBloodGroup =  "PatientBloodGroup", 
                              DonarName =  "DonarName", 
                              DonarBloodGroup =  "DonarBloodGroup", 
                              HbsAg =  "HbsAg", 
                              AntiHCV =  "AntiHCV", 
                              Fee = 12345, 
                  };         

        // One to Many
        var biochemistry1= new Biochemistry 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              BloodSugarFasting =  "BloodSugarFasting", 
                              BloodSugarFastingUnit =  "BloodSugarFastingUnit", 
                              BloodSugarFastingNor =  "BloodSugarFastingNor", 
                              BloodSugar2HPP =  "BloodSugar2HPP", 
                              BloodSugar2HPPUnit =  "BloodSugar2HPPUnit", 
                              BloodSugar2HPPNor =  "BloodSugar2HPPNor", 
                              BloodSugarRandom =  "BloodSugarRandom", 
                              BloodSugarRandomUnit =  "BloodSugarRandomUnit", 
                              BloodSugarRandomNor =  "BloodSugarRandomNor", 
                              BloodUrea =  "BloodUrea", 
                              BloodUreaUnit =  "BloodUreaUnit", 
                              BloodUreaNor =  "BloodUreaNor", 
                              Bun =  "Bun", 
                              BUNUnit =  "BUNUnit", 
                              BUNNor =  "BUNNor", 
                              SCreatinine =  "SCreatinine", 
                              SCreatinineUnit =  "SCreatinineUnit", 
                              SCreatinineNor =  "SCreatinineNor", 
                              SUricAcid =  "SUricAcid", 
                              SUricAcidUnit =  "SUricAcidUnit", 
                              SUricAcidNor =  "SUricAcidNor", 
                              SCholestrol =  "SCholestrol", 
                              SCholestrolUnit =  "SCholestrolUnit", 
                              SCholestrolNor =  "SCholestrolNor", 
                              STriglycerides =  "STriglycerides", 
                              STriglyceridesUnit =  "STriglyceridesUnit", 
                              STriglyceridesNor =  "STriglyceridesNor", 
                              HDLCholestrol =  "HDLCholestrol", 
                              HDLCholestrolUnit =  "HDLCholestrolUnit", 
                              HDLCholestrolNor =  "HDLCholestrolNor", 
                              LDLCholestrol =  "LDLCholestrol", 
                              LDLCholestrolUnit =  "LDLCholestrolUnit", 
                              LDLCholestrolNor =  "LDLCholestrolNor", 
                              SgotAst =  "SgotAst", 
                              SGOTASTUnit =  "SGOTASTUnit", 
                              SGOTNor =  "SGOTNor", 
                              Ldh =  "Ldh", 
                              LDHUnit =  "LDHUnit", 
                              LDHNor =  "LDHNor", 
                              Cpk =  "Cpk", 
                              CPKUnit =  "CPKUnit", 
                              CPKNor =  "CPKNor", 
                              Ckmb =  "Ckmb", 
                              CKMBUnit =  "CKMBUnit", 
                              CKMBNor =  "CKMBNor", 
                              SBilirubinT =  "SBilirubinT", 
                              SBilirubinTUnit =  "SBilirubinTUnit", 
                              SBilirubinTNor =  "SBilirubinTNor", 
                              SBilirubinD =  "SBilirubinD", 
                              SBilirubinDUnit =  "SBilirubinDUnit", 
                              SBilirubinDNor =  "SBilirubinDNor", 
                              SBilirubinInd =  "SBilirubinInd", 
                              SBilirubinIndUnit =  "SBilirubinIndUnit", 
                              SBilirubinIndNor =  "SBilirubinIndNor", 
                              SAlkPhosphatase =  "SAlkPhosphatase", 
                              SAlkPhosphataseUnit =  "SAlkPhosphataseUnit", 
                              SAlkPhosphataseNor =  "SAlkPhosphataseNor", 
                              SgptAlt =  "SgptAlt", 
                              SGPTALTUnit =  "SGPTALTUnit", 
                              SGPTALTNor =  "SGPTALTNor", 
                              SSodium =  "SSodium", 
                              SSodiumUnit =  "SSodiumUnit", 
                              SSodiumNor =  "SSodiumNor", 
                              SPotassium =  "SPotassium", 
                              SPotassiumUnit =  "SPotassiumUnit", 
                              SPotassiumNor =  "SPotassiumNor", 
                              SChloride =  "SChloride", 
                              SChlorideUnit =  "SChlorideUnit", 
                              SChlorideNor =  "SChlorideNor", 
                              SCalcium =  "SCalcium", 
                              SCalciumUnit =  "SCalciumUnit", 
                              SCalciumNor =  "SCalciumNor", 
                              SProtein =  "SProtein", 
                              SProteinUnit =  "SProteinUnit", 
                              SProteinNor =  "SProteinNor", 
                              SAlbumin =  "SAlbumin", 
                              SAlbuminUnit =  "SAlbuminUnit", 
                              SAlbuminNor =  "SAlbuminNor", 
                              AGRatio =  "AGRatio", 
                              AGRatioUnit =  "AGRatioUnit", 
                              AGRatioNor =  "AGRatioNor", 
                              Fee = 12345, 
                  };
        var biochemistry2= new Biochemistry 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              BloodSugarFasting =  "BloodSugarFasting", 
                              BloodSugarFastingUnit =  "BloodSugarFastingUnit", 
                              BloodSugarFastingNor =  "BloodSugarFastingNor", 
                              BloodSugar2HPP =  "BloodSugar2HPP", 
                              BloodSugar2HPPUnit =  "BloodSugar2HPPUnit", 
                              BloodSugar2HPPNor =  "BloodSugar2HPPNor", 
                              BloodSugarRandom =  "BloodSugarRandom", 
                              BloodSugarRandomUnit =  "BloodSugarRandomUnit", 
                              BloodSugarRandomNor =  "BloodSugarRandomNor", 
                              BloodUrea =  "BloodUrea", 
                              BloodUreaUnit =  "BloodUreaUnit", 
                              BloodUreaNor =  "BloodUreaNor", 
                              Bun =  "Bun", 
                              BUNUnit =  "BUNUnit", 
                              BUNNor =  "BUNNor", 
                              SCreatinine =  "SCreatinine", 
                              SCreatinineUnit =  "SCreatinineUnit", 
                              SCreatinineNor =  "SCreatinineNor", 
                              SUricAcid =  "SUricAcid", 
                              SUricAcidUnit =  "SUricAcidUnit", 
                              SUricAcidNor =  "SUricAcidNor", 
                              SCholestrol =  "SCholestrol", 
                              SCholestrolUnit =  "SCholestrolUnit", 
                              SCholestrolNor =  "SCholestrolNor", 
                              STriglycerides =  "STriglycerides", 
                              STriglyceridesUnit =  "STriglyceridesUnit", 
                              STriglyceridesNor =  "STriglyceridesNor", 
                              HDLCholestrol =  "HDLCholestrol", 
                              HDLCholestrolUnit =  "HDLCholestrolUnit", 
                              HDLCholestrolNor =  "HDLCholestrolNor", 
                              LDLCholestrol =  "LDLCholestrol", 
                              LDLCholestrolUnit =  "LDLCholestrolUnit", 
                              LDLCholestrolNor =  "LDLCholestrolNor", 
                              SgotAst =  "SgotAst", 
                              SGOTASTUnit =  "SGOTASTUnit", 
                              SGOTNor =  "SGOTNor", 
                              Ldh =  "Ldh", 
                              LDHUnit =  "LDHUnit", 
                              LDHNor =  "LDHNor", 
                              Cpk =  "Cpk", 
                              CPKUnit =  "CPKUnit", 
                              CPKNor =  "CPKNor", 
                              Ckmb =  "Ckmb", 
                              CKMBUnit =  "CKMBUnit", 
                              CKMBNor =  "CKMBNor", 
                              SBilirubinT =  "SBilirubinT", 
                              SBilirubinTUnit =  "SBilirubinTUnit", 
                              SBilirubinTNor =  "SBilirubinTNor", 
                              SBilirubinD =  "SBilirubinD", 
                              SBilirubinDUnit =  "SBilirubinDUnit", 
                              SBilirubinDNor =  "SBilirubinDNor", 
                              SBilirubinInd =  "SBilirubinInd", 
                              SBilirubinIndUnit =  "SBilirubinIndUnit", 
                              SBilirubinIndNor =  "SBilirubinIndNor", 
                              SAlkPhosphatase =  "SAlkPhosphatase", 
                              SAlkPhosphataseUnit =  "SAlkPhosphataseUnit", 
                              SAlkPhosphataseNor =  "SAlkPhosphataseNor", 
                              SgptAlt =  "SgptAlt", 
                              SGPTALTUnit =  "SGPTALTUnit", 
                              SGPTALTNor =  "SGPTALTNor", 
                              SSodium =  "SSodium", 
                              SSodiumUnit =  "SSodiumUnit", 
                              SSodiumNor =  "SSodiumNor", 
                              SPotassium =  "SPotassium", 
                              SPotassiumUnit =  "SPotassiumUnit", 
                              SPotassiumNor =  "SPotassiumNor", 
                              SChloride =  "SChloride", 
                              SChlorideUnit =  "SChlorideUnit", 
                              SChlorideNor =  "SChlorideNor", 
                              SCalcium =  "SCalcium", 
                              SCalciumUnit =  "SCalciumUnit", 
                              SCalciumNor =  "SCalciumNor", 
                              SProtein =  "SProtein", 
                              SProteinUnit =  "SProteinUnit", 
                              SProteinNor =  "SProteinNor", 
                              SAlbumin =  "SAlbumin", 
                              SAlbuminUnit =  "SAlbuminUnit", 
                              SAlbuminNor =  "SAlbuminNor", 
                              AGRatio =  "AGRatio", 
                              AGRatioUnit =  "AGRatioUnit", 
                              AGRatioNor =  "AGRatioNor", 
                              Fee = 12345, 
                  };         

        // One to Many
        var semenanalysis1= new SemenAnalysis 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Colour =  "Colour", 
                              Quantity =  "Quantity", 
                              Ph =  "Ph", 
                              TimeOfCollection =  "TimeOfCollection", 
                              TimeOfExamination =  "TimeOfExamination", 
                              TotalCount =  "TotalCount", 
                              ActiveMotility =  "ActiveMotility", 
                              Sluggish =  "Sluggish", 
                              NonMotile =  "NonMotile", 
                              Abnormal =  "Abnormal", 
                              PusCells =  "PusCells", 
                              Rbc =  "Rbc", 
                              EpithelialCell =  "EpithelialCell", 
                              Fee = 12345, 
                  };
        var semenanalysis2= new SemenAnalysis 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Colour =  "Colour", 
                              Quantity =  "Quantity", 
                              Ph =  "Ph", 
                              TimeOfCollection =  "TimeOfCollection", 
                              TimeOfExamination =  "TimeOfExamination", 
                              TotalCount =  "TotalCount", 
                              ActiveMotility =  "ActiveMotility", 
                              Sluggish =  "Sluggish", 
                              NonMotile =  "NonMotile", 
                              Abnormal =  "Abnormal", 
                              PusCells =  "PusCells", 
                              Rbc =  "Rbc", 
                              EpithelialCell =  "EpithelialCell", 
                              Fee = 12345, 
                  };         

        // One to Many
        var urineexamination1= new UrineExamination 
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
                  };
        var urineexamination2= new UrineExamination 
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
                  };         

        // One to Many
        var serology1= new Serology 
                 {
            Serialno = 12345, 
                              Patientid = 12345,
            Tdate = DateTime.Now, 
                              WidalTest =  "WidalTest", 
                              STyphiTo =  "STyphiTo", 
                              STyphiTh =  "STyphiTh", 
                              ParaThyphiAh =  "ParaThyphiAh", 
                              ParaThyphiBh =  "ParaThyphiBh", 
                              Typhoid =  "Typhoid", 
                              IGM =  "IGM", 
                              IGG =  "IGG", 
                              HbsAg =  "HbsAg", 
                              AsoTitre =  "AsoTitre", 
                              PregnancyTest =  "PregnancyTest", 
                              RaFactor =  "RaFactor", 
                              AntiHcv =  "AntiHcv", 
                              Mantoex =  "Mantoex", 
                              KahnsVdrl =  "KahnsVdrl", 
                              TbPlus =  "TbPlus", 
                              Igm =  "Igm", 
                              Igg =  "Igg", 
                              HelicobacterPylori =  "HelicobacterPylori", 
                              Hiv =  "Hiv", 
                              Fee = 12345, 
                  };
        var serology2= new Serology 
                 {
            Serialno = 12345, 
                              Patientid = 12345,
            Tdate = DateTime.Now, 
                              WidalTest =  "WidalTest", 
                              STyphiTo =  "STyphiTo", 
                              STyphiTh =  "STyphiTh", 
                              ParaThyphiAh =  "ParaThyphiAh", 
                              ParaThyphiBh =  "ParaThyphiBh", 
                              Typhoid =  "Typhoid", 
                              IGM =  "IGM", 
                              IGG =  "IGG", 
                              HbsAg =  "HbsAg", 
                              AsoTitre =  "AsoTitre", 
                              PregnancyTest =  "PregnancyTest", 
                              RaFactor =  "RaFactor", 
                              AntiHcv =  "AntiHcv", 
                              Mantoex =  "Mantoex", 
                              KahnsVdrl =  "KahnsVdrl", 
                              TbPlus =  "TbPlus", 
                              Igm =  "Igm", 
                              Igg =  "Igg", 
                              HelicobacterPylori =  "HelicobacterPylori", 
                              Hiv =  "Hiv", 
                              Fee = 12345, 
                  };         

         
        return new Patient
                {
                    
                    PatientID = 12345,
                    Name =  "Name",
                    Age =  "Age",
                    Sex =  "Sex",
                    RefBy =  "RefBy",
                    
                     // One to Many
                     Haematologies = new List<Haematology>{haematology1,haematology2},
                     // One to Many
                     ElisaTbs = new List<ElisaTb>{elisatb1,elisatb2},
                     // One to Many
                     ElisaHcvs = new List<ElisaHcv>{elisahcv1,elisahcv2},
                     // One to Many
                     ElisaHbsags = new List<ElisaHbsag>{elisahbsag1,elisahbsag2},
                     // One to Many
                     BloodGroups = new List<BloodGroup>{bloodgroup1,bloodgroup2},
                     // One to Many
                     Biochemistries = new List<Biochemistry>{biochemistry1,biochemistry2},
                     // One to Many
                     SemenAnalyses = new List<SemenAnalysis>{semenanalysis1,semenanalysis2},
                     // One to Many
                     UrineExaminations = new List<UrineExamination>{urineexamination1,urineexamination2},
                     // One to Many
                     Serologies = new List<Serology>{serology1,serology2},
                     
                };
         
       }
       public Patient SavePatient(Patient patient)
       {
         return null;
       }
       public List< Patient> Query(string query)
       {
          var resultList = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Patient
                {
                    
                  PatientID = i+12345, 
                  Name =  "Name"+i, 
                  Age =  "Age"+i, 
                  Sex =  "Sex"+i, 
                  RefBy =  "RefBy"+i, 
                });
            }
            return resultList;
       }
    
      public Task<Patient> AddPatientAsync(Patient patient)
      {
         return null;
      }
      public async Task<List<Patient>> GetAllPatientAsync()
      {
          var resultList = new List<Patient>();
          
              
              for (int i = 0; i < 10; i++)
              {
                  resultList.Add(new Patient
                  {

                      PatientID = i + 12345,
                      Name = "Name" + i,
                      Age = "Age" + i,
                      Sex = "Sex" + i,
                      RefBy = "RefBy" + i,
                  });
              }
             
              
         
          return resultList;
      }
      public async Task<Patient> FindPatientAsync(long id)
      {
         return new Patient
                {
                    
                    PatientID =  12345,
                    Name =  "Name",
                    Age =  "Age",
                    Sex =  "Sex",
                    RefBy =  "RefBy",
                };
      }
      public async Task<Patient> UpdatePatientAsync(Patient patient)
      {
        return null;
      }
      public async Task RemovePatientAsync(long id)
      {
        
      }
       
      public async Task<Patient> GetPatientWithChildrenAsync(long id)
      {
        // One to Many
        var haematology1= new Haematology 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Hb =  "Hb", 
                              HBUnit =  "HBUnit", 
                              HBNor =  "HBNor", 
                              Tlc =  "Tlc", 
                              TLCUnit =  "TLCUnit", 
                              TLCNor =  "TLCNor", 
                              Esr =  "Esr", 
                              ESRUnit =  "ESRUnit", 
                              ESRNor =  "ESRNor", 
                              Bt =  "Bt", 
                              BTUnit =  "BTUnit", 
                              BTNor =  "BTNor", 
                              Ct =  "Ct", 
                              CTUnit =  "CTUnit", 
                              CTNor =  "CTNor", 
                              PlateletsCount =  "PlateletsCount", 
                              PlateletsCountUnit =  "PlateletsCountUnit", 
                              PlateletsCountNor =  "PlateletsCountNor", 
                              Pt =  "Pt", 
                              PTUnit =  "PTUnit", 
                              PTNor =  "PTNor", 
                              Dlc =  "Dlc", 
                              DLCUnit =  "DLCUnit", 
                              DLCNor =  "DLCNor", 
                              Polymorphs =  "Polymorphs", 
                              PolymorphsUnit =  "PolymorphsUnit", 
                              PolymorphsNor =  "PolymorphsNor", 
                              Lymphocytes =  "Lymphocytes", 
                              LymphocytesUnit =  "LymphocytesUnit", 
                              LymphocytesNor =  "LymphocytesNor", 
                              Monocyte =  "Monocyte", 
                              MonocyteUnit =  "MonocyteUnit", 
                              MonocyteNor =  "MonocyteNor", 
                              Eosinophil =  "Eosinophil", 
                              EosinophilUnit =  "EosinophilUnit", 
                              EosinophilNor =  "EosinophilNor", 
                              Basophil =  "Basophil", 
                              BasophilUnit =  "BasophilUnit", 
                              BasophilNor =  "BasophilNor", 
                              MalariaParasites =  "MalariaParasites", 
                              MalariaParasitesUnit =  "MalariaParasitesUnit", 
                              MalariaParasitesNor =  "MalariaParasitesNor", 
                              BloodGroup =  "BloodGroup", 
                              BloodGroupUnit =  "BloodGroupUnit", 
                              BloodGroupNor =  "BloodGroupNor", 
                              RHFactor =  "RHFactor", 
                              RHFactorUnit =  "RHFactorUnit", 
                              RHFactorNor =  "RHFactorNor", 
                              TotalRBC =  "TotalRBC", 
                              TotalRBCUnit =  "TotalRBCUnit", 
                              TotalRBCNor =  "TotalRBCNor", 
                              PVCHaematorcrit =  "PVCHaematorcrit", 
                              PVCHaematorcritUnit =  "PVCHaematorcritUnit", 
                              PVCHaematorcritNor =  "PVCHaematorcritNor", 
                              MCV =  "MCV", 
                              MCVUnit =  "MCVUnit", 
                              MCVNor =  "MCVNor", 
                              MCH =  "MCH", 
                              MCHUnit =  "MCHUnit", 
                              MCHNor =  "MCHNor", 
                              MCHC =  "MCHC", 
                              MCHCUnit =  "MCHCUnit", 
                              MCHCNor =  "MCHCNor", 
                              Fee = 12345, 
                  };
        var haematology2= new Haematology 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Hb =  "Hb", 
                              HBUnit =  "HBUnit", 
                              HBNor =  "HBNor", 
                              Tlc =  "Tlc", 
                              TLCUnit =  "TLCUnit", 
                              TLCNor =  "TLCNor", 
                              Esr =  "Esr", 
                              ESRUnit =  "ESRUnit", 
                              ESRNor =  "ESRNor", 
                              Bt =  "Bt", 
                              BTUnit =  "BTUnit", 
                              BTNor =  "BTNor", 
                              Ct =  "Ct", 
                              CTUnit =  "CTUnit", 
                              CTNor =  "CTNor", 
                              PlateletsCount =  "PlateletsCount", 
                              PlateletsCountUnit =  "PlateletsCountUnit", 
                              PlateletsCountNor =  "PlateletsCountNor", 
                              Pt =  "Pt", 
                              PTUnit =  "PTUnit", 
                              PTNor =  "PTNor", 
                              Dlc =  "Dlc", 
                              DLCUnit =  "DLCUnit", 
                              DLCNor =  "DLCNor", 
                              Polymorphs =  "Polymorphs", 
                              PolymorphsUnit =  "PolymorphsUnit", 
                              PolymorphsNor =  "PolymorphsNor", 
                              Lymphocytes =  "Lymphocytes", 
                              LymphocytesUnit =  "LymphocytesUnit", 
                              LymphocytesNor =  "LymphocytesNor", 
                              Monocyte =  "Monocyte", 
                              MonocyteUnit =  "MonocyteUnit", 
                              MonocyteNor =  "MonocyteNor", 
                              Eosinophil =  "Eosinophil", 
                              EosinophilUnit =  "EosinophilUnit", 
                              EosinophilNor =  "EosinophilNor", 
                              Basophil =  "Basophil", 
                              BasophilUnit =  "BasophilUnit", 
                              BasophilNor =  "BasophilNor", 
                              MalariaParasites =  "MalariaParasites", 
                              MalariaParasitesUnit =  "MalariaParasitesUnit", 
                              MalariaParasitesNor =  "MalariaParasitesNor", 
                              BloodGroup =  "BloodGroup", 
                              BloodGroupUnit =  "BloodGroupUnit", 
                              BloodGroupNor =  "BloodGroupNor", 
                              RHFactor =  "RHFactor", 
                              RHFactorUnit =  "RHFactorUnit", 
                              RHFactorNor =  "RHFactorNor", 
                              TotalRBC =  "TotalRBC", 
                              TotalRBCUnit =  "TotalRBCUnit", 
                              TotalRBCNor =  "TotalRBCNor", 
                              PVCHaematorcrit =  "PVCHaematorcrit", 
                              PVCHaematorcritUnit =  "PVCHaematorcritUnit", 
                              PVCHaematorcritNor =  "PVCHaematorcritNor", 
                              MCV =  "MCV", 
                              MCVUnit =  "MCVUnit", 
                              MCVNor =  "MCVNor", 
                              MCH =  "MCH", 
                              MCHUnit =  "MCHUnit", 
                              MCHNor =  "MCHNor", 
                              MCHC =  "MCHC", 
                              MCHCUnit =  "MCHCUnit", 
                              MCHCNor =  "MCHCNor", 
                              Fee = 12345, 
                  };         

        // One to Many
        var elisatb1= new ElisaTb 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };
        var elisatb2= new ElisaTb 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };         

        // One to Many
        var elisahcv1= new ElisaHcv 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };
        var elisahcv2= new ElisaHcv 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };         

        // One to Many
        var elisahbsag1= new ElisaHbsag 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };
        var elisahbsag2= new ElisaHbsag 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientValue = 12345, 
                              CutOffValue = 12345, 
                              Fee = 12345, 
                  };         

        // One to Many
        var bloodgroup1= new BloodGroup 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientBloodGroup =  "PatientBloodGroup", 
                              DonarName =  "DonarName", 
                              DonarBloodGroup =  "DonarBloodGroup", 
                              HbsAg =  "HbsAg", 
                              AntiHCV =  "AntiHCV", 
                              Fee = 12345, 
                  };
        var bloodgroup2= new BloodGroup 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              PatientBloodGroup =  "PatientBloodGroup", 
                              DonarName =  "DonarName", 
                              DonarBloodGroup =  "DonarBloodGroup", 
                              HbsAg =  "HbsAg", 
                              AntiHCV =  "AntiHCV", 
                              Fee = 12345, 
                  };         

        // One to Many
        var biochemistry1= new Biochemistry 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              BloodSugarFasting =  "BloodSugarFasting", 
                              BloodSugarFastingUnit =  "BloodSugarFastingUnit", 
                              BloodSugarFastingNor =  "BloodSugarFastingNor", 
                              BloodSugar2HPP =  "BloodSugar2HPP", 
                              BloodSugar2HPPUnit =  "BloodSugar2HPPUnit", 
                              BloodSugar2HPPNor =  "BloodSugar2HPPNor", 
                              BloodSugarRandom =  "BloodSugarRandom", 
                              BloodSugarRandomUnit =  "BloodSugarRandomUnit", 
                              BloodSugarRandomNor =  "BloodSugarRandomNor", 
                              BloodUrea =  "BloodUrea", 
                              BloodUreaUnit =  "BloodUreaUnit", 
                              BloodUreaNor =  "BloodUreaNor", 
                              Bun =  "Bun", 
                              BUNUnit =  "BUNUnit", 
                              BUNNor =  "BUNNor", 
                              SCreatinine =  "SCreatinine", 
                              SCreatinineUnit =  "SCreatinineUnit", 
                              SCreatinineNor =  "SCreatinineNor", 
                              SUricAcid =  "SUricAcid", 
                              SUricAcidUnit =  "SUricAcidUnit", 
                              SUricAcidNor =  "SUricAcidNor", 
                              SCholestrol =  "SCholestrol", 
                              SCholestrolUnit =  "SCholestrolUnit", 
                              SCholestrolNor =  "SCholestrolNor", 
                              STriglycerides =  "STriglycerides", 
                              STriglyceridesUnit =  "STriglyceridesUnit", 
                              STriglyceridesNor =  "STriglyceridesNor", 
                              HDLCholestrol =  "HDLCholestrol", 
                              HDLCholestrolUnit =  "HDLCholestrolUnit", 
                              HDLCholestrolNor =  "HDLCholestrolNor", 
                              LDLCholestrol =  "LDLCholestrol", 
                              LDLCholestrolUnit =  "LDLCholestrolUnit", 
                              LDLCholestrolNor =  "LDLCholestrolNor", 
                              SgotAst =  "SgotAst", 
                              SGOTASTUnit =  "SGOTASTUnit", 
                              SGOTNor =  "SGOTNor", 
                              Ldh =  "Ldh", 
                              LDHUnit =  "LDHUnit", 
                              LDHNor =  "LDHNor", 
                              Cpk =  "Cpk", 
                              CPKUnit =  "CPKUnit", 
                              CPKNor =  "CPKNor", 
                              Ckmb =  "Ckmb", 
                              CKMBUnit =  "CKMBUnit", 
                              CKMBNor =  "CKMBNor", 
                              SBilirubinT =  "SBilirubinT", 
                              SBilirubinTUnit =  "SBilirubinTUnit", 
                              SBilirubinTNor =  "SBilirubinTNor", 
                              SBilirubinD =  "SBilirubinD", 
                              SBilirubinDUnit =  "SBilirubinDUnit", 
                              SBilirubinDNor =  "SBilirubinDNor", 
                              SBilirubinInd =  "SBilirubinInd", 
                              SBilirubinIndUnit =  "SBilirubinIndUnit", 
                              SBilirubinIndNor =  "SBilirubinIndNor", 
                              SAlkPhosphatase =  "SAlkPhosphatase", 
                              SAlkPhosphataseUnit =  "SAlkPhosphataseUnit", 
                              SAlkPhosphataseNor =  "SAlkPhosphataseNor", 
                              SgptAlt =  "SgptAlt", 
                              SGPTALTUnit =  "SGPTALTUnit", 
                              SGPTALTNor =  "SGPTALTNor", 
                              SSodium =  "SSodium", 
                              SSodiumUnit =  "SSodiumUnit", 
                              SSodiumNor =  "SSodiumNor", 
                              SPotassium =  "SPotassium", 
                              SPotassiumUnit =  "SPotassiumUnit", 
                              SPotassiumNor =  "SPotassiumNor", 
                              SChloride =  "SChloride", 
                              SChlorideUnit =  "SChlorideUnit", 
                              SChlorideNor =  "SChlorideNor", 
                              SCalcium =  "SCalcium", 
                              SCalciumUnit =  "SCalciumUnit", 
                              SCalciumNor =  "SCalciumNor", 
                              SProtein =  "SProtein", 
                              SProteinUnit =  "SProteinUnit", 
                              SProteinNor =  "SProteinNor", 
                              SAlbumin =  "SAlbumin", 
                              SAlbuminUnit =  "SAlbuminUnit", 
                              SAlbuminNor =  "SAlbuminNor", 
                              AGRatio =  "AGRatio", 
                              AGRatioUnit =  "AGRatioUnit", 
                              AGRatioNor =  "AGRatioNor", 
                              Fee = 12345, 
                  };
        var biochemistry2= new Biochemistry 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              BloodSugarFasting =  "BloodSugarFasting", 
                              BloodSugarFastingUnit =  "BloodSugarFastingUnit", 
                              BloodSugarFastingNor =  "BloodSugarFastingNor", 
                              BloodSugar2HPP =  "BloodSugar2HPP", 
                              BloodSugar2HPPUnit =  "BloodSugar2HPPUnit", 
                              BloodSugar2HPPNor =  "BloodSugar2HPPNor", 
                              BloodSugarRandom =  "BloodSugarRandom", 
                              BloodSugarRandomUnit =  "BloodSugarRandomUnit", 
                              BloodSugarRandomNor =  "BloodSugarRandomNor", 
                              BloodUrea =  "BloodUrea", 
                              BloodUreaUnit =  "BloodUreaUnit", 
                              BloodUreaNor =  "BloodUreaNor", 
                              Bun =  "Bun", 
                              BUNUnit =  "BUNUnit", 
                              BUNNor =  "BUNNor", 
                              SCreatinine =  "SCreatinine", 
                              SCreatinineUnit =  "SCreatinineUnit", 
                              SCreatinineNor =  "SCreatinineNor", 
                              SUricAcid =  "SUricAcid", 
                              SUricAcidUnit =  "SUricAcidUnit", 
                              SUricAcidNor =  "SUricAcidNor", 
                              SCholestrol =  "SCholestrol", 
                              SCholestrolUnit =  "SCholestrolUnit", 
                              SCholestrolNor =  "SCholestrolNor", 
                              STriglycerides =  "STriglycerides", 
                              STriglyceridesUnit =  "STriglyceridesUnit", 
                              STriglyceridesNor =  "STriglyceridesNor", 
                              HDLCholestrol =  "HDLCholestrol", 
                              HDLCholestrolUnit =  "HDLCholestrolUnit", 
                              HDLCholestrolNor =  "HDLCholestrolNor", 
                              LDLCholestrol =  "LDLCholestrol", 
                              LDLCholestrolUnit =  "LDLCholestrolUnit", 
                              LDLCholestrolNor =  "LDLCholestrolNor", 
                              SgotAst =  "SgotAst", 
                              SGOTASTUnit =  "SGOTASTUnit", 
                              SGOTNor =  "SGOTNor", 
                              Ldh =  "Ldh", 
                              LDHUnit =  "LDHUnit", 
                              LDHNor =  "LDHNor", 
                              Cpk =  "Cpk", 
                              CPKUnit =  "CPKUnit", 
                              CPKNor =  "CPKNor", 
                              Ckmb =  "Ckmb", 
                              CKMBUnit =  "CKMBUnit", 
                              CKMBNor =  "CKMBNor", 
                              SBilirubinT =  "SBilirubinT", 
                              SBilirubinTUnit =  "SBilirubinTUnit", 
                              SBilirubinTNor =  "SBilirubinTNor", 
                              SBilirubinD =  "SBilirubinD", 
                              SBilirubinDUnit =  "SBilirubinDUnit", 
                              SBilirubinDNor =  "SBilirubinDNor", 
                              SBilirubinInd =  "SBilirubinInd", 
                              SBilirubinIndUnit =  "SBilirubinIndUnit", 
                              SBilirubinIndNor =  "SBilirubinIndNor", 
                              SAlkPhosphatase =  "SAlkPhosphatase", 
                              SAlkPhosphataseUnit =  "SAlkPhosphataseUnit", 
                              SAlkPhosphataseNor =  "SAlkPhosphataseNor", 
                              SgptAlt =  "SgptAlt", 
                              SGPTALTUnit =  "SGPTALTUnit", 
                              SGPTALTNor =  "SGPTALTNor", 
                              SSodium =  "SSodium", 
                              SSodiumUnit =  "SSodiumUnit", 
                              SSodiumNor =  "SSodiumNor", 
                              SPotassium =  "SPotassium", 
                              SPotassiumUnit =  "SPotassiumUnit", 
                              SPotassiumNor =  "SPotassiumNor", 
                              SChloride =  "SChloride", 
                              SChlorideUnit =  "SChlorideUnit", 
                              SChlorideNor =  "SChlorideNor", 
                              SCalcium =  "SCalcium", 
                              SCalciumUnit =  "SCalciumUnit", 
                              SCalciumNor =  "SCalciumNor", 
                              SProtein =  "SProtein", 
                              SProteinUnit =  "SProteinUnit", 
                              SProteinNor =  "SProteinNor", 
                              SAlbumin =  "SAlbumin", 
                              SAlbuminUnit =  "SAlbuminUnit", 
                              SAlbuminNor =  "SAlbuminNor", 
                              AGRatio =  "AGRatio", 
                              AGRatioUnit =  "AGRatioUnit", 
                              AGRatioNor =  "AGRatioNor", 
                              Fee = 12345, 
                  };         

        // One to Many
        var semenanalysis1= new SemenAnalysis 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Colour =  "Colour", 
                              Quantity =  "Quantity", 
                              Ph =  "Ph", 
                              TimeOfCollection =  "TimeOfCollection", 
                              TimeOfExamination =  "TimeOfExamination", 
                              TotalCount =  "TotalCount", 
                              ActiveMotility =  "ActiveMotility", 
                              Sluggish =  "Sluggish", 
                              NonMotile =  "NonMotile", 
                              Abnormal =  "Abnormal", 
                              PusCells =  "PusCells", 
                              Rbc =  "Rbc", 
                              EpithelialCell =  "EpithelialCell", 
                              Fee = 12345, 
                  };
        var semenanalysis2= new SemenAnalysis 
                 {
            SerialNo = 12345, 
                              PatientID = 12345, 
                              TDate =  DateTime.Now, 
                              Colour =  "Colour", 
                              Quantity =  "Quantity", 
                              Ph =  "Ph", 
                              TimeOfCollection =  "TimeOfCollection", 
                              TimeOfExamination =  "TimeOfExamination", 
                              TotalCount =  "TotalCount", 
                              ActiveMotility =  "ActiveMotility", 
                              Sluggish =  "Sluggish", 
                              NonMotile =  "NonMotile", 
                              Abnormal =  "Abnormal", 
                              PusCells =  "PusCells", 
                              Rbc =  "Rbc", 
                              EpithelialCell =  "EpithelialCell", 
                              Fee = 12345, 
                  };         

        // One to Many
        var urineexamination1= new UrineExamination 
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
                  };
        var urineexamination2= new UrineExamination 
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
                  };         

        // One to Many
        var serology1= new Serology 
                 {
            Serialno = 12345, 
                              Patientid = 12345,
            Tdate = DateTime.Now, 
                              WidalTest =  "WidalTest", 
                              STyphiTo =  "STyphiTo", 
                              STyphiTh =  "STyphiTh", 
                              ParaThyphiAh =  "ParaThyphiAh", 
                              ParaThyphiBh =  "ParaThyphiBh", 
                              Typhoid =  "Typhoid", 
                              IGM =  "IGM", 
                              IGG =  "IGG", 
                              HbsAg =  "HbsAg", 
                              AsoTitre =  "AsoTitre", 
                              PregnancyTest =  "PregnancyTest", 
                              RaFactor =  "RaFactor", 
                              AntiHcv =  "AntiHcv", 
                              Mantoex =  "Mantoex", 
                              KahnsVdrl =  "KahnsVdrl", 
                              TbPlus =  "TbPlus", 
                              Igm =  "Igm", 
                              Igg =  "Igg", 
                              HelicobacterPylori =  "HelicobacterPylori", 
                              Hiv =  "Hiv", 
                              Fee = 12345, 
                  };
        var serology2= new Serology 
                 {
            Serialno = 12345, 
                              Patientid = 12345,
            Tdate = DateTime.Now, 
                              WidalTest =  "WidalTest", 
                              STyphiTo =  "STyphiTo", 
                              STyphiTh =  "STyphiTh", 
                              ParaThyphiAh =  "ParaThyphiAh", 
                              ParaThyphiBh =  "ParaThyphiBh", 
                              Typhoid =  "Typhoid", 
                              IGM =  "IGM", 
                              IGG =  "IGG", 
                              HbsAg =  "HbsAg", 
                              AsoTitre =  "AsoTitre", 
                              PregnancyTest =  "PregnancyTest", 
                              RaFactor =  "RaFactor", 
                              AntiHcv =  "AntiHcv", 
                              Mantoex =  "Mantoex", 
                              KahnsVdrl =  "KahnsVdrl", 
                              TbPlus =  "TbPlus", 
                              Igm =  "Igm", 
                              Igg =  "Igg", 
                              HelicobacterPylori =  "HelicobacterPylori", 
                              Hiv =  "Hiv", 
                              Fee = 12345, 
                  };         

         
        return new Patient
                {
                    
                    PatientID = 12345,
                    Name =  "Name",
                    Age =  "Age",
                    Sex =  "Sex",
                    RefBy =  "RefBy",
                    
                     // One to Many
                     Haematologies = new List<Haematology>{haematology1,haematology2},
                     // One to Many
                     ElisaTbs = new List<ElisaTb>{elisatb1,elisatb2},
                     // One to Many
                     ElisaHcvs = new List<ElisaHcv>{elisahcv1,elisahcv2},
                     // One to Many
                     ElisaHbsags = new List<ElisaHbsag>{elisahbsag1,elisahbsag2},
                     // One to Many
                     BloodGroups = new List<BloodGroup>{bloodgroup1,bloodgroup2},
                     // One to Many
                     Biochemistries = new List<Biochemistry>{biochemistry1,biochemistry2},
                     // One to Many
                     SemenAnalyses = new List<SemenAnalysis>{semenanalysis1,semenanalysis2},
                     // One to Many
                     UrineExaminations = new List<UrineExamination>{urineexamination1,urineexamination2},
                     // One to Many
                     Serologies = new List<Serology>{serology1,serology2},
                     
                };
         
      }
      public async Task<Patient> SavePatientAsync(Patient patient)
      {
        return null;
      }
      public async Task<List<Patient>> QueryAsync(string query)
      {
         var resultList = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Patient
                {
                    
                  PatientID = i+12345, 
                  Name =  "Name"+i, 
                  Age =  "Age"+i, 
                  Sex =  "Sex"+i, 
                  RefBy =  "RefBy"+i, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
     
}